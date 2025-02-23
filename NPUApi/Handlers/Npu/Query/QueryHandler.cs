using MediatR;
using Microsoft.EntityFrameworkCore;
using NPUApi.Models.Db;
using NPUApi.Models.Requests.Npu;
using NPUApi.Models.Response.Npu;

namespace NPUApi.Handlers.Npu.Query;

public class QueryHandler(NpuDbContext dbContext) : IRequestHandler<QueryRequest, List<QueryResponse>>
{
    public async Task<List<QueryResponse>> Handle(QueryRequest request, CancellationToken cancellationToken)
    {
        var data = await dbContext.Npus
            .Where(n => n.SearchTerms.Contains(request.SearchTerm))
            .ToListAsync(cancellationToken);

        return data.Select(n => new QueryResponse { Id = n.Id, User = n.User, Title = n.Title, FileName = n.FileName })
            .ToList();
    }
}