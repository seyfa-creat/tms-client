// Legacy implementation — the bug that caused the audit failure
double grantPerStudent = 1999.99;
double totalAllocation = grantPerStudent * 100_000;
Console.WriteLine($"Total allocated (double): {totalAllocation}");
Run it:
dotnet run
// Fixed implementation — exact financial math
decimal grantPerStudent = 1999.99m;
decimal totalAllocation = grantPerStudent * 100_000m;
Console.WriteLine($"Total allocated (decimal): {totalAllocation}");
Console.WriteLine($"Total allocated (formatted): {totalAllocation:F2}");
Run it:
dotnet run
