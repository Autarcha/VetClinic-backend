using VetClinic_backend.Models;

namespace VetClinic_backend.Interfaces
{
    public interface IAnimalRepository
    {
        public IQueryable<Animal>? GetAllAnimals();
        public Task<Animal?> GetAnimalsByOwnerId(int owner_id);
        public Task<Animal?> GetAnimalById(int animalId);
        public Task<Animal?> AddAnimal(Animal animal);
        public Task<Animal?> UpdateAnimal(Animal animal);
    }
}
