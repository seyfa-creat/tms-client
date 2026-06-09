var enrollCourse = new Course { Code = "CRS-101", Title = "C# Mastery", Capacity = 2 };
var enrollService = new EnrollmentService();
var enrollments = new List<EnrollmentRecord>();
var failures = new List<string>();
sw.Restart();
foreach (var student in students)
{
try
{
}
var record = enrollService.ProcessRegistration(student, enrollCourse);
enrollCourse.EnrolledCount++;
enrollments.Add(record);
Console.WriteLine($" Enrolled: {student.Name}");
catch (InvalidOperationException ex)
{
failures.Add($"{student.Name}: {ex.Message}");
Console.WriteLine($" Rejected: {student.Name} {ex.Message}");
}
}
async Task SendConfirmationAsync(Student student)
{
try
{
}
await Task.Delay(100); // Simulate sending email
Console.WriteLine($" Email sent to {student.Name}");
catch (Exception ex)
{
// Log the failure do NOT re-throw.
// This is intentional fire-and-forget.
Console.WriteLine($" Email failed for {student.Name}: {ex.Message}");
}
}