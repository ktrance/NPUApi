using MediatR;
using NPUApi.Models.Response.Npu;

namespace NPUApi.Models.Requests.Npu;

public class CreateRequest : IRequest<CreateResponse>
{
    public string User { get; set; }
    public string Title { get; set; }
    public IFormFile File { get; set; }
}
