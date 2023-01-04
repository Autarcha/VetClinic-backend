using VetClinic_backend.Models;

namespace VetClinic_backend.Interfaces
{
    public interface IVisitDetailsRepository
    {
        public Task<VisitDetails?> AddVisitDetails(VisitDetails visitDetails);
        public Task<VisitDetails?> UpdateVisitDetails(VisitDetails visitDetails);
    }
}
