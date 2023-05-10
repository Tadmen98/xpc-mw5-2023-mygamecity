using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGameCity.DAL.QueryObjects.Filters
{
    public record CategoryNameFilter
    {
        public bool Filter { get; set; }
        public string Title { get; set; }
    }
}
