using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace microservproreitoria.src.TeacherApplication.Entities
{
    public class Teacher
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        private string Name { get; set; }
    }
}