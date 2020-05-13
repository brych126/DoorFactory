using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using DoorFactory.Interfaces;
using DoorFactory.Models;
using DoorFactory.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DoorFactory.Controllers
{
    public class AccountController : Controller
    {
        private readonly ICustomUserManager _userManager;
        private DoorsDatabaseContext _dbContext;

        public AccountController(ICustomUserManager userManager)
        {
            _userManager = userManager;
            _dbContext=new DoorsDatabaseContext();
        }

        [HttpGet]
        public IActionResult LogInPage()
        {
            _dbContext = new DoorsDatabaseContext();
            return View();
        }

        [HttpPost]
        public IActionResult LogInPage(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_dbContext.Employees.Any(u=>u.Username==model.User.Username && u.Password==model.User.Password))
                {
                    var user = _dbContext.Employees.First(e =>
                        e.Username == model.User.Username && e.Password == model.User.Password);
                    _userManager.LogIn(user);
                    return RedirectToAction("Index", "Home");
                }

                if (!_dbContext.Employees.Any(u => u.Username == model.User.Username))
                {
                    ModelState.AddModelError("", "Користувача з таким ім'я немає у системі.");
                }
                else
                {
                    ModelState.AddModelError("User.Password", "Неправильний пароль. Повторіть спробу.");
                }

                return View(model);
            }
            return View(model);
        }

        public IActionResult LogOut()
        {
            _userManager.LogOut();
            return RedirectToAction("Index", "Home");
        }

    }
}
