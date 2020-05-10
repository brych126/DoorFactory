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
        private OrderDetails _currentOrderDetails;

        public OrderCreator()
        {
            _order = new Orders();
            _currentDoor=new Doors();
            _currentOrderDetails=new OrderDetails();
            _doors =new List<Doors>();
            _orderDetails=new List<OrderDetails>();
        }

        public void ResetAllFields()
        {
            _doors.Clear();
            _orderDetails.Clear();
            _order = null;
            _currentDoor = null;
            _currentOrderDetails = null;
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
            ResetCurrentFields();
        }

        public void SetCustomer()
        {
            ;
        }


        private Doors DesignDoor(DoorOrderViewModel model, DoorsDatabaseContext dbContext)
        {
            var doorToDesign = model.Door;
            double baseMaterialCount = doorToDesign.Height/100.0 * doorToDesign.Width/100.0 * doorToDesign.Thickness/100.0;
            var baseMaterial = dbContext.Materials.Find(model.BaseMaterialID);
            var doorLock = dbContext.Materials.Find(model.LockID);
            doorToDesign.MaterialsDoor.Add(new MaterialsDoor(){Door = doorToDesign,Material = baseMaterial,CountMaterial = baseMaterialCount});
            doorToDesign.MaterialsDoor.Add(new MaterialsDoor() { Door = doorToDesign, Material = doorLock, CountMaterial = 1});
            var doorPrice = baseMaterialCount * (double) baseMaterial.Price + (double) doorLock.Price;
            const double doorRate = 0.42;
            doorToDesign.Price = Decimal.Round((decimal) doorPrice, 2);
            doorToDesign.Rate = doorRate;
            return doorToDesign;
        }

        private OrderDetails FormOrderDetails(DoorOrderViewModel model)
        {
            return new OrderDetails()
            {
                DoorQuantity = model.OrderDetails.DoorQuantity,
                Door = _currentDoor,
                Order = _order
            };
        }

        public int GetDoorsCount()
        {
            return _doors.Count;
        }
    }
}
