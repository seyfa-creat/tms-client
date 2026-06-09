public class EnrollmentService
{
public EnrollmentRecord ProcessRegistration(Student? student, Course? course)
{
// TODO1:Addguard clauses fail fast if student is null, course is null,
//
or course capacity is zero or negative.
//
Use ArgumentNullException for nulls, InvalidOperationException for full course.
// Stuck? Pattern: if (param is null) throw new ArgumentNullException(nameof(param));
>= 3.5 →"Honors"
// TODO2:Useaswitch expression on student.GPA to classify academic standing:
//
//
//
//
>= 2.5 →"GoodStanding"
< 2.5 →"AcademicWarning"
Print the result: $"{student.Name} is in {standing}."
// Stuck? Pattern: string result = value switch { >= X => "Label", ... };
// TODO3:Return a newEnrollmentRecord with student.Id, course.Code,
//
and DateTime.UtcNow.
}
}
var service = new EnrollmentService();
// Test 1: Valid registration
var validStudent = new Student { Id = "S1", Name = "Abeba", Age = 20, GPA = 3.8m };
var validCourse = new Course { Code = "CS-401", Title = "Advanced C#", Capacity = 30 };
var result = service.ProcessRegistration(validStudent, validCourse);
Console.WriteLine($"Enrolled: {result.StudentId} in {result.CourseCode}");
// Test 2: Null student should throw
try
{
}
service.ProcessRegistration(null, validCourse);
catch (ArgumentNullException ex)
{
Console.WriteLine($"Guard caught: {ex.ParamName}");
}
// Test 3: Full course should throw
var fullCourse = new Course { Code = "CS-402", Title = "Full Course", Capacity = 1 };
fullCourse.EnrolledCount = 1;
try
{
}
service.ProcessRegistration(validStudent, fullCourse);
catch (InvalidOperationException ex)
{
Console.WriteLine($"Business rule: {ex.Message}");
}
Run it:
dotnet run