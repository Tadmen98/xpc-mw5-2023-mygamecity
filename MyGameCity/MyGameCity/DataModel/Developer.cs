using System.Text.Json;

namespace MyGameCity.DataModel
{
    public class Developer
    {
        public string Title { get; set; }   
        public string? Description { get; set; }
        public string? CountryOfOrigin { get; set; }
        public  Dictionary<Developer,List<Games>> ListOfGames { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
        }
    }
}
