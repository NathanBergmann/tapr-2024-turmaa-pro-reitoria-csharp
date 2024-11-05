using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using microservproreitoria.src.subjectCreation.entities;

namespace microservproreitoria.src.labsCreation.entities
{
    public class Lab
    {
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public Guid IdCourse { get; set; }
    public Course Course { get; set; }
    public LaboratoryType LaboratoryType { get; set; }
    public ICollection<Subject> Materials { get; set; } = new List<Subject>();
    }
}