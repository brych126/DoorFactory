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
        private Employees _user;
        public bool IsUserLoggedIn()
        {
            return _isLoggedIn;
        }

        public void LogIn(Employees user)
        {
            _user = user;
            _isLoggedIn = true;
        }

        public void LogOut()
        {
            _user = null;
            _isLoggedIn = false;
        }

        public string GetUserName()
        {
            return _user.Name;
        }
    }
}
