using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoorFactory.ViewModels;

namespace DoorFactory.Interfaces
{
    public interface IOrderCreator
    {
        void ResetAllFields();
        void ReadData(DoorOrderViewModel model);
        int GetDoorsCount();
    }
}
