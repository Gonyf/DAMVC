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
        public IActionResult Edit(int id)
        {
            var beer = _repo.Get(id);
            return View(beer);
        }
        
        [HttpGet("Details")]
        public IActionResult Details(int id)
        {
            var beer = _repo.Get(id);
            return View(beer);
        }
        
        [HttpGet("Delete")]
        public IActionResult Delete(int id)
        {
            var beer = _repo.Get(id);
            return View(beer);
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
        
        [HttpPost("Edit")]
        public IActionResult Edit(BeerDTO beer)
        {
            _repo.Update(beer);
            return RedirectToActionPermanent(nameof(Details), new { beer.Id });
        }        
        
        [HttpPost("Delete")]
        public IActionResult DeletePost(int id)
        {
            _repo.Delete(id);
            return RedirectToActionPermanent(nameof(Index));
        }
    }
}
