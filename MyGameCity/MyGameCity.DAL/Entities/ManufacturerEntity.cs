namespace MyGameCity.DAL.Entities;

public record ManufacturerEntity : EntityBase
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string LogoImg { get; set; }
    public string CountryOfOrigin { get; set;} //TODO: replace with class not string
    public IEnumerable<ComodityEntity> ComodityList { get; set; }
}
