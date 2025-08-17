namespace TestProject1.Models;

public class Student : IDisposable
{
    private bool disposedValue;

    public int Id { get; set; }

    public string Name { get; set; }

    public string FileName { get; set; }

    public StreamReader Reader { get; set; }

    public Student(int id, string name, string fileName)
    {
        Id = id;
        Name = name;
        FileName = fileName;
        Reader = new StreamReader(FileName);
    }

    // Copy constructor.
    public Student(Student input)
    {
        Id = input.Id;
        Name = input.Name;
        FileName = input.FileName;
        Reader = new StreamReader(FileName);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                // TODO: dispose managed state (managed objects)
                Id = 0;
                Name = "";
            }

            // TODO: free unmanaged resources (unmanaged objects) and override finalizer
            // TODO: set large fields to null
            Reader?.Dispose();
            disposedValue = true;
        }
    }

    // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
    ~Student()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(false);
    }

    void IDisposable.Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
