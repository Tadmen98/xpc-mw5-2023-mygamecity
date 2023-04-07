using System.Text.Json;

namespace MyGameCity.DataModel
{
    public class Review
    {
        public int Stars { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
        }
    }
}
