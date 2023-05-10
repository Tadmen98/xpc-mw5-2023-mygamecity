using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGameCity.DAL.QueryObjects.Filters
{
    public record PriceFilter
    {
        public int PriceMin { get; set; }
        public int PriceMax { get; set; }
        public bool Filter { get; set; }
    }
}
