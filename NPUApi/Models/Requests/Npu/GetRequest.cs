using MediatR;
using NPUApi.Models.Response.Npu;

namespace NPUApi.Models.Requests.Npu;

public class GetRequest : IRequest<GetResponse>
{
    public Guid Id { get; set; }
}