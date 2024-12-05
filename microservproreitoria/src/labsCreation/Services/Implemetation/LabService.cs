using microservproreitoria.src.LabsCreation.Entities;
using Microsoft.EntityFrameworkCore;

namespace microservproreitoria.src.labsCreation.Services.Implemetation
{
    public class LabService : ILabService
    {
        private readonly RepositoryDbContext _context;

        public LabService(RepositoryDbContext context)
        {
            _context = context;
        }

        public async Task<List<Lab>> GetAllAsync()
        {
            return await _context.Labs.ToListAsync();
        }

        public async Task<Lab> GetByIdAsync(Guid id)
        {
            return await _context.Labs.FindAsync(id);
        }

        public async Task<Lab> SaveAsync(Lab lab)
        {
            await _context.Labs.AddAsync(lab);
            await _context.SaveChangesAsync();
            return lab;
        }

        public async Task<Lab> UpdateAsync(Guid id, Lab lab)
        {
            var existingLab = await _context.Labs.FindAsync(id);
            if (existingLab == null)
                return null;

            existingLab.Name = lab.Name;
            existingLab.IdCourse = lab.IdCourse;
            existingLab.Materials = lab.Materials;

            _context.Labs.Update(existingLab);
            await _context.SaveChangesAsync();
            return existingLab;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var lab = await _context.Labs.FindAsync(id);
            if (lab == null)
                return false;

            _context.Labs.Remove(lab);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
