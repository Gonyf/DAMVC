using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DAMVC.DTO;
using DAMVC.Extensions;
using DAMVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DAMVC.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var loggedInUserName = this.GetLoggedInUserName();
            var model = new UserIndexVM
            {
                UserName = loggedInUserName
            };
            return View(model);
        }

    }
}
