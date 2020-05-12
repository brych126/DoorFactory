using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoorFactory.Interfaces;
using DoorFactory.Models;

namespace DoorFactory.Services
{
    public class CustomUserManager:ICustomUserManager
    {
        private bool _isLoggedIn;

        public bool IsUserLoggedIn()
        {
            return _isLoggedIn;
        }

        public void LogInIntoSystem(Employees employee)
        {
            throw new NotImplementedException();
        }
    }
}
