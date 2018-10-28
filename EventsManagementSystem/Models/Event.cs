using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsManagementSystem.Models
{
    public class Event
    {
        private static int _PrevEventCode { get; set; } = 99;
        public int EventCode { get; private set; } = 100;
        public string Name { get; private set; } = "???";
        public int NumberOfTickets { get; set; } = 0;
        public double PricePerTicket { get; protected internal set; } = 5.99;

        public int NumberOfTicketsAvaliable { get; protected internal set; } = 0;

        public DateTime DateAdded { get; private set; } = DateTime.Now;

        public Event(string name, int numberOfTickets, double pricePerTicket)
        {
            //Id's
            _PrevEventCode++;
            EventCode = _PrevEventCode;

            Name = name;
            NumberOfTickets = numberOfTickets;
            PricePerTicket = pricePerTicket;

            NumberOfTicketsAvaliable = numberOfTickets;
        }

        public override string ToString()
        {
            return $"Code: {EventCode} : ";
        }
    }
}
