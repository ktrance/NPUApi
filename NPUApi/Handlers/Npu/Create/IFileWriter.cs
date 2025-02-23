namespace NPUApi.Handlers.Npu.Create;

public interface IFileWriter
{
    Task<string> Write(IFormFile file, CancellationToken cancellationToken);
}