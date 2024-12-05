
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using microservproreitoria.src.CourseCreation.Entities;

namespace microservproreitoria.src.CourseCreation.Services;

public interface ICourseService
{
    Task<List<Course>> GetAllAsync();
    Task<Course> SaveAsync(Course course);
    Task<Course> UpdateAsync(String id, Course course);
    Task<Course> DeleteAsync(String id);
}
