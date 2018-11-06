using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsManagementSystem.Models
{
    public class Booking
    {
        private int bookingCode = 1000;
        public int BookingCode { get => bookingCode; set => bookingCode = (value > 999 && value < 10000 ? value : bookingCode); }

        private int eventCode = 1000;
        public int EventCode { get => eventCode; set => eventCode = ((value > 999) && (value < 10000) ? value : eventCode); }

        private string customerName = "???";
        public string CustomerName { get => customerName; set => customerName = (value.Length >= 10 ? value : customerName); }

        private string customerAddress = "???";
        public string CustomerAddress { get => customerAddress; set => customerAddress = (value.Length >= 10 ? value : customerAddress); }

        private int numberOfTicketsToBuy = 0;
        public int NumberOfTicketsToBuy { get => numberOfTicketsToBuy; set => numberOfTicketsToBuy = value; }
        
        private double pricePerTicket = 5.99;
        public double PricePerTicket
        {
            get => pricePerTicket;

            set
            {
                if (value > 0) pricePerTicket = value;
            }
        }
        public double Price { get { return numberOfTicketsToBuy * pricePerTicket; } }
        
        public DateTime DateAdded { get; } = DateTime.Now;
    }
}
