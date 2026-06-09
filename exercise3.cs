// Legacy Pre-C# 14 Implementation (Verbose)
public class Course
{
private int _capacity; // Manual backing field
public int Capacity
{
get => _capacity;
set
{
}
}
}
if (value <= 0)
throw newArgumentOutOfRangeException("Capacity must be positive.");
_capacity = value;
C# 14 introduced the field keyword — you write validation directly in the setter and the
compiler generates the backing field for you.
Addthe Course class to Models.cs:
public class Course
{
public required string Code { get; init; }
public required string Title
{
get;
set => field = !string.IsNullOrWhiteSpace(value)
? value
: throw new ArgumentException("Title cannot be empty or whitespace.", nameof(value));
}
// C# 14Auto-property validation using 'field'
public int Capacity
{
get;
set => field = value > 0
? value
: throw new ArgumentOutOfRangeException(nameof(value), "System constraint: Capacit
y must begreater than zero.");
}
public int EnrolledCount { get; set; }
}
Test it in Program.cs:
var course = new Course{ Code = "CS-401", Title = "Advanced C#", Capacity = 30 };
Console.WriteLine($"Course: {course.Title} (Capacity: {course.Capacity})");
// Invalid capacity — should throw
try
{
}
course.Capacity =-5;
catch (ArgumentOutOfRangeException ex)
{
Console.WriteLine($"Caught: {ex.Message}");
}
// Invalid title — should throw
try
{
}
course.Title = "";
catch (ArgumentException ex)
{
Console.WriteLine($"Caught: {ex.Message}");
}
Run it:
dotnet run