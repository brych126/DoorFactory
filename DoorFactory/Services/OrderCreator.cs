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

        public OrderCreator()
        {
            _order = new Orders();
            _doors =new List<Doors>();
            _orderDetails=new List<OrderDetails>();
        }

        public void ResetAllFields()
        {
            _doors.Clear();
            _orderDetails.Clear();
            _order = null;
        }

        public void ReadData(DoorOrderViewModel model)
        {
            if (_order==null)
            {
                _order = new Orders();
            }
            _doors.Add(model.Door);
        }

        public int GetDoorsCount()
        {
            return _doors.Count;
        }
    }
}
