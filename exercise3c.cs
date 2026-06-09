public interface IGradable
{
string Title { get; }
decimal CalculateGrade();
}
Step 2 —ImplementIt onTwoAssessment Types
Addboth classes to Models.cs:
public class Quiz : IGradable
{
public required string Title { get; init; }
public required int CorrectAnswers { get; init; }
public required int TotalQuestions { get; init; }
public decimal CalculateGrade()
{
if (TotalQuestions == 0) return 0m;
return (decimal)CorrectAnswers / TotalQuestions * 100m;
}
}
public class LabAssignment : IGradable
{
public required string Title { get; init; }
public required decimal FunctionalityScore { get; init; }
public required decimal CodeQualityScore { get; init; }
public decimal CalculateGrade()
{
// 70% functionality, 30% code quality
return (FunctionalityScore * 0.7m) + (CodeQualityScore * 0.3m);
}
}
void PrintGradeReport(IEnumerable<IGradable> assessments)
{
Console.WriteLine("--- Grade Report---");
foreach (var item in assessments)
{
Console.WriteLine($"{item.Title}: {item.CalculateGrade():F2}%");
}
}
// Test it — one array holds two completely different types
IGradable[] cohortAssessments = [
newQuiz { Title = "C# Basics", CorrectAnswers = 18, TotalQuestions = 20 },
newLabAssignment { Title = "Registration API", FunctionalityScore = 90m, CodeQualityScore =
85m}
];
PrintGradeReport(cohortAssessments);
Run it:
dotnet run
