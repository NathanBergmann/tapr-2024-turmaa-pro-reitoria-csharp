using microservproreitoria.src.SubjectCreation.Entities;
using Microsoft.EntityFrameworkCore;

namespace microservproreitoria.src.SubjectCreation.Services
{
    public class SubjectService : ISubjectService
    {
        private RepositoryDbContext _dbContext;
        public SubjectService(RepositoryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task DeleteAsync(string id)
        {
            var oldSubject = await _dbContext.Subjects.Where(s => s.Id.Equals(id)).FirstOrDefaultAsync();
            if (oldSubject != null)
            {
                _dbContext.Remove(oldSubject);
                await _dbContext.SaveChangesAsync();
                return;
            }
            return;
        }

        public async Task<IEnumerable<Subject>> GetAllAsync()
        {
            var subjectList = await _dbContext.Subjects.ToListAsync();
            return subjectList;
        }

        public async Task<Subject> SaveAsync(Subject subject)
        {
            await _dbContext.Subjects.AddAsync(subject);
            await _dbContext.SaveChangesAsync();
            return subject;
        }

        public async Task<Subject> UpdateAsync(string id, Subject subject)
        {
            var oldSubject = await _dbContext.Subjects.Where(s => s.Id.Equals(id)).FirstOrDefaultAsync();
            if (oldSubject != null)
            {
                oldSubject.Name = subject.Name;
                oldSubject.Workload = subject.Workload;
                await _dbContext.SaveChangesAsync();
                return subject;
            }
            return null;
        }
    }
}
