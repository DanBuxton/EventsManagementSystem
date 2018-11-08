using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsManagementSystem.Models
{
    public class BookingLinkedListNode
    {
        public Booking Data { get; set; } = null;
        public BookingLinkedListNode NextNode { get; set; } = null;
    }
}
