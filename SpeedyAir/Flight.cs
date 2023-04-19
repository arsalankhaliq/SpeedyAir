using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyAir
{
    class Flight
    {
        public int FlightNumber { get; }
        public string DepartureCity { get; }
        public string ArrivalCity { get; }
        public int Day { get; }
        public List<Order> Orders { get; } = new List<Order>();
        public int RemainingCapacity => 20 - Orders.Count;

        public Flight(int flightNumber, string departureCity, string arrivalCity, int day)
        {
            FlightNumber = flightNumber;
            DepartureCity = departureCity;
            ArrivalCity = arrivalCity;
            Day = day;
        }

        public void AddOrder(Order order)
        {
            Orders.Add(order);
        }
    }
}
