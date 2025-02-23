namespace NPUApi.Models.Db;

public class Npu
{
    public Guid Id { get; set; }
    public string User { get; set; }
    public string Title { get; set; }
    public string FileName { get; set; }
    public string SearchTerms { get; set; }
}
