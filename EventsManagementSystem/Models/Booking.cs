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
        public int BookingCode { get => bookingCode; set => bookingCode = (value > 5 ? value : 0); }

        private int EventCode = 1000;
        private string CustomerName = "???";
        private string CustomerAddress = "???";
        private int NumberOfTicketsToBuy = 0;
        private DateTime DateAdded = DateTime.Now;

    }
}
