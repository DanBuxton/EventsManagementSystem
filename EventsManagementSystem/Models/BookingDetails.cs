using System;

namespace EventsManagementSystem.Models
{
    public sealed class BookingDetails
    {
        public int BookingCode { get; set; } = prevCode++;
        public static int prevCode = 1000;

        public int EventCode { get => eventCode; set => eventCode = ((value > 999) && (value < 10000) ? value : eventCode); }
        private int eventCode = 1000;

        public string CustomerName { get => customerName; set => customerName = (value.Length >= 4 ? value : customerName); }
        private string customerName = "???";

        public string CustomerAddress { get => customerAddress; set => customerAddress = (value.Length >= 8 ? value : customerAddress); }
        private string customerAddress = "???";

        public int NumberOfTicketsToBuy { get => numberOfTicketsToBuy; set => numberOfTicketsToBuy = (value > 0 ? value : 1); }
        private int numberOfTicketsToBuy = 0;
        
        public double PricePerTicket { get => pricePerTicket; set => pricePerTicket = (value > 0 ? value : pricePerTicket); }
        private double pricePerTicket = 5.99;

        public double TotalPriceOfTickets => (numberOfTicketsToBuy > 0 ? numberOfTicketsToBuy * pricePerTicket : 0);

        public override string ToString()
        {
            return string.Format("Code: {0:d}; Name: {1:s}; Address: {2:s} Tickets: {3:N0}({4:c2})", BookingCode, customerName, customerAddress, numberOfTicketsToBuy, TotalPriceOfTickets);
        }
    }
}
