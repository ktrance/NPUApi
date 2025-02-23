using MediatR;
using Microsoft.EntityFrameworkCore;
using NPUApi.Models.Db;
using NPUApi.Models.Requests.Npu;
using NPUApi.Models.Response.Npu;

namespace NPUApi.Handlers.Npu.Get;

public class GetHandller(NpuDbContext dbContext) : IRequestHandler<GetRequest, GetResponse>
{
    public async Task<GetResponse> Handle(GetRequest request, CancellationToken cancellationToken)
    {
        var npu = await dbContext.Npus.Where(n => n.Id == request.Id).SingleAsync(cancellationToken);
        return new GetResponse { Id = npu.Id, User = npu.User, Title = npu.Title, FileName = npu.FileName };
    }
}