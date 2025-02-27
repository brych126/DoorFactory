﻿using System;
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
                return RedirectToAction("SuccessOrder");
            }
            CustomerDataVMInitializer(model);
            return View(model);
        }

        public IActionResult EditOrder()
        {
            var editModel = new List<EditDoorOrderViewModel>();
            var doorsInfo = _orderCreator.GetOrderDoors();
            EditDoorOrderVMInitializer(editModel,doorsInfo);
            return View(editModel);
        }

        public IActionResult DeleteItem(int id)
        {
            _orderCreator.DeleteItem(id);
            return RedirectToAction("EditOrder");
        }

        [HttpGet]
        public IActionResult EditDoor(int id)
        {
            var model = _orderCreator.GetItemToEdit(id);
            DoorOrderVMInitializer(model);
            return View(model);
        }

        [HttpPost]
        public IActionResult EditDoor(DoorOrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                _orderCreator.EditItem(model,_dbContext);
                return RedirectToAction("EditOrder");
            }
            DoorOrderVMInitializer(model);
            return View(model);
        }

        private void EditDoorOrderVMInitializer(List<EditDoorOrderViewModel> editModel, List<DoorOrderViewModel> doors)
        {
            foreach (var doorInfo in doors)
            {
                var x = new EditDoorOrderViewModel
                {
                    Door = doorInfo.Door,
                    Color = _dbContext.Colors.First(c => c.ColorId == doorInfo.Door.ColorId).Name,
                    BaseMaterial = _dbContext.Materials.First(m => m.MaterialId == doorInfo.BaseMaterialID).Name,
                    Lock = _dbContext.Materials.First(m => m.MaterialId == doorInfo.LockID).Name,
                    BaseMaterialCategory = _dbContext.MaterialsCategory
                        .First(mc => mc.MaterialCategoryId == doorInfo.BaseMaterialCategoryID).Name,
                    LockCategory = _dbContext.MaterialsCategory
                        .First(mc => mc.MaterialCategoryId == doorInfo.LockCategoryID).Name,
                    DoorCategory = _dbContext.DoorCategories
                        .First(dc => dc.DoorsCategoriesId == doorInfo.Door.DoorsCategoriesId).CategoryName,
                    OpeningStyle = _dbContext.OpeningStyles
                        .First(os => os.OpeningStylesId == doorInfo.Door.OpeningStylesId).Name,
                    StyleType = _dbContext.StyleTypes.First(st => st.StyleTypesId == doorInfo.Door.StyleTypesId).Name,
                    DoorQuantity = doorInfo.OrderDetails.DoorQuantity,
                    DoorPosition = doors.IndexOf(doorInfo)
                };
                editModel.Add(x);
            }
        }

        private void CustomerDataVMInitializer(CustomerDataViewModel model)
        {
            var citiesList = _dbContext.Cities.ToList();
            var cities = new SelectList(citiesList, "CityId", "City");
            model.Cities = cities;
        }

        public IActionResult Materials()
        {
            var model= new MaterialsViewModel();
            var baseMaterials = _dbContext.Materials.Include(m => m.MaterialCategory)
                .Where(m => m.MaterialCategoryId < 3).ToList();
            var locks = _dbContext.Materials.Include(m => m.MaterialCategory)
                .Where(m => m.MaterialCategoryId >= 3).ToList();
            var colors= _dbContext.Colors.ToList();
            var colorsCode=new List<string>(){ "#000000", "#FBEC5D", "#645452", "#F0DC82", "#cd7f32", "#964B00", "#F0FFFF", "#3D2B1F", "#2B1700", "	#080808", "#F5F5DC" };
            model.BaseMaterials = baseMaterials;
            model.Locks = locks;
            model.Colors = colors;
            model.ColorCode=colorsCode;
            return View(model);
        }

        public IActionResult OrderInfo(int id)
        {
            var order = _dbContext.Orders.Include(o => o.OrderDetails)
                .ThenInclude(od => od.Door)
                .ThenInclude(d=>d.StyleTypes)
                .Include(o=>o.OrderDetails)
                .ThenInclude(od=>od.Door)
                .ThenInclude(d=>d.OpeningStyles)
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Door)
                .ThenInclude(d => d.DoorsCategories)
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Door)
                .ThenInclude(d => d.MaterialsDoor)
                .ThenInclude(md=>md.Material)
                .ThenInclude(m=>m.MaterialCategory)
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Door)
                .ThenInclude(d => d.Color)
                .Include(o=>o.Customers)
                .Include(o=>o.Employee)
                .Include(o=>o.DelieveryInfo)
                .First(o => o.OrderId == id);
            var model=new OrderViewModel()
            {
                Order = order,
                UniqueDoors = order.OrderDetails.Count,
                DoorsAmount = order.OrderDetails.Sum(od=>od.DoorQuantity)
            };
            return View(model);
        }

        public IActionResult ChangeDeliveryStatus(int id)
        {
            var delivery = _dbContext.DelieveryInfo.First(d => d.OrderId == id);
            delivery.Status = delivery.Status==0 ? (short) 1 : (short) 0;
            _dbContext.DelieveryInfo.Update(delivery);
            _dbContext.SaveChanges();
            return RedirectToAction("OrderInfo",new{id=id});
        }

        public IActionResult ChangePaymentStatus(int id)
        {
            var order = _dbContext.Orders.First(o => o.OrderId == id);
            order.PaymentStatus = order.PaymentStatus==0 ? (short) 1 : (short) 0;
            _dbContext.Orders.Update(order);
            _dbContext.SaveChanges();
            return RedirectToAction("OrderInfo", new { id = id });
        }

        public IActionResult DeleteOrder(int id)
        {
            var order = _dbContext.Orders
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Door)
                .First(o => o.OrderId == id);
            foreach (var orderDetail in order.OrderDetails)
            {
                _dbContext.Doors.Remove(orderDetail.Door);
            }
            _dbContext.Orders.Remove(order);
            _dbContext.SaveChanges();
            return RedirectToAction("OrdersInfo");
        }

        public IEnumerable<Materials> GetMaterials(int ID)
        {
            var materials = _dbContext.Materials.Where(m => m.MaterialCategoryId == ID).ToList();
            return materials;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult SuccessOrder()
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
