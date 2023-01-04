using VetClinic_backend.Models;

namespace VetClinic_backend.Interfaces
{
    public interface IVisitRepository
    {
        public IQueryable<Visit> GetAllVisits();
        public Task<Visit?> GetVisitById(int visitId);
        public Task<Visit?> AddVisit(Visit visit);
        public Task<Visit?> UpdateVisit(Visit visit);
    }
}
