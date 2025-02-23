namespace NPUApi.Handlers.Npu.Create;

public class NullFilePublisher : IFilePublisher
{
    public Task Publish(string filename, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}