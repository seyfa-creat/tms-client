namespace TmsApi.Entities;
public class Student
{
public int Id { get; set; }
// sur
rogate primary key — internal, used by foreign keys
public required string RegistrationNumber { get; set; } // na
tural key — human-readable (uniqueness configured in Session 2)
public required string Name { get; set; }
public decimal GPA { get; set; }
public bool IsActive { get; set; } = true;
// Navigation property for many-to-many relationship
public ICollection<Enrollment> Enrollments { get; set; } = ne
w List<Enrollment>();
}
namespace TmsApi.Entities;

public class Course
{
    public int Id { get; set; }
    y key — internal, used by foreign keys
// surrogate primar
public required string Code { get; set; } // natural key — hu
    man-readable(uniqueness configured in Session 2)
public required string Title { get; set; }
    public int Capacity { get; set; }
    // Navigation property for many-to-many relationship
    public ICollection<Enrollment> Enrollments { get; set; } = ne
w List<Enrollment>();
}
using System;
namespace TmsApi.Entities;

public class Enrollment
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public decimal? Grade { get; set; } // Nullable, as student m
    ay be currently enrolled
public DateTime EnrolledAt { get; set; } = DateTime.UtcNow;
    // Navigation properties back to entities
    public Student Student { get; set; } = null!;
    public Course Course { get; set; } = null!;
}
namespace TmsApi.Entities;

public class Assessment
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public decimal MaxScore { get; set; }
    public decimal Weight { get; set; } // share of the final gra
    de, e.g. 0.30m for 30%
// Foreign key + navigation to the owning course
public int CourseId { get; set; }
    public Course Course { get; set; } = null!;
}
using System;
namespace TmsApi.Entities;

public class Certificate
{
    // surrogate
    public int Id { get; set; }
    primary key
public required string SerialNumber { get; set; } // natural
    key — human-readable(uniqueness configured in Session 2)
public DateTime IssuedAt { get; set; } = DateTime.UtcNow;
    // Foreign keys + navigation to the student and course
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public Student Student { get; set; } = null!;
    public Course Course { get; set; } = null!;
}
