namespace TestProject1.Services;

public class StudentServiceHoldingActualStudent : StudentService
{
    public StudentServiceHoldingActualStudent(Student student) : base(student)
    {
    }
}
