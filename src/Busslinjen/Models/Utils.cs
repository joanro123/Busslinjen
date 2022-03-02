using System;
using System.Collections.Generic;
using System.Linq;

namespace Busslinjen.Models
{
    public class Utils
    {
        public Random Rnd { get; set; } = new Random();
        public void CreateStops(List<BusStop> stops)
        {
            for (int i = 0; i < 10; i++)
            {
                BusStop busStop = new BusStop();
                busStop.Name = (Stop)i;
                stops.Add(busStop);
            }

        }

        public Stop RandomStop()
        {
            Array values = Enum.GetValues(typeof(Stop));
            Stop randomStop = (Stop)values.GetValue(Rnd.Next(values.Length));
            return randomStop;
        }

        public void ShowWaitingPassengers(List<BusStop> stops, int index, Bus bus, List<Passenger> passengers)
        {
            foreach (var item in stops)
            {
                if (item.Name == stops[index].Name)
                {
                    Console.WriteLine(item.Name);
                    Console.WriteLine("Bussen är här. Antal väntande passagerare: " + item.WaitingPassengers);
                    var q = passengers.Where(w => w.StopTravelingTo == stops[index].Name && w.IsInTheBus == true).Count();
                    if (q != 0)
                    {
                        Console.WriteLine("Lämnar av " + q + " passagerare.");
                    }

                    Console.WriteLine("Antal passagerare i bussen: " + bus.PassengersInTheBus);
                    if (bus.BusFull)
                    {
                        Console.WriteLine("Bussen är fullsatt");
                    }
                    Console.WriteLine();
                }
                if (item.Name != stops[index].Name)
                {
                    Console.WriteLine(item.Name);
                    Console.WriteLine("Antal väntande passagerare: " + item.WaitingPassengers);
                    Console.WriteLine();
                }
            }
        }

        public void NewPassenger(List<BusStop> stops, Passenger passenger)
        {
            foreach (var item in stops)
            {
                if (passenger.StopWaitingAt == item.Name)
                {
                    item.WaitingPassengers++;
                }
            }
        }

        public void RemoveFromList(List<Passenger> passengers)
        {
            foreach (var item in passengers)
            {
                if (item.RemoveFromList)
                {
                    passengers.Remove(item);
                    break;
                }
            }
        }

        public void PassengersOnOff(List<BusStop> stops, List<Passenger> passengers, Bus bus, int index)
        {
            foreach (var pass in passengers)
            {
                if (pass != null && pass.RemoveFromList != true)
                {
                    if (pass.StopWaitingAt == stops[index].Name && pass.IsInTheBus == false)
                    {
                        if (bus.PassengersInTheBus < bus.MaxPassengers)
                        {
                            pass.IsInTheBus = true;
                            bus.PassengersInTheBus++;
                            stops[index].WaitingPassengers--;
                            bus.BusFull = false;
                        }
                        if (bus.PassengersInTheBus == bus.MaxPassengers)
                        {
                            bus.BusFull = true;
                        }
                    }
                    if (pass.StopTravelingTo == stops[index].Name && pass.IsInTheBus == true)
                    {
                        bus.PassengersInTheBus--;
                        pass.RemoveFromList = true;
                    }
                }
            }
        }

        public string ShowTime(int minutes, int hours, string status, string high, string low)
        {
            
            if
                (minutes >= 60)
            {
                hours++;
                if (hours == 24)
                {
                    hours = 0;
                }
                minutes = 0;
                if (minutes == 0)
                {
                    Console.WriteLine("Klockan är " + hours + ":" + minutes + "0");
                }
                else
                {
                    Console.WriteLine("Klockan är " + hours + ":" + minutes);
                }
            }
            else
            {
                Console.WriteLine("Klockan är " + hours + ":" + minutes);
            }
            if ((hours > 6 && hours < 10) || (hours > 15 && hours < 19))
            {
                Console.WriteLine(high);
                status = high;
            }
            else
            {
                Console.WriteLine(low);
                status = low;
            }
            return status;
        }

        //public Stop RandomTravelingToStop()
        //{
        //    bool running = true;
        //    Stop randomStop = 0;
        //    while (running)
        //    {
        //        Array values = Enum.GetValues(typeof(Stop));
        //        randomStop = (Stop)values.GetValue(Rnd.Next(values.Length));
        //        if (randomStop != RandomWaitingAtStop())
        //        {
        //            running = false;
        //        }

        //    }
        //    return randomStop;

        //}
    }
}
