public class TmsDatabaseException : Exception
{
public string Operation { get; }
public TmsDatabaseException(string operation, string message)
: base(message)
{
Operation = operation;
}
public TmsDatabaseException(string operation, string message, Exception innerException)
: base(message, innerException)
{
}
}
Operation = operation;
public class CapacityReachedException : InvalidOperationException
{
public string CourseCode { get; }
public CapacityReachedException(string courseCode)
: base($"Course {courseCode} has reached maximum capacity.")
{
}
CourseCode = courseCode;
public CapacityReachedException(string courseCode, Exception innerException)
: base($"Course {courseCode} has reached maximum capacity.", innerException)
{
CourseCode = courseCode;
}
}
public class EnrollmentService
{
public EnrollmentRecord ProcessRegistration(Student? student, Course? course)
{
if (student is null)
throw new ArgumentNullException(nameof(student));
if (course is null)
throw new ArgumentNullException(nameof(course));
if (course.EnrolledCount >= course.Capacity)
throw new CapacityReachedException(course.Code);
string standing = student.GPA switch
{
>= 3.5m=>"Honors",
>= 2.5m=>"GoodStanding",
_ =>"Academic Warning"
};
Console.WriteLine($" {student.Name} is in {standing}.");
return new EnrollmentRecord(student.Id, course.Code, DateTime.UtcNow);
}
}
// This already works (catches any InvalidOperationException, including CapacityReachedExcepti
on):
catch (InvalidOperationException ex)
// This is more precise (lets you access ex.CourseCode):
catch (CapacityReachedException ex)
{
}
var overflowCourse = new Course { Code = "CRS-999", Title = "Overflow Test", Capacity = 0 };
enrollService.ProcessRegistration(
newStudent { Id = "S99", Name = "Test", Age = 20, GPA = 3.0m },
overflowCourse
);
catch (CapacityReachedException ex)
{
Console.WriteLine($"\nDomain exception caught:");
Console.WriteLine($" Course: {ex.CourseCode}");
Console.WriteLine($" Message: {ex.Message}");
}
Run it:
dotnet run