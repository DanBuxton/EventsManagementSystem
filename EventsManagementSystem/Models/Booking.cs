using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsManagementSystem.Models
{
    public class Booking
    {
        private static int _PrevBookingCode { get; set; } = 0;
        public int BookingCode { get; private set; }

        public int EventCode { get; private set; }
        public string CustomerName { get; private set; }
        public string CustomerAddress { get; private set; }
        public int NumberOfTicketsToBuy { get; private set; }
        public DateTime DateAdded { get; private set; } = DateTime.Now;
        public double TotalPriceOfTickets { get { return Event.PricePerTicket * NumberOfTicketsToBuy; } }

        public Event Event { get; set; }

        private double PricePerTicket = 15.35;

        public Booking(Event _event, string customerName, string customerAddress, int numberOfTicketsToBuy = 1)
        {
            //Id's
            _PrevBookingCode++;
            BookingCode = _PrevBookingCode;
            EventCode = _event.EventCode;

            CustomerName = customerName;
            CustomerAddress = customerAddress;
            NumberOfTicketsToBuy = numberOfTicketsToBuy;
        }
    }
}
