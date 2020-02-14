using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAMVC.DTO;
using DAMVC.Mappers;
using DAMVC.Models.DB;

namespace DAMVC.Data
{
    public class BeerRepository : IBeerRepository
    {
        private readonly DataContext _context;

        public BeerRepository(DataContext context)
        {
            _context = context;
        }

        public BeerDTO Get(int id)
        {
            return BeerMapper.ToBeerDTO(_context.Beers.FirstOrDefault(b => b.Id == id));
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

        public async void Delete(int beerId)
        {
            var toRemove = new Beer {Id = beerId};
            _context.Beers.Attach(toRemove);
            _context.Beers.Remove(toRemove);
            await _context.SaveChangesAsync();
        }

        public async void Update(BeerDTO beer)
        {
            var entity = _context.Beers.FirstOrDefault(b => b.Id == beer.Id);
            if (entity == null)
                throw new NullReferenceException($"beer with id {beer.Id} could not be found");
                
            UpdateBeerEntityFields(beer, entity);
            _context.Beers.Update(entity);
            await _context.SaveChangesAsync();
        }

        private void UpdateBeerEntityFields(BeerDTO beerDTO, Beer entity)
        {
            entity.ActualIBU = beerDTO.ActualIBU;
            entity.AlcPercent = beerDTO.AlcPercent;
            entity.Brewery = beerDTO.Brewery;
            entity.Country = beerDTO.Country;
            entity.DrinkingTime = beerDTO.DrinkingTime;
            entity.Name = beerDTO.Name;
            entity.PerceivedBitterness = beerDTO.PerceivedBitterness;
            entity.PerceivedFruitiness = beerDTO.PerceivedFruitiness;
            entity.PerceivedSweetness = beerDTO.PerceivedSweetness;
        }
    }
}
