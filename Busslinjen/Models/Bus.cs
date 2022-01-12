using System;
using System.Collections.Generic;
using System.Text;

namespace Busslinjen.Models
{
    public class Bus
    {
        public int MaxPassengers { get; set; } = 10;
        public int PassengersInTheBus { get; set; }
        public bool BusFull { get; set; } = false;
    }
}
