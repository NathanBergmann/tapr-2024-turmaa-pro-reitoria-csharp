using microservproreitoria.src.SubjectCreation.Entities;

namespace microservproreitoria.src.SubjectCreation.Services;

public interface ISubjectService
{
    Task<IEnumerable<Subject>> GetAllAsync();
    Task<Subject> SaveAsync(Subject subject);
    Task DeleteAsync(string id);
    Task<Subject> UpdateAsync(string id, Subject subject);
}
