public class Enrollment
{
}
public string StudentId { get; set; } = string.Empty;
public string CourseCode { get; set; } = string.Empty;
public DateTime ProcessedAt { get; set; }
// Somewhere in the logging pipeline:
// enrollment.CourseCode = null; // ← No compiler error. Data silently corrupted
// Immutable by design — the logging pipeline cannot corrupt this
public record EnrollmentRecord(string StudentId, string CourseCode, DateTime EnrolledAt);
One line. The primary constructor parameters become init-only properties automatically.
Noonecanwrite enrollment.CourseCode = null after construction — the compiler
prevents it.
Test it in Program.cs:
var enrollment = new EnrollmentRecord("STU-001", "CS-401", DateTime.UtcNow);
Console.WriteLine(enrollment);
// Try to mutate it — uncomment this line and see the compiler error:
// enrollment.CourseCode = "HACKED"; // ERROR: init-only property
// Non-destructive copy — creates a NEW record with one field changed
var corrected = enrollment with { CourseCode = "CS-402" };
Console.WriteLine(corrected);
// Value equality — two records with the same data are equal
var duplicate = new EnrollmentRecord("STU-001", "CS-401", enrollment.EnrolledAt);
Console.WriteLine($"Same data? {enrollment == duplicate}"); // True
Run it:
dotnet run
