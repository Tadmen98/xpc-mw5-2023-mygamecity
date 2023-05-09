using MyGameCity.DAL.Entities;

namespace MyGameCity.DAL.DTO;

public record DeveloperEntity : EntityBase
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string LogoImg { get; set; }
    public string CountryOfOrigin { get; set;} //TODO: replace with class not string
    //public List<GameEntity> GameList { get; set; }
}
