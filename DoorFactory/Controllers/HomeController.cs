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
            //var door= new Doors()
            //{
            //    DoorName = "Тестові двері",
            //    Width = 571,
            //    Height = 2122,
            //    Thickness = 112,
            //    Price = 4123,
            //    Rate = 0.42,
            //    DoorsCategoriesId = 3,
            //    OpeningStylesId = 2,
            //    StyleTypesId = 3,
            //    ColorId = 6, 
            //};
            //var order =new Orders()
            //{
            //    OrderDate = Convert.ToDateTime("2020-05-14"),
            //    PaymentDeadline = Convert.ToDateTime("2020-09-01"),
            //    PaymentStatus = 0,
            //    OrderTotalPrice = 11709,
            //    CustomersId = 6,
            //    EmployeeId = 6 
            //};
            //var orderDetail=new OrderDetails()
            //{
            //    Door = door,
            //    Order = order,
            //    DoorQuantity = 2
            //};
            //_dbContext.Doors.Add(door);
            //_dbContext.Orders.Add(order);
            //_dbContext.OrderDetails.Add(orderDetail);
            //_dbContext.SaveChanges();
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

        [HttpGet]
        public IActionResult CustomerForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CustomerForm(Customers customer)
        {
            if (ModelState.IsValid)
            {
                return Content(customer.Name +" "+ customer.LastName);
            }
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
