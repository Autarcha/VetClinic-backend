using Microsoft.EntityFrameworkCore;
using VetClinic_backend.Data;
using VetClinic_backend.Interfaces;
using VetClinic_backend.Models;

namespace VetClinic_backend.Repositories
{
    public class AnimalRepository: Repository<Animal>, IAnimalRepository
    {
        public AnimalRepository(RepositoryContext context) : base(context) { }

        public IQueryable<Animal>? GetAllAnimals()
        {
            var result = GetAll().Include(x => x.Owner).OrderBy(x => x.Id);
            return result;
        }

        public async Task<Animal?> GetAnimalsByOwnerId(int owner_id)
        {
            var result = await GetAll().FirstOrDefaultAsync(a => a.Owner.Id == owner_id);
            return result;
        }

        public async Task<Animal?> GetAnimalById(int animal_id)
        {
            var result = await GetAll().Include(x => x.Owner).FirstOrDefaultAsync(a => a.Id == animal_id);
            return result;
        }
        public async Task<Animal?> AddAnimal(Animal animal)
        {
            var newUser = await AddAsync(animal);
            await SaveChangesAsync();
            return newUser;
        }

        public async Task<Animal?> UpdateAnimal(Animal animal)
        {
            var updateUser = UpdateAsync(animal);
            await SaveChangesAsync();
            return updateUser.Result;
        }
    }
}
