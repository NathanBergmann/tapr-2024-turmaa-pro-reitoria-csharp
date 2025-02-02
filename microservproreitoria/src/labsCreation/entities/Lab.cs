using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using microservproreitoria.src.CourseCreation.Entities;
using microservproreitoria.src.labsCreation.entities;
using microservproreitoria.src.SubjectCreation.Entities;

namespace microservproreitoria.src.LabsCreation.Entities
{
    public class Lab
    {
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public Guid IdCourse { get; set; }
    public Course Course { get; set; }
    public LaboratoryType LaboratoryType { get; set; }
    public ICollection<Materials> Materials { get; set; } = new List<Materials>();
    }
}