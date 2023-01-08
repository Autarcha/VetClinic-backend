using Microsoft.EntityFrameworkCore;
using VetClinic_backend.Data;
using VetClinic_backend.Interfaces;
using VetClinic_backend.Models;

namespace VetClinic_backend.Repositories
{
    public class AnimalRepository: Repository<Animal>, IAnimalRepository
    {
        public AnimalRepository(RepositoryContext context) : base(context) { }

        public IQueryable<Animal> GetAllAnimals()
        {
            var result = GetAll().Include(a => a.Owner).OrderBy(a => a.Id);
            return result;
        }

        public async Task<Animal?> GetAnimalsByOwnerId(int owner_id)
        {
            var result = await GetAllAnimals().FirstOrDefaultAsync(a => a.Owner.Id == owner_id);
            return result;
        }

        public async Task<Animal?> GetAnimalById(int animal_id)
        {
            var result = await GetAllAnimals().Include(a => a.Owner).FirstOrDefaultAsync(a => a.Id == animal_id);
            return result;
        }
        public async Task<Animal?> AddAnimal(Animal animal)
        {
            var newAnimal = await AddAsync(animal);
            await SaveChangesAsync();
            return newAnimal;
        }

        public async Task<Animal?> UpdateAnimal(Animal animal)
        {
            var updateAnimal = UpdateAsync(animal);
            await SaveChangesAsync();
            return updateAnimal.Result;
        }
    }
}
