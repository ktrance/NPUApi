using MediatR;
using NPUApi.Models.Db;
using NPUApi.Models.Requests.Npu;
using NPUApi.Models.Response.Npu;

namespace NPUApi.Handlers.Npu.Create;

public class CreateHandler(IFileWriter writer, IFilePublisher publisher, NpuDbContext dbContext) : IRequestHandler<CreateRequest, CreateResponse>
{
    public async Task<CreateResponse> Handle(CreateRequest request, CancellationToken cancellationToken)
    {
        var fileName = await writer.Write(request.File, cancellationToken);
        var id = Guid.NewGuid();

        await dbContext.AddAsync(new Models.Db.Npu { Id = id, User = request.User, Title = request.Title, FileName = fileName, SearchTerms = request.Title}, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        await publisher.Publish(fileName, cancellationToken);

        return new CreateResponse { Id = id, User = request.User, Title = request.Title, FileName = fileName };
    }
}