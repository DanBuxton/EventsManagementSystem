using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsManagementSystem.Models
{
    public class Event
    {
        private int eventCode = 0;
        public int EventCode
        {
            get => eventCode;

            set
            {
                if (value > 99) eventCode = value;
            }
        }

        private string name = "???";
        public string Name
        {
            get => name;

            set
            {
                if (value.Length < 40) name = value;
            }
        }

        private int numberOfTickets = 0;
        public int NumberOfTickets
        {
            get => numberOfTickets;

            set
            {
                if (value > 0) numberOfTickets = value;
            }
        }

        private double pricePerTicket = 5.99;
        public double PricePerTicket
        {
            get => pricePerTicket;

            set
            {
                if (value > 0) pricePerTicket = value;
            }
        }

        private int numberOfTicketsAvaliable = 0;
        public int NumberOfTicketsAvaliable
        {
            get => numberOfTicketsAvaliable;

            set => numberOfTicketsAvaliable = (value >= 0 ? value : 0);
        }

        private readonly DateTime dateAdded = DateTime.Now;
        public DateTime DateAdded { get => dateAdded; }

        public override string ToString()
        {
            return $"({EventCode}) {Name} {NumberOfTickets} ({numberOfTicketsAvaliable} left)";
        }
    }
}
