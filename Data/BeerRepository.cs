using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAMVC.DTO;
using DAMVC.Mappers;
using Microsoft.EntityFrameworkCore;

namespace DAMVC.Data
{
    public class BeerRepository : IBeerRepository
    {
        private readonly DataContext _context;

        public BeerRepository(DataContext Context)
        {
            _context = Context;
        }

        public IEnumerable<BeerDTO> List()
        {
            var beerList = new List<BeerDTO>();
            _context.Beers.ToList().ForEach(b => beerList.Add(BeerMapper.ToBeerDTO(b)));
            return beerList;
        }

        public async Task<BeerDTO> Create(BeerDTO beer)
        {
            _context.Beers.Add(BeerMapper.ToDBBeer(beer));
            await _context.SaveChangesAsync();
            return beer;
        }

        public async void Delete(BeerDTO beer)
        {
			_context.Beers.Remove(BeerMapper.ToDBBeer(beer));
			await _context.SaveChangesAsync();
        }

        public async void Update(BeerDTO beer)
        {
			_context.Beers.Update(BeerMapper.ToDBBeer(beer));

			await _context.SaveChangesAsync();
        }

		public async Task<BeerDTO> Get(int id)
		{
			var beer = await _context.Beers.FirstOrDefaultAsync(x => x.Id == id);
			var beerDTO = BeerMapper.ToBeerDTO(beer);
			return beerDTO;
		}
	}
}
