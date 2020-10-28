using DAMVC.DTO;
using DAMVC.Models.DB;
using Beer = DAMVC.DTO.Beer;

namespace DAMVC.Mappers
{
    public static class BeerMapper
    {
        public static Beer ToBeer(Models.DB.Beer beerDB)
        {
            var beerDTO = new Beer
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

        public static Models.DB.Beer ToDBBeer(Beer beer)
        {
            var dbBeer = new Models.DB.Beer
            {
                Id = beer.Id,
                Name = beer.Name,
                Brewery = beer.Brewery,
                Country = beer.Country,
                AlcPercent = beer.AlcPercent,
                PerceivedBitterness = beer.PerceivedBitterness,
                PerceivedSweetness = beer.PerceivedSweetness,
                PerceivedFruitiness = beer.PerceivedFruitiness,
                ActualIBU = beer.ActualIBU,
                DrinkingTime = beer.DrinkingTime,
                SubmittedByUser = beer.SubmittedByUser
            };

            return dbBeer;
        }
    }
}
