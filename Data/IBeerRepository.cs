using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAMVC.DTO;
using DAMVC.Models.DB;

namespace DAMVC.Data
{
    public interface IBeerRepository
    {
        IEnumerable<BeerDTO> List();
        Task<BeerDTO> Create(BeerDTO beer);
        Task<bool> Delete(int beerId);
        Task<BeerDTO> Update(BeerDTO beer);
    }
}
