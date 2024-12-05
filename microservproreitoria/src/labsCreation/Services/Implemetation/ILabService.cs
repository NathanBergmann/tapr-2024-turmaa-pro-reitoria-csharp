using microservproreitoria.src.LabsCreation.Entities;

namespace microservproreitoria.src.labsCreation.Services
{
    public interface ILabService
    {
        Task<List<Lab>> GetAllAsync();
        Task<Lab> GetByIdAsync(Guid id);
        Task<Lab> SaveAsync(Lab lab);
        Task<Lab> UpdateAsync(Guid id, Lab lab);
        Task<bool> DeleteAsync(Guid id);
    }
}
