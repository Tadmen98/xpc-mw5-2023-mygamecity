using MyGameCity.DAL.Data;
using MyGameCity.DAL.Entities;

namespace MyGameCity.DAL.Repositories
{
    internal class GameRepository : IRepository<ComodityEntity>
    {
        GamesDbContext context = new();
        public Guid Create(ComodityEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            
            // TODO: add to the database
            
            return entity.Id;
        }

        public ComodityEntity GetById(Guid id)
        {
            // TODO: get from the database
            var entity = new ComodityEntity() {Name=""};
            return entity;
        }

        public ComodityEntity Update(ComodityEntity? entity)
        {
            if (entity == null) throw new ArgumentNullException();
            // TODO: update function
            return entity;
        }

        public void DeleteById(Guid id)
        {
            //TODO: 
            ;
        }
    }
}
