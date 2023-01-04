using VetClinic_backend.Data;
using VetClinic_backend.Interfaces;
using VetClinic_backend.Models;

namespace VetClinic_backend.Repositories
{
    public class VisitDetailsRepository : Repository<VisitDetails>, IVisitDetailsRepository
    {

        public VisitDetailsRepository(RepositoryContext context) : base(context) { }

        public async Task<VisitDetails?> GetVisitDetailsByVisitId(int visitId)
        {
            throw new NotImplementedException();
        }
        public async Task<VisitDetails?> AddVisitDetails(VisitDetails visitDetails)
        {
            var newVisitDetails = await AddAsync(visitDetails);
            await SaveChangesAsync();
            return newVisitDetails;
        }

        public async Task<VisitDetails?> UpdateVisitDetails(VisitDetails visitDetails)
        {
            var updateVisitDetails = UpdateAsync(visitDetails);
            await SaveChangesAsync();
            return updateVisitDetails.Result;
        }
    }
}
