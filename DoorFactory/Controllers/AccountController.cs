using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoorFactory.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DoorFactory.Controllers
{
    public class AccountController : Controller
    {
        private ICustomUserManager _userManager;

        public AccountController(ICustomUserManager userManager)
        {
            _userManager = userManager;
        }

        public IActionResult LogInPage()
        {
            return View();
        }
    }
}
