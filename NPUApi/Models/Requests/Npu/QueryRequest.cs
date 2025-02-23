using MediatR;
using NPUApi.Models.Response.Npu;

namespace NPUApi.Models.Requests.Npu;

public class QueryRequest : IRequest<List<QueryResponse>>
{
    public string SearchTerm { get; set; }
}