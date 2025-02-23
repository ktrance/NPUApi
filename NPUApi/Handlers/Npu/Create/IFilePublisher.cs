namespace NPUApi.Handlers.Npu.Create;

public interface IFilePublisher
{
    Task Publish(string filename, CancellationToken cancellationToken);
}