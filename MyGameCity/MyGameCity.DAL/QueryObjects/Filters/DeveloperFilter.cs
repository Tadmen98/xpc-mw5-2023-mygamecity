using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGameCity.DAL.QueryObjects.Filters
{
    public record DeveloperFilter
    {
        public string CountryOfOrigin { get; set; }
        public bool Filter { get; set; }
    }
}
