using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EventsManagementSystem.Models;

namespace EventsManagementSystem
{
    public class Program
    {
        public Stack<Event> Events { get; set; } = new Stack<Event>();
        public Queue<Booking> Bookings { get; set; } = new Queue<Booking>();
        public List<TransactionLog> Transactions { get; set; } = new List<TransactionLog>();

        public static void Main(string[] args)
        {
            // Event has a queue of bookings OR Booking has an event property?????
        }

        public void CancelBooking()
        {

        }
    }
}
