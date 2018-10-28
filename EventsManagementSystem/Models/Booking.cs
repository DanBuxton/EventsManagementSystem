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
        public int BookingCode { get; private set; } = 1;

        public int EventCode { get { return Event.EventCode; } }
        public string CustomerName { get; private set; } = "???";
        public string CustomerAddress { get; private set; } = "???";
        public int NumberOfTicketsToBuy { get; protected internal set; } = 0;
        public DateTime DateAdded { get; private set; } = DateTime.Now;
        public double TotalPriceOfTickets { get { return Event.PricePerTicket * NumberOfTicketsToBuy; } }

        private Event Event { get; set; } = new Event(name: "???", numberOfTickets: 50, pricePerTicket: 5.99);

        public Booking(Event _event, string customerName, string customerAddress, int numberOfTicketsToBuy = 1)
        {
            Event = _event;

            //Id's
            _PrevBookingCode++;
            BookingCode = _PrevBookingCode;

            CustomerName = customerName;
            CustomerAddress = customerAddress;
            NumberOfTicketsToBuy = numberOfTicketsToBuy;
        }
    }
}
