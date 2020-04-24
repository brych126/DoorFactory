using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DoorFactory.Models;
using DoorFactory.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace DoorFactory.Controllers
{
    public class HomeController : Controller
    {
        DoorsDatabaseContext _dbContext;

        public HomeController()
        {
            _dbContext=new DoorsDatabaseContext();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult OrderDoor()
        {
            return View();
        }

        public IActionResult DoorsInfo()
        {
            DoorsViewModel dvm=new DoorsViewModel();
            var doors = _dbContext.Doors
                .Include(d => d.Color)
                .Include(d => d.DoorsCategories)
                .Include(d => d.MaterialsDoor)
                .Include(d => d.OpeningStyles)
                .Include(d => d.StyleTypes);
            dvm.Doors=new List<Doors>(doors);
            return View(dvm);
        }

        public IActionResult OrdersInfo()
        {
            List<OrdersViewModel> ovm = new List<OrdersViewModel>();
            var orders = _dbContext.Orders
                .Include(o => o.Customers)
                .Include(o => o.OrderDetails)
                .Include(o=>o.Employee);
            int doorsAmount = 0;
            foreach (var order in orders )
            {
                doorsAmount = 0;
                foreach (var orderDet in order.OrderDetails)
                {
                    doorsAmount += orderDet.DoorQuantity;
                }
                ovm.Add(new OrdersViewModel(){Order = order,DoorsAmount = doorsAmount});
            }
            return View(ovm);
        }

        public IActionResult CustomersInfo()
        {
            CustomersViewModel cvm = new CustomersViewModel();
            var customers = _dbContext.Customers
                .Include(c=>c.Orders);
            cvm.Customers = new List<Customers>(customers);
            return View(cvm);
        }

        public IActionResult CustomerForm()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
