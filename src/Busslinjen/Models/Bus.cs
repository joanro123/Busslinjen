using System;
using System.Collections.Generic;
using System.Text;

namespace Busslinjen.Models
{
    /// <summary>
    /// Bus parameters.
    /// </summary>
    public class Bus
    {
         /// <summary>
        /// maximum amount of passengers
        /// </summary>
        public int MaxPassengers { get; set; } = 10;
        public int PassengersInTheBus { get; set; }
        public bool BusFull { get; set; } = false;
    }
}
