using System.Text.Json;

namespace MyGameCity.DataModel
{
    //todo-cleancode Game or Games?
    public class Games
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Ammount { get; set; }
        public string Category { get; set; }
        public Publisher Publisher { get; set; }
        public Developer Developer { get; set; }   
        public Review Review { get; set; }

        // todo-maintability why is this here? 
        public override string ToString()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = false });
        }
    }  
}
