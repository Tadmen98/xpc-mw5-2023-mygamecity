using Microsoft.EntityFrameworkCore;
using MyGameCity.DAL.Data;
using MyGameCity.DAL.DTO;
using MyGameCity.DAL.Entities;
using MyGameCity.DAL.Exceptions;
//using MyGameCity.DataModel;

namespace MyGameCity.DAL.Services.DevService
{
    public class DeveloperService : IDeveloperService
    {
        private readonly DataContext _context;

        public DeveloperService(DataContext context)
        {
            _context = context;
        }
        public async Task<DeveloperEntity> AddDeveloper(DeveloperDTO developer_dto)
        {
            //List<GameEntity> games = _context.Game.Where(c => developer_dto.GameIds.Contains(c.Id)).ToList();
            var developer_check = await _context.Developer.Where(c => c.Id == developer_dto.Id).FirstOrDefaultAsync();
            if (developer_check != null)
            {
                throw new AlreadyExistException($"Developer {developer_dto.Id} already exists");
            }

            var developer = new DeveloperEntity(developer_dto) {};
            await _context.Developer.AddAsync(developer);
            await _context.SaveChangesAsync();
            return developer;
        }

        public async Task<DeveloperEntity> DeleteDeveloper(Guid id)
        {
            var developer = await _context.Developer.FindAsync(id);
            if (developer is null)
            {
                throw new NotFoundException($"Developer {id} was not found");
            }

            _context.Developer.Remove(developer);
            await _context.SaveChangesAsync();
            return developer;
        }

        public async Task<List<DeveloperEntity>> GetAllDevelopers()
        {
            var developers = await _context.Developer.ToListAsync();
            return developers;
        }

        public async Task<DeveloperEntity> GetDeveloperById(Guid id)
        {
            var developer = await _context.Developer.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (developer is null)
            {
                throw new NotFoundException($"Developer {id} was not found");
            }
            return developer;
        }

        public async Task<DeveloperEntity> UpdateDeveloper(DeveloperDTO developer_dto)
        {
            var developer = await _context.Developer.FindAsync(developer_dto.Id);
            if (developer == null)
            {
                throw new NotFoundException($"Developer {developer_dto.Id} was not found");
            }
            developer.Title = developer_dto.Title;
            developer.Description = developer_dto.Description;
            developer.LogoImg = developer_dto.LogoImg;
            developer.CountryOfOrigin = developer_dto.CountryOfOrigin;

            await _context.SaveChangesAsync();
            return developer;
        }
    }
}
