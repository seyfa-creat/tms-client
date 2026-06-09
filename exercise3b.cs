public class Student
{
public required string Id { get; init; }
public required string Name
{
get;
set => field = !string.IsNullOrWhiteSpace(value)
? value
: throw new ArgumentException("Name cannot be empty or whitespace.", nameof(valu
e));
}
public int Age
{
get;
set => field = value is >= 16 and <= 100
? value
: throw new ArgumentOutOfRangeException(nameof(value), "Age must be between 16 a
nd 100.");
}
public decimal GPA
{
get;
set => field = value is >= 0.0m and <= 4.0m
? value
: throw new ArgumentOutOfRangeException(nameof(value), "GPA must be between 0.0
and 4.0.");
}
}
Test it in Program.cs:
var s = newStudent { Id = "S1", Name ="Abeba", Age = 20, GPA= 3.8m };
Console.WriteLine($"Student: {s.Name}, GPA: {s.GPA}");
// These should throw — try each one:
// new Student { Id = "S2", Name = "", Age = 20, GPA= 3.0m };
// new Student { Id = "S3", Name = "Test", Age = 12, GPA = 3.0m };
// new Student { Id = "S4", Name = "Test", Age = 20, GPA = 5.0m };