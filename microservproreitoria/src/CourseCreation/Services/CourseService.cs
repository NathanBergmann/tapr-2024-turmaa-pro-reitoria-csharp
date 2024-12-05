

using microservproreitoria.src.CourseCreation.Entities;
using Microsoft.EntityFrameworkCore;

namespace microservproreitoria.src.CourseCreation.Services;

public class CourseService : ICourseService
{
    private  RepositoryDbContext _repository;

    public CourseService(RepositoryDbContext repository)
    {
        this._repository = repository;
    }

    public async Task<Course> DeleteAsync(string id)
    {
         var courseOld = 
            await this._repository.Courses.Where(a => a.Id.Equals(id))
                .FirstOrDefaultAsync();
        if(courseOld != null)
        {
            this._repository.Remove(courseOld);
            await this._repository.SaveChangesAsync();
            return courseOld;
        }
        return null;
    }

    public async Task<List<Course>> GetAllAsync()
    {
        var cousesList = await this._repository.Courses.ToListAsync();
        return cousesList;
    }

    public async Task<Course> SaveAsync(Course course)
    {
        await this._repository.Courses.AddAsync(course);
        await this._repository.SaveChangesAsync();
        return course;
    }

    public async Task<Course> UpdateAsync(string id, Course course)
    {
          var coursesOld = 
            await this._repository.Courses.Where(a => a.Id.Equals(id))
                .FirstOrDefaultAsync();
        if(course != null)
        {
            coursesOld.Name = course.Name;
            await this._repository.SaveChangesAsync();
            return course;
        }
        return null;
    }
}