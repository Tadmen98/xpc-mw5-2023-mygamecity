using Microsoft.EntityFrameworkCore;
using MyGameCity.DAL.Data;
using MyGameCity.DAL.Entities;
using MyGameCity.DAL.QueryObjects.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGameCity.DAL.QueryObjects
{
    public class GetDeveloperFilterQuery : IQuery<DeveloperEntity, DeveloperFilter>
    {
        private readonly DataContext _context;
        public GetDeveloperFilterQuery(DataContext context)
        {
            _context = context;
        }
        public IList<DeveloperEntity> Execute(DeveloperFilter filter)
        {
            return _context.Developer.Where(s => s.CountryOfOrigin == filter.CountryOfOrigin).ToList(); 
        }
    }
}
