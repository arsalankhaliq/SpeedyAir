using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace SpeedyAir
{
    class Program
    {
        static void Main(string[] args)
        {
            var flights = new List<Flight>
            {
                new Flight(1, "YUL", "YYZ", 1),
                new Flight(2, "YUL", "YYC", 1),
                new Flight(3, "YUL", "YVR", 1),
                new Flight(4, "YUL", "YYZ", 2),
                new Flight(5, "YUL", "YYC", 2),
                new Flight(6, "YUL", "YVR", 2)
            };

            var ordersJSON = File.ReadAllText("..\\..\\..\\coding-assigment-orders.json");
            var ordersObjs = JsonConvert.DeserializeObject<Dictionary<string, Order>>(ordersJSON);
            for (int i = 1; i < 100; i++)
            {
                var order = new Order();
                var orderNum = "order-" + i.ToString("D3");
                if(ordersObjs.TryGetValue(orderNum, out order))
                {
                    foreach (var flight in flights)
                    {
                        if(flight.ArrivalCity == order.Destination && flight.RemainingCapacity > 0)
                        {
                            flight.AddOrder(order);
                            Console.WriteLine($"order: {orderNum}, flightNumber: {flight.FlightNumber}, departure: {flight.DepartureCity}, arrival: {flight.ArrivalCity}, day: {flight.Day}");
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"order: {orderNum}, flightNumber: not scheduled");
                }
            }
            foreach (var flight in flights)
            {
                Console.WriteLine(flight.RemainingCapacity);
            }
        }
    }
}
