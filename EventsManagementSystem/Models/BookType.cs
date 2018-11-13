using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsManagementSystem.Models
{
    public class BookType
    {
        public int EventCode { get; set; } = 9999;
        public int BookingCode { get; set; } = 9999;
        public int NumOfTickets { get; set; } = 99;

        public override string ToString()
        {
            //return $"{BookingCode} {EventCode} {NumOfTickets}";
            return string.Format("Event ref: {0:d}, Booking ref: {1:d}, No. of tickets: {2:N0}", BookingCode, EventCode, NumOfTickets);
        }
    }
}
