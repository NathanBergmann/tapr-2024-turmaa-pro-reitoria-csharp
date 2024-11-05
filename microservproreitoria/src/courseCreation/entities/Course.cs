using System;
using System.Collections.Generic;
using microservproreitoria.src.subjectCreation.entities;

public class Course
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string name { get; set; } = string.Empty;
    public int SemesterQtd { get; set; }
    public CourseStatus Status { get; set; }
    public GraduateType graduateType { get; set; }
    public ICollection<Subject> Materials { get; set; } = new List<Subject>();
}
