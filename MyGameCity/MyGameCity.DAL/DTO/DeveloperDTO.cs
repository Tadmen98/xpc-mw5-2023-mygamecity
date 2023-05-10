using MyGameCity.DAL.Entities;

namespace MyGameCity.DAL.DTO;

public record DeveloperDTO : EntityBase
{
    public DeveloperDTO()
    {

    }

    public DeveloperDTO(DeveloperEntity entity)
    {
        Id = entity.Id;
        Title = entity.Title;
        Description = entity.Description;
        LogoImg = entity.LogoImg;
        CountryOfOrigin = entity.CountryOfOrigin;
    }
    public string Title { get; set; }
    public string Description { get; set; }
    public string LogoImg { get; set; }
    public string CountryOfOrigin { get; set;} //TODO: replace with class not string
    //public List<GameEntity> GameList { get; set; }
}
