using System;

namespace EventsManagementSystem.Models
{
    public class EventDetails
    {
        public int EventCode
        {
            get => eventCode;

            set
            {
                if (value > 99) eventCode = value;
            }
        }
        private int eventCode = 0;

        public string Name
        {
            get => name;

            set
            {
                if (value.Length < 40) name = value;
            }
        }
        private string name = "???";

        public int NumberOfTickets
        {
            get => numberOfTickets;

            set
            {
                if (value > 0) numberOfTickets = value;
            }
        }
        private int numberOfTickets = 0;

        public double PricePerTicket
        {
            get => pricePerTicket;

            set
            {
                if (value > 0) pricePerTicket = value;
            }
        }
        private double pricePerTicket = 5.99;

        public int NumberOfTicketsAvaliable
        {
            get => numberOfTicketsAvaliable;

            set => numberOfTicketsAvaliable = (value >= 0) && (value <= numberOfTickets) ? value : numberOfTicketsAvaliable;
        }
        private int numberOfTicketsAvaliable = 0;

        public DateTime DateAdded { protected internal set; get; } = DateTime.Now;

        public DateTime DateUpdated { get { return dateUpdated; } set { if (value > DateAdded) dateUpdated = value; } }
        private DateTime dateUpdated;

        public override string ToString()
        {
            return string.Format("Id: {0:d}; Name: {1:s}; Tickets: {2:N0} at {3:c}, {4:N0} left; {5:s}", EventCode,
                Name, NumberOfTickets, pricePerTicket, numberOfTicketsAvaliable, DateAdded.ToString("dd/MM (HH:mm)"));
        }
    }
}
