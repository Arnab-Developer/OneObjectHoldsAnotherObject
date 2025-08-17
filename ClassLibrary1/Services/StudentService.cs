namespace ClassLibrary1.Services;

public abstract class StudentService : IStudentService
{
    private readonly Student _student;

    protected StudentService(Student student)
    {
        _student = student;
    }

    public Student Student
    {
        get
        {
            return _student;
        }
    }

    public string GetMessage()
    {
        return $"Hello {Student.Name}";
    }

    public async Task<string> GetContentAsync(CancellationToken ct)
    {
        return await Student.Reader.ReadToEndAsync(ct);
    }
}