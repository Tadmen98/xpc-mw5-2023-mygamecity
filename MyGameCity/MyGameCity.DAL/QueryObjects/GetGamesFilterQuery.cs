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
    public class GetGamesFilterQuery : IQuery<GameEntity, GameFilter>
    {
        private readonly DataContext _context;
        public GetGamesFilterQuery(DataContext context)
        {
            _context = context;
        }

        public async Task<IList<GameEntity>> Execute(GameFilter filters)
        {
            IQueryable<GameEntity> query = _context.Game;

            if (filters.PriceFilter.Filter)
            {
                query = query.Where(s => s.Price >= filters.PriceFilter.PriceMin && s.Price <= filters.PriceFilter.PriceMax);
            }

            if (filters.StockFilter.Filter)
            {
                query = query.Where(s => s.NumberInStock >= filters.StockFilter.InStockMin && s.NumberInStock <= filters.StockFilter.InStockMax);
            }

            if (filters.InTitleFilter.Filter)
            {
                query = query.Where(s => s.Title.Contains(filters.InTitleFilter.SearchString));
            }

            if (filters.CategoryNameFilter.Filter)
            {
                query = query.Where(g => g.Category.Any(c => c.Name == filters.CategoryNameFilter.Title));
            }

            return await query.ToListAsync();
        }
    }
}
