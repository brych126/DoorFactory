using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoorFactory.Interfaces;
using DoorFactory.Models;
using DoorFactory.ViewModels;

namespace DoorFactory.Services
{
    public class OrderCreator:IOrderCreator
    {
        private Orders _order;
        private List<Doors> _doors;
        private List<OrderDetails> _orderDetails;
        private Doors _currentDoor;
        private Customers _customer;
        private OrderDetails _currentOrderDetails;
        private List<DoorOrderViewModel> _doorVM;
        private int _editIndex;

        public OrderCreator()
        {
            _order = new Orders();
            _currentDoor=new Doors(); 
            _currentOrderDetails=new OrderDetails();
            _doors =new List<Doors>();
            _orderDetails=new List<OrderDetails>();
            _customer=new Customers();
            _doorVM = new List<DoorOrderViewModel>();
        }

        private void ResetAllFields()
        {
            _doors.Clear();
            _orderDetails.Clear();
            _doorVM.Clear();
            _order = null;
            _currentDoor = null;
            _currentOrderDetails = null;
            _customer = null;
        }

        private void ResetCurrentFields()
        {
            _currentDoor = null;
            _currentOrderDetails = null;
        }

        public void ReadData(DoorOrderViewModel model, DoorsDatabaseContext dbContext)
        {
            if (_order==null)
            {
                _order = new Orders();
            }
            _currentDoor = DesignDoor(model, dbContext);
            _doors.Add(_currentDoor);
            _currentOrderDetails = FormOrderDetails(model);
            _orderDetails.Add(_currentOrderDetails);
            _doorVM.Add(model);
            ResetCurrentFields();
        }

        public void SetCustomer(CustomerDataViewModel model)
        {
            _customer = model.Customer;
            if (model.NeedDelivery)
            {
                var deliveryInfo = model.DeliveryInfo;
                deliveryInfo.Date = DateTime.Now.Add(new TimeSpan(15, 0, 0, 0));
                deliveryInfo.EmployeeId = 1;
                deliveryInfo.Status = 0;
                _order.DelieveryInfo.Add(deliveryInfo);
            }
        }

        public void CreateOrder(DoorsDatabaseContext dbContext)
        {
            var orderSum = _orderDetails.Sum(od => od.Door.Price * od.DoorQuantity);
            _order.OrderTotalPrice = _order.DelieveryInfo.Count==0 ? orderSum : orderSum + 650;
            _order.Customers = _customer;
            _order.EmployeeId = 1;
            _order.OrderDate=DateTime.Now;
            _order.PaymentDeadline = _order.OrderDate.Add(new TimeSpan(25, 0, 0, 0));
            _order.OrderDetails = _orderDetails;
            dbContext.Orders.Add(_order);
            dbContext.SaveChanges();
            ResetAllFields();
        }

        public List<DoorOrderViewModel> GetOrderDoors()
        {
            return  _doorVM;
        }

        public void DeleteItem(int index)
        {
            _doors.RemoveAt(index);
            _orderDetails.RemoveAt(index);
            _doorVM.RemoveAt(index);
        }

        public DoorOrderViewModel GetItemToEdit(int index)
        {
            _editIndex = index;
            return _doorVM[index];
        }

        public void EditItem(DoorOrderViewModel model, DoorsDatabaseContext dbContext)
        {
            _doors[_editIndex] = DesignDoor(model, dbContext);
            _orderDetails[_editIndex] = FormOrderDetails(model);
            _doorVM[_editIndex]=model;
        }


        private Doors DesignDoor(DoorOrderViewModel model, DoorsDatabaseContext dbContext)
        {
            var doorToDesign = model.Door;
            double baseMaterialCount = doorToDesign.Height/100.0 * doorToDesign.Width/100.0 * doorToDesign.Thickness/100.0;
            var baseMaterial = dbContext.Materials.First(m => m.MaterialId == model.BaseMaterialID);
            var doorLock = dbContext.Materials.First(m => m.MaterialId == model.LockID);
            doorToDesign.MaterialsDoor.Add(new MaterialsDoor(){Door = doorToDesign,MaterialId = baseMaterial.MaterialId,CountMaterial = baseMaterialCount});
            doorToDesign.MaterialsDoor.Add(new MaterialsDoor() { Door = doorToDesign, MaterialId = doorLock.MaterialId, CountMaterial = 1});
            var doorPrice = baseMaterialCount * (double) baseMaterial.Price + (double) doorLock.Price;
            const double doorRate = 0.42;
            doorToDesign.Price = Decimal.Round((decimal) doorPrice, 2);
            doorToDesign.Rate = doorRate;
            doorToDesign.DoorName = "Тест";
            return doorToDesign;
        }

        private OrderDetails FormOrderDetails(DoorOrderViewModel model)
        {
            return new OrderDetails()
            {
                DoorQuantity = model.OrderDetails.DoorQuantity,
                Door = _currentDoor,
            };
        }

        public int GetDoorsCount()
        {
            return _doors.Count;
        }
    }
}
