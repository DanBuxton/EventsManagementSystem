using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsManagementSystem
{
    public class Program
    {
        public Stack<Event> Events { get; set; } = new Stack<Event>();
        public Queue<Booking> Bookings { get; set; } = new Queue<Booking>();

        public static void Main(string[] args)
        {

        }

        public void CancelBooking()
        {

        }
    }
}
