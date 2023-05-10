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
    public class GetReviewFilterQuery : IQuery<ReviewEntity, ReviewFilter>
    {
        private readonly DataContext _context;
        public GetReviewFilterQuery(DataContext context)
        {
            _context = context;
        }
        public IList<ReviewEntity> Execute(ReviewFilter filter)
        {
            return _context.Review.Where(s => s.Game.Title == filter.GameName).ToList();
        }
    }
}
