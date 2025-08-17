namespace TestProject1;

public class StudentServiceHoldingActualStudentTest
{
    private readonly Student _student;
    private readonly IStudentService _service;
    private readonly CancellationToken _ct;

    public StudentServiceHoldingActualStudentTest()
    {
        _student = new Student(34, "Jon 34", "sample.txt");
        _service = new StudentServiceHoldingActualStudent(_student);
        _ct = CancellationToken.None;
    }

    [Fact]
    public void GetMessage_ReturnUpdatedMessage_WhenNameChanges()
    {
        string msg;

        using (_student)
        {
            msg = _service.GetMessage();
            msg.ShouldBe("Hello Jon 34");

            _student.Name = "Jon 34 - Updated";

            msg = _service.GetMessage();
            msg.ShouldBe("Hello Jon 34 - Updated");
        }

        msg = _service.GetMessage();
        msg.ShouldBe("Hello ");
    }

    [Fact]
    public async Task GetContent_ThrowsException_WhenReaderDisposed()
    {
        string content;

        using (_student)
        {
            content = await _service.GetContentAsync(_ct);
            content.ShouldNotBeNullOrEmpty();
        }

        var func = async () => await _service.GetContentAsync(_ct);
        var ex = await func.ShouldThrowAsync<InvalidOperationException>();
    }
}
