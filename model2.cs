In Program.cs, add:
// C# 12+ Collection Expressions the modern way to initialize lists
List<Student> students = [
newStudent { Id = "S1", Name= "Abeba", Age = 22, GPA= 3.8m },
newStudent { Id = "S2", Name= "Kidane", Age = 21, GPA = 2.4m},
newStudent { Id = "S3", Name= "Dawit", Age = 20, GPA= 3.1m },
newStudent { Id = "S4", Name= "Sara", Age = 23, GPA = 3.9m },
newStudent { Id = "S5", Name= "Frehiwot", Age = 19, GPA = 2.0m},
newStudent { Id = "S6", Name= "Yonas", Age = 24, GPA= 3.5m },
newStudent { Id = "S7", Name= "Meron", Age = 22, GPA =1.8m},
newStudent { Id = "S8", Name= "Tesfaye", Age = 21, GPA = 2.9m}
];
var leaderboard = students
// TODO1:Extract students where GPA is >= 3.5m
// TODO2:Sort the remaining students by GPA descending
// TODO3:Project the result so we only keep the 'Name' string
// TODO4:Materialize the lazy query into a concrete List
;
Console.WriteLine($"Found {leaderboard.Count} Honors Students:");
foreach (var name in leaderboard)
{
Console.WriteLine($"- {name}");
}
// TODO5:UseLINQto calculate the average GPA across all students.
//
Format it to 2 decimal places using :F2.
decimal averageGpa = ____
// Stuck? Pattern: students.Average(s => s.SomeProperty)
Console.WriteLine($"\nClass Average GPA: {averageGpa:F2}");
// TODO6:Use.GroupBy with a switch expression to classify each student.
//
GPA>=3.5 →"Honors", >= 2.5 →"GoodStanding",
//
>= 2.0 →"Probation", < 2.0 → "Academic Warning"
var standingGroups = _____
// Stuck? Pattern: .GroupBy(s => s.GPA switch { >= X => "Label", ... })
Console.WriteLine("\n--- Academic Standing Report---");
foreach (var group in standingGroups)
{
Console.WriteLine($"\n{group.Key} ({group.Count()}):");
foreach (var s in group)
{
Console.WriteLine($" {s.Name} GPA: {s.GPA}");
}
}
// TODO7:Usethespread operator (..) to merge two arrays and append a value.
// Stuck? Pattern: string[] combined = [..array1, ..array2, "extra"];
string[] backendCourses = ["C#", "ASP.NET Core"];
string[] frontendCourses = ["TypeScript", "Angular"];
string[] allCourses = ___ // TODO
Console.WriteLine($"\nFull curriculum: {string.Join(", ", allCourses)}");
