using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsManagementSystem.Models
{
    public class CancelType
    {
        public int BookingCode { get; set; } = 9999;
        public int NumOfTickets { get; set; } = 99;

        public override string ToString()
        {
            //return $"{BookingCode} {NumOfTickets}";
            return string.Format("Event ref: {0:d}, No. of tickets: {1:N0}", BookingCode, NumOfTickets);
        }
    }
}
