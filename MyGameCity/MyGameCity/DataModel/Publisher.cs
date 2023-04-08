using System.Text.Json;

namespace MyGameCity.DataModel
{
    public class Publisher
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? CountryOfOrigin { get; set; }
        //public  List<Games> ListOfGames { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
        }
    }
}
