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
        public int BookingCode { get => bookingCode; set => bookingCode = (value > 5 ? value : bookingCode); }

        private int eventCode = 1000;
        private string customerName = "???";
        private string customerAddress = "???";
        private int numberOfTicketsToBuy = 0;
        private DateTime dateAdded = DateTime.Now;

    }
}
