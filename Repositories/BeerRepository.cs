using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAMVC.Data;
using DAMVC.DTO;
using DAMVC.Interfaces;
using DAMVC.Mappers;
using Microsoft.EntityFrameworkCore;

namespace DAMVC.Repositories
{
    public class BeerRepository : IBeerRepository
    {
        private readonly DataContext _context;

        public BeerRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Beer> List()
        {
            var beerList = new List<Beer>();
            _context.Beers.ToList().ForEach(b => beerList.Add(BeerMapper.ToBeer(b)));
            return beerList;
        }

        public async Task<Beer> Create(Beer beer)
        {
            beer.DrinkingTime = DateTime.Now;
            _context.Beers.Add(BeerMapper.ToDBBeer(beer));
            await _context.SaveChangesAsync();
            return beer;
        }

        public async void Delete(Beer beer)
        {
			_context.Beers.Remove(BeerMapper.ToDBBeer(beer));
			await _context.SaveChangesAsync();
        }

        public async void Update(Beer beer)
        {
			_context.Beers.Update(BeerMapper.ToDBBeer(beer));
			await _context.SaveChangesAsync();
        }

		public async Task<Beer> Get(int id)
		{
			var beer = await _context.Beers.FirstOrDefaultAsync(x => x.Id == id);
			var beerDTO = BeerMapper.ToBeer(beer);
			return beerDTO;
		}
	}
}
