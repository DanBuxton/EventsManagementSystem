using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsManagementSystem.Models
{
    public class Booking
    {
        public int BookingCode { get; } = prevCode++;
        //public int BookingCode { get => bookingCode; set => bookingCode = (value > 999 && value < 10000 ? value : bookingCode); }
        private static int prevCode = 1000;

        public int EventCode { get => eventCode; set => eventCode = ((value > 999) && (value < 10000) ? value : eventCode); }
        private int eventCode = 1000;

        public string CustomerName { get => customerName; set => customerName = (value.Length >= 4 ? value : customerName); }
        private string customerName = "???";

        public string CustomerAddress { get => customerAddress; set => customerAddress = (value.Length >= 10 ? value : customerAddress); }
        private string customerAddress = "???";

        public int NumberOfTicketsToBuy { get => numberOfTicketsToBuy; set => numberOfTicketsToBuy = value; }
        private int numberOfTicketsToBuy = 0;
        
        public double PricePerTicket
        {
            get => pricePerTicket;

            set
            {
                if (value > 0) pricePerTicket = value;
            }
        }
        private double pricePerTicket = 5.99;

        public double Price { get { return numberOfTicketsToBuy * pricePerTicket; } }
        
        public DateTime DateAdded { get; } = DateTime.Now;

        public override string ToString()
        {
            return string.Format("Code: {0:d}\nName: {1:s}\nAddress: {2:s} Tickets: {3:N0}({4:c2})", BookingCode, customerName, customerAddress, numberOfTicketsToBuy, Price);
        }
    }
}
