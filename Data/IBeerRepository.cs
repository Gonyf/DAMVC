using System.Collections.Generic;
using System.Threading.Tasks;
using DAMVC.DTO;

namespace DAMVC.Data
{
    public interface IBeerRepository
    {
        BeerDTO Get(int id);
        IEnumerable<BeerDTO> List();
        Task<BeerDTO> Create(BeerDTO beer);
        void Delete(int beerId);
        void Update(BeerDTO beer);
    }
}
