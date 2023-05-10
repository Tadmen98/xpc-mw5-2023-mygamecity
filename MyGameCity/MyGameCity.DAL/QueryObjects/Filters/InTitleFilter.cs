using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGameCity.DAL.QueryObjects.Filters
{
    public record InTitleFilter
    {
        public bool Filter { get; set; }
        public string SearchString { get; set; }
    }
}
