namespace TestProject1.Services;

public class StudentServiceHoldingCopyOfStudent : StudentService
{
    public StudentServiceHoldingCopyOfStudent(Student student) : base(new Student(student))
    {
    }
}