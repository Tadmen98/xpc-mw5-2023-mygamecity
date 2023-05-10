using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGameCity.DAL.QueryObjects.Filters
{
    public record GameFilter
    {
        public CategoryNameFilter CategoryNameFilter { get; set; }
        public DeveloperNameFilter DeveloperNameFilter { get; set; }
        public InTitleFilter InTitleFilter { get; set; }
        public PriceFilter PriceFilter { get; set; }
        public StockFilter StockFilter { get; set; }
    }

    

    
}
