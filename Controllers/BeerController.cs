using System.Threading.Tasks;
using DAMVC.Data;
using DAMVC.DTO;
using Microsoft.AspNetCore.Mvc;

namespace DAMVC.Controllers
{
    [Route("[controller]")]
    public class BeerController : Controller
    {
        private readonly IBeerRepository _repo;
        public BeerController(IBeerRepository repository)
        {
            _repo = repository;
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            var beers = _repo.List();
            return View(beers);
        }

        [HttpGet("Edit")]
        public async Task<IActionResult> Edit(int id)
        {
			var beer = await _repo.Get(id);
            return View(beer);
        }        
  
		[HttpPost("Edit")]
        public IActionResult Edit(BeerDTO beer)
        {
			_repo.Update(beer);
            return RedirectToActionPermanent(nameof(Details), beer);
        }
        
        [HttpGet("Details")]
        public async Task<IActionResult> Details(int id)
        {
			var beer = await _repo.Get(id);
            return View(beer);
        }
        
        [HttpGet("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
			var beer = await _repo.Get(id);
            return View(beer);
        }

		[HttpPost("Delete")]
		public IActionResult Delete(BeerDTO beerDTO)
        {
			_repo.Delete(beerDTO);
			return RedirectToActionPermanent(nameof(Index));
        }
        
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(BeerDTO beer)
        {
            await _repo.Create(beer);
            return RedirectToActionPermanent(nameof(Details), new { beer.Id });
        }
    }
}
