using System;
using System.Collections.Generic;
using System.Text;

namespace Busslinjen.Models
{
    public class Passenger
    {
        public Stop StopWaitingAt { get; set; }
        public Stop StopTravelingTo { get; set; }
        public bool IsInTheBus { get; set; } = false;
        public bool RemoveFromList { get; set; }

        private Utils utils = new Utils();
        private bool running = true;

        public Passenger()
        {
            StopWaitingAt = utils.RandomStop();
            while (running)
            {
                StopTravelingTo = utils.RandomStop();
                if (StopWaitingAt != StopTravelingTo)
                {
                    running = false;
                }
            }

        }
    }
}
