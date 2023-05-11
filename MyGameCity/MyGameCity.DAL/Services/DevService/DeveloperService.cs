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
        public DeveloperEntity AddDeveloper(DeveloperDTO developer_dto)
        {
            //List<GameEntity> games = _context.Game.Where(c => developer_dto.GameIds.Contains(c.Id)).ToList();
            var developer_check = _context.Review.Where(c => c.Id == developer_dto.Id).FirstOrDefault();
            if (developer_check != null)
            {
                throw new AlreadyExistException($"Developer {developer_dto.Id} already exists");
            }

            var developer = new DeveloperEntity(developer_dto) {};
            _context.Developer.Add(developer);
            _context.SaveChanges();
            return developer;
        }

        public DeveloperEntity DeleteDeveloper(Guid id)
        {
            var developer = _context.Developer.Find(id);
            if (developer is null)
            {
                throw new NotFoundException($"Developer {id} was not found");
            }

            _context.Developer.Remove(developer);
            _context.SaveChanges();
            return developer;
        }

        public List<DeveloperEntity> GetAllDevelopers()
        {
            var developers = _context.Developer.ToList();
            return developers;
        }

        public DeveloperEntity GetDeveloperById(Guid id)
        {
            var developer = _context.Developer.Where(c => c.Id == id).FirstOrDefault();
            if (developer is null)
            {
                throw new NotFoundException($"Developer {id} was not found");
            }
            return developer;
        }

        public DeveloperEntity UpdateDeveloper(DeveloperDTO developer_dto)
        {
            var developer = _context.Developer.Find(developer_dto.Id);
            if (developer == null)
            {
                throw new NotFoundException($"Developer {developer_dto.Id} was not found");
            }
            developer.Title = developer_dto.Title;
            developer.Description = developer_dto.Description;
            developer.LogoImg = developer_dto.LogoImg;
            developer.CountryOfOrigin = developer_dto.CountryOfOrigin;

            _context.SaveChanges();
            return developer;
        }
    }
}
