using Microsoft.EntityFrameworkCore;
using VetClinic_backend.Data;
using VetClinic_backend.Interfaces;
using VetClinic_backend.Models;

namespace VetClinic_backend.Repositories
{
    public class VisitRepository : Repository<Visit>, IVisitRepository
    {

        public VisitRepository(RepositoryContext context) : base(context) { }

        public IQueryable<Visit>? GetAllVisits()
        {
            var result = GetAll().Include(x => x.Customer).Include(x => x.Employee).Include(x => x.VisitDetails).OrderBy(x => x.Id);
            return result;
        }

        public async Task<Visit?> GetVisitById(int visitId)
        {
            var result = await GetAll().FirstOrDefaultAsync(v => v.Id == visitId);
            return result;
        }

        public async Task<Visit?> AddVisit(Visit visit)
        {
            var newVisit = await AddAsync(visit);
            await SaveChangesAsync();
            return newVisit;
        }

        public async Task<Visit?> UpdateVisit(Visit visit)
        {
            var updateVisit = UpdateAsync(visit);
            await SaveChangesAsync();
            return updateVisit.Result;
        }


    }
}
