using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoorFactory.Models;
using DoorFactory.ViewModels;

namespace DoorFactory.Interfaces
{
    public interface IOrderCreator
    {
        void ResetAllFields();
        void ReadData(DoorOrderViewModel model, DoorsDatabaseContext _dbContext);
        int GetDoorsCount();
        void SetCustomer(CustomerDataViewModel model);
        void CreateOrder(DoorsDatabaseContext _dbContext);
    }
}
