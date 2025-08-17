namespace TestProject1;

public class StudentServiceHoldingCopyOfStudentTest
{
    private readonly Student _student;
    private readonly IStudentService _service;
    private readonly CancellationToken _ct;

    public StudentServiceHoldingCopyOfStudentTest()
    {
        _student = new Student(34, "Jon 34", "sample.txt");
        _service = new StudentServiceHoldingCopyOfStudent(_student);
        _ct = CancellationToken.None;
    }

    [Fact]
    public void GetMessage_ReturnSameMessage_EvenIfNameChanges()
    {
        string msg;

        using (_student)
        {
            msg = _service.GetMessage();
            msg.ShouldBe("Hello Jon 34");

            _student.Name = "Jon 34 - Updated";

            msg = _service.GetMessage();
            msg.ShouldBe("Hello Jon 34");
        }

        msg = _service.GetMessage();
        msg.ShouldBe("Hello Jon 34");
    }

    [Fact]
    public async Task GetContent_DoNotThrowsException_EvenIfReaderDisposed()
    {
        string content;

        using (_student)
        {
            content = await _service.GetContentAsync(_ct);
            content.ShouldNotBeNullOrEmpty();
        }

        content = await _service.GetContentAsync(_ct);
        content.ShouldBeEmpty(); // Return empty because it already read the content. The important point is, it is not throwing exception.
    }
}