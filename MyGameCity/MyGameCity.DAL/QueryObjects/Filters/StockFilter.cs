using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGameCity.DAL.QueryObjects.Filters
{
    public record StockFilter
    {
        public bool Filter { get; set; }
        public int InStockMin { get; set; }
        public int InStockMax { get; set; }
    }
}
