using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DoorFactory.Interfaces;
using Microsoft.AspNetCore.Mvc;
using DoorFactory.Models;
using DoorFactory.ViewModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DoorFactory.Controllers
{
    public class HomeController : Controller
    {
        private DoorsDatabaseContext _dbContext;
        private IOrderCreator _orderCreator;

        public HomeController(IOrderCreator orderCreator)
        {
            _dbContext=new DoorsDatabaseContext();
            _orderCreator = orderCreator;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult OrderDoor()
        {
            //var order=new Orders()
            //{
            //    OrderDate = DateTime.Now,
            //    PaymentStatus =0,
            //    PaymentDeadline = DateTime.Now,
            //    CustomersId = 1,
            //    EmployeeId = 1,
            //    OrderTotalPrice = 755
            //};
            //order.OrderDetails.Add(new OrderDetails(){DoorQuantity = 2,DoorId = 1});
            //_dbContext.Orders.Add(order);
            //_dbContext.SaveChanges();
            var model =new DoorOrderViewModel();
            DoorOrderVMInitializer(model);
            return View(model);
        }

        [HttpPost]
        public IActionResult OrderDoor(DoorOrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                _orderCreator.ReadData(model,_dbContext);
                return RedirectToAction("OrderDoor");
            }
            DoorOrderVMInitializer(model);
            return View(model);
        }

        private void DoorOrderVMInitializer(DoorOrderViewModel model)
        {
            var colorsList = _dbContext.Colors.ToList();
            var colors = new SelectList(colorsList, "ColorId", "Name");
            var doorCategoriesList = _dbContext.DoorCategories.ToList();
            var doorCategories = new SelectList(doorCategoriesList, "DoorsCategoriesId", "CategoryName");
            var openingStylesList = _dbContext.OpeningStyles.ToList();
            var openingStyles = new SelectList(openingStylesList, "OpeningStylesId", "Name");
            var styleTypesList = _dbContext.StyleTypes.ToList();
            var styleTypes = new SelectList(styleTypesList, "StyleTypesId", "Name");
            var materialsCategoriesList = _dbContext.MaterialsCategory.Where(mc=>mc.MaterialCategoryId < 3).ToList();
            var materialCategories = new SelectList(materialsCategoriesList, "MaterialCategoryId", "Name");
            var lockCategoriesList = _dbContext.MaterialsCategory.Where(mc => mc.MaterialCategoryId >= 3).ToList();
            var lockCategories = new SelectList(lockCategoriesList, "MaterialCategoryId", "Name");
            var baseMaterialsList = new List<Materials>();
            var baseMaterials = new SelectList(materialsCategoriesList, "MaterialId", "Name");
            var locksList = new List<Materials>();
            var locks = new SelectList(lockCategoriesList, "MaterialId", "Name");
            if (model.BaseMaterialCategoryID==0)
            { 
                baseMaterialsList = _dbContext.Materials
                    .Where(m => m.MaterialCategoryId == 1)
                    .ToList();
                baseMaterials = new SelectList(baseMaterialsList, "MaterialId", "Name");
            }
            else
            {
                baseMaterialsList = _dbContext.Materials
                    .Where(m => m.MaterialCategoryId == model.BaseMaterialCategoryID)
                    .ToList();
                baseMaterials = new SelectList(baseMaterialsList, "MaterialId", "Name");
            }
            if (model.LockCategoryID == 0)
            {
                locksList = _dbContext.Materials
                    .Where(m => m.MaterialCategoryId == 3)
                    .ToList();
                locks = new SelectList(locksList, "MaterialId", "Name");
            }
            else
            {
                locksList = _dbContext.Materials
                    .Where(m => m.MaterialCategoryId == model.LockCategoryID)
                    .ToList();
                locks = new SelectList(locksList, "MaterialId", "Name");
            }
            model.Colors = colors;
            model.DoorCategories = doorCategories;
            model.OpeningStyles = openingStyles;
            model.StyleTypes = styleTypes;
            model.MaterialCategories = materialCategories;
            model.LockCategories = lockCategories;
            model.BaseMaterials = baseMaterials;
            model.Locks = locks;
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

            #region MyRegion
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
            #endregion
           
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
            var model = new CustomerDataViewModel();
            CustomerDataVMInitializer(model);
            return View(model);
        }

        [HttpPost]
        public IActionResult CustomerForm(CustomerDataViewModel model)
        {
            if (!model.NeedDelivery)
            {
              ModelState["DeliveryInfo.Adress"].ValidationState=ModelValidationState.Skipped;
            }
            if (ModelState.IsValid)
            {
                _orderCreator.SetCustomer(model);
                _orderCreator.CreateOrder(_dbContext);
                return RedirectToAction("Index");
            }
            CustomerDataVMInitializer(model);
            return View(model);
        }

        private void CustomerDataVMInitializer(CustomerDataViewModel model)
        {
            var citiesList = _dbContext.Cities.ToList();
            var cities = new SelectList(citiesList, "CityId", "City");
            model.Cities = cities;
        }

        public IEnumerable<Materials> GetMaterials(int ID)
        {
            var materials = _dbContext.Materials.Where(m=>m.MaterialCategoryId==ID).ToList();
            return materials;
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
