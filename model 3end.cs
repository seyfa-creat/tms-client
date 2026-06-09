// Stop the timer
sw.Stop();
// Calculate class average GPA from loaded students
decimal classAverage = students.Length > 0
? students.Average(s => s.GPA)
: 0m;
// Print the final report
Console.WriteLine("\n========== ENROLLMENT SUMMARY ==========");
Console.WriteLine($"Total students loaded:
{students.Length}");
Console.WriteLine($"Successful enrollments: {enrollments.Count}");
Console.WriteLine($"Failed enrollments:
{failures.Count}");
Console.WriteLine($"Class average GPA:
Console.WriteLine($"Total elapsed time:
if (failures.Count > 0)
{
{classAverage:F2}");
{sw.ElapsedMilliseconds}ms");
Console.WriteLine("\n--- Failure Details---");
foreach (var failure in failures)
{
Console.WriteLine($" {failure}");
}
}
Console.WriteLine("========================================");
// TODO1:Define a delegate that accepts a Student object (or use Action<Student>)
public class EnrollmentService
{
// TODO2:Create aproperty that holds the delegate 'listener'
public void FinalizeEnrollment(Student s)
{
Console.WriteLine("Persisting to database...");
// TODO3:Check if the delegate listener is 'not null'
//
and invoke it with the student object.
}
}
// TODO4:In Program.cs, create a lambda function that prints:
//
"SMS SENT: Welcome tothe TMS, [StudentName]!"
// TODO5:Attach that lambda to the EnrollmentService and call FinalizeEnrollment.
