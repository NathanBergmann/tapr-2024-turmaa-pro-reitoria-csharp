using microservproreitoria.src.TeacherApplication.Entities;

namespace microservproreitoria.src.TeacherApplication.Services
{
    public interface ITeacherService
    {
        Task<List<Teacher>> GetAllAsync();
        Task<Teacher> GetByIdAsync(Guid id);
        Task<Teacher> SaveAsync(Teacher teacher);
        Task<Teacher> UpdateAsync(Guid id, Teacher teacher);
        Task<bool> DeleteAsync(Guid id);
    }
}
