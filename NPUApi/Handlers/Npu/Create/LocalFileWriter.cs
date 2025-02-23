namespace NPUApi.Handlers.Npu.Create;

public class LocalFileWriter : IFileWriter
{
    public async Task<string> Write(IFormFile file, CancellationToken cancellationToken)
    {
        var fileName = Guid.NewGuid().ToString();
        var filePath = Path.Combine(Path.GetTempPath(), fileName);

        await using var stream = new FileStream(filePath, FileMode.Create);
        await file.CopyToAsync(stream, cancellationToken);
        return fileName;
    }
}