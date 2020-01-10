using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAMVC.DTO;
using DAMVC.Models.DB;

namespace DAMVC.Mappers
{
    public static class BeerMapper
    {
        public static BeerDTO ToBeerDTO(Beer beerDB)
        {
            var beerDTO = new BeerDTO
            {
                Id = beerDB.Id,
                Name = beerDB.Name,
                Brewery = beerDB.Brewery,
                Country = beerDB.Country,
                AlcPercent = beerDB.AlcPercent,
                PerceivedBitterness = beerDB.PerceivedBitterness,
                PerceivedSweetness = beerDB.PerceivedSweetness,
                PerceivedFruitiness = beerDB.PerceivedFruitiness,
                ActualIBU = beerDB.ActualIBU,
                DrinkingTime = beerDB.DrinkingTime,
                SubmittedByUser = beerDB.SubmittedByUser
            };

            return beerDTO;
        }

        public static Beer ToDBBeer(BeerDTO beerDTO)
        {
            var beer = new Beer
            {
                Id = beerDTO.Id,
                Name = beerDTO.Name,
                Brewery = beerDTO.Brewery,
                Country = beerDTO.Country,
                AlcPercent = beerDTO.AlcPercent,
                PerceivedBitterness = beerDTO.PerceivedBitterness,
                PerceivedSweetness = beerDTO.PerceivedSweetness,
                PerceivedFruitiness = beerDTO.PerceivedFruitiness,
                ActualIBU = beerDTO.ActualIBU,
                DrinkingTime = beerDTO.DrinkingTime,
                SubmittedByUser = beerDTO.SubmittedByUser
            };

            return beer;
        }
    }
}
