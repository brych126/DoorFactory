using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoorFactory.Interfaces;

namespace DoorFactory.Services
{
    public class Test:ITest
    {
        private int variable;

        public Test()
        {
            variable = 0;
        }
        public int Increment()
        {
            ++variable;
            return variable;
        }
    }
}
