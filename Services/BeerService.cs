using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAMVC.DTO;
using DAMVC.Interfaces;

namespace DAMVC.Services
{
    public class BeerService : IBeerService
    {
        private readonly IBeerRepository _repo;
        private readonly ICurrentUserResolver _currentUserResolver;

        public BeerService(IBeerRepository repo, ICurrentUserResolver currentUserResolver)
        {
            _repo = repo;
            _currentUserResolver = currentUserResolver;
        }

        public IEnumerable<Beer> List()
        {
            return _repo.List();
        }

        public Task<Beer> Create(Beer beer)
        {
            beer.SubmittedByUser = _currentUserResolver.Get().Id;
            return _repo.Create(beer);
        }

        public void Delete(Beer beer)
        {
            _repo.Delete(beer);
        }

        public void Update(Beer beer)
        {
            _repo.Update(beer);
        }

        public Task<Beer> Get(int id)
        {
            return _repo.Get(id);
        }
    }
}
