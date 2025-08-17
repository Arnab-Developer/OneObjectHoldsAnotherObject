namespace TestProject1.Services;

public interface IStudentService
{
    public Student Student { get; }

    public string GetMessage();

    public Task<string> GetContentAsync(CancellationToken ct);
}