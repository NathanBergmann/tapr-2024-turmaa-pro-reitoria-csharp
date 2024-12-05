using microservproreitoria.src.TeacherApplication.Entities;
using Microsoft.EntityFrameworkCore;

namespace microservproreitoria.src.TeacherApplication.Services.Implemetation
{
    public class TeacherService : ITeacherService
    {
        private readonly RepositoryDbContext _context;

        public TeacherService(RepositoryDbContext context)
        {
            _context = context;
        }

        public async Task<List<Teacher>> GetAllAsync()
        {
            return await _context.Teachers.ToListAsync();
        }

        public async Task<Teacher> GetByIdAsync(Guid id)
        {
            return await _context.Teachers.FindAsync(id);
        }

        public async Task<Teacher> SaveAsync(Teacher teacher)
        {
            await _context.Teachers.AddAsync(teacher);
            await _context.SaveChangesAsync();
            return teacher;
        }

        public async Task<Teacher> UpdateAsync(Guid id, Teacher teacher)
        {
            var existingTeacher = await _context.Teachers.FindAsync(id);
            if (existingTeacher == null)
                return null;

            existingTeacher.Name = teacher.Name;

            _context.Teachers.Update(existingTeacher);
            await _context.SaveChangesAsync();
            return existingTeacher;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
                return false;

            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
