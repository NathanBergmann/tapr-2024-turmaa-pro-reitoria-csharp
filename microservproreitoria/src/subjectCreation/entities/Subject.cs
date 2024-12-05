using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace microservproreitoria.src.SubjectCreation.Entities
{
    public class Subject
    {
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public int Workload { get; set; }
    }
}