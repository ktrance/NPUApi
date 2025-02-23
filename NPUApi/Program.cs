using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NPUApi.Handlers.Npu.Create;
using NPUApi.Models.Db;
using NPUApi.Models.Requests.Npu;
using NPUApi.Models.ViewModels;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());
builder.Services.AddTransient<IFileWriter, LocalFileWriter>();
builder.Services.AddTransient<IFilePublisher, NullFilePublisher>();
builder.Services.AddDbContext<NpuDbContext>(options => options.UseInMemoryDatabase("database"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/api/npu", async ([FromForm] Npu npu, IMediator mediator, CancellationToken cancellationToken) =>
    {
        var response = await mediator.Send(new CreateRequest { User = "user"/*should come from auth middleware*/, Title = npu.Name, File = npu.Image }, cancellationToken);
        return new NpuViewModel {Id = response.Id, User = response.User, Title = response.Title, FileName = response.FileName};

    })
    .WithOpenApi()
    .DisableAntiforgery();

app.MapGet("/api/npu/{id}", async ([FromRoute] Guid id, IMediator mediator, CancellationToken cancellationToken) =>
    {
        var response = await mediator.Send(new GetRequest { Id = id }, cancellationToken);
        return new NpuViewModel
            { Id = response.Id, User = response.User, Title = response.Title, FileName = response.FileName };

    })
    .WithOpenApi();

app.MapGet("/api/npu/query", async (string name, IMediator mediator, CancellationToken cancellationToken) =>
    {
        var response = await mediator.Send(new QueryRequest { SearchTerm = name}, cancellationToken);
        return response.Select(n => new NpuViewModel
            { Id = n.Id, User = n.User, Title = n.Title, FileName = n.FileName }).ToList();

    })
    .WithOpenApi();

app.MapPatch("/api/npu/query", async (UpdateSearchTerms terms, IMediator mediator, CancellationToken cancellationToken) =>
    {
        // not implemented
        // intended to be called from search indexer
    })
    .WithOpenApi();


app.MapGet("/api/npu/{id}/score", async ([FromRoute] Guid id, IMediator mediator, CancellationToken cancellationToken) =>
    {
        // not implemented
        // should follow same structure as other post but return a list of scores

    })
    .WithOpenApi();

app.MapPost("/api/npu/{id}/score", async ([FromRoute] Guid id, [FromBody]NpuScore npuScore, IMediator mediator, CancellationToken cancellationToken) =>
    {
        // not implemented
        // should follow same structure as other post

    })
    .WithOpenApi();



app.Run();

record Npu(string Name, IFormFile Image)
{
}

record NpuScore(int Score)
{
}

record UpdateSearchTerms(string FileName, string SearchTerms)
{
}