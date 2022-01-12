using Busslinjen.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Timers;

namespace Busslinjen
{
    class Program
    {
        static void Main(string[] args)
        {
            List<BusStop> stops = new List<BusStop>();
            List<Passenger> passengers = new List<Passenger>();
            Bus bus = new Bus();
            Utils utils = new Utils();
            utils.CreateStops(stops);
            bool running = true;
            int index = 0;
            int hours = DateTime.Now.Hour;
            int minutes = DateTime.Now.Minute;

            string low = "Lågtrafik";
            string high = "Högtrafik";
            string status = null;
            

            while (running)
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

                //   utils.ShowTime(minutes, hours, status, high, low);
                Console.WriteLine();

                Passenger passenger = new Passenger();
                utils.NewPassenger(stops, passenger);
                passengers.Add(passenger);

                if (status == high)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        Passenger passenger2 = new Passenger();
                        utils.NewPassenger(stops, passenger2);
                        passengers.Add(passenger2);
                    }
                }

                utils.PassengersOnOff(stops, passengers, bus, index);
                utils.ShowWaitingPassengers(stops, index, bus, passengers);


                utils.RemoveFromList(passengers);

                index++;
                if (index == stops.Count)
                {
                    index = 0;
                }

                //Thread.Sleep(2000);
                //Console.Clear();
                minutes += 10;

                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                }
            }
        }
    }
}
