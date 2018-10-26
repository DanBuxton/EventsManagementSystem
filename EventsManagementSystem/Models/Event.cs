using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsManagementSystem.Models
{
    public class Event
    {
        private static int _PrevEventCode { get; set; } = 0;
        public int EventCode { get; private set; }
        public string Name { get; private set; }
        public int NumberOfTickets { get; private set; }
        public double PricePerTicket { get; private set; }

        public DateTime DateAdded { get; private set; } = DateTime.Now;

        public Event(string name, int numberOfTickets)
        {
            //Id's
            _PrevEventCode++;
            EventCode = _PrevEventCode;

            Name = name;
            NumberOfTickets = numberOfTickets;
        }
    }
}
