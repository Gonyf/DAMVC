using System.Collections.Generic;
using System.Threading.Tasks;
using DAMVC.DTO;

namespace DAMVC.Interfaces
{
    public interface IBeerRepository
    {
        IEnumerable<Beer> List();
        Task<Beer> Create(Beer beer);
        void Delete(Beer beer);
        void Update(Beer beer);
		Task<Beer> Get(int id);
    }
}
