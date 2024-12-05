using microservproreitoria.src.SubjectCreation.Entities;

namespace microservproreitoria.src.SubjectCreation.Services;

public interface ISubjectService
{
    Task<IEnumerable<Subject>> GetAllAsync();
    Task<Subject> SaveAsync(Subject subject);
    Task DeleteAsync(Subject subject);
    Task<Subject> GetByIdAsync(Guid id);
    Task<Subject> UpdateAsync(Subject subject);
}
