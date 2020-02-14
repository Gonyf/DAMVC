using System.Threading.Tasks;
using DAMVC.DTO;
using DAMVC.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DAMVC.Controllers
{
    [Route("[controller]")]
    public class BeerController : Controller
    {
        private readonly IBeerService _service;
        public BeerController(IBeerService service)
        {
            _service = service;
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            var beers = _service.List();
            return View(beers);
        }

        [HttpGet("Edit")]
        public async Task<IActionResult> Edit(int id)
        {
			var beer = await _service.Get(id);
            return View(beer);
        }        
  
		[HttpPost("Edit")]
        public IActionResult Edit(Beer beer)
        {
            _service.Update(beer);
            return RedirectToActionPermanent(nameof(Details), beer);
        }
        
        [HttpGet("Details")]
        public async Task<IActionResult> Details(int id)
        {
			var beer = await _service.Get(id);
            return View(beer);
        }
        
        [HttpGet("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
			var beer = await _service.Get(id);
            return View(beer);
        }

		[HttpPost("Delete")]
		public IActionResult Delete(Beer beer)
        {
            _service.Delete(beer);
			return RedirectToActionPermanent(nameof(Index));
        }
        
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(Beer beer)
        {
            await _service.Create(beer);
            return RedirectToActionPermanent(nameof(Details), new { beer.Id });
        }
    }
}
