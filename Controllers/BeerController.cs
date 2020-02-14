using System;
using System.Collections.Generic;
using System.Linq;
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
        public IActionResult Edit()
        {
            return View();
        }
        
        [HttpGet("Details")]
        public IActionResult Details(BeerDTO beer)
        {
            return View(beer);
        }
        
        [HttpGet("Delete")]
        public IActionResult Delete()
        {
            return View();
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
            return View(RedirectToActionPermanent("Details","Beer", beer));
        }
    }
}
