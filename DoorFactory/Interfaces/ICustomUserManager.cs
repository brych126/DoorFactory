﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoorFactory.Models;

namespace DoorFactory.Interfaces
{
   public interface ICustomUserManager
    {
        bool IsUserLoggedIn();
        void LogIn(Employees user);
        void LogOut();
        string GetUserName();
    }
}
