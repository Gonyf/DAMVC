using System.Collections.Generic;
using System.Threading.Tasks;
using DAMVC.DTO;

namespace DAMVC.Data
{
    public interface IBeerRepository
    {
        IEnumerable<BeerDTO> List();
        Task<BeerDTO> Create(BeerDTO beer);
        void Delete(BeerDTO beer);
        void Update(BeerDTO beer);
		Task<BeerDTO> Get(int id);
    }
}
