using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EventsManagementSystem.Models;

namespace EventsManagementSystem
{
    public class Program
    {
        public List<Event> Events { get; set; } = new List<Event>();
        public Queue<Booking> Bookings { get; set; } = new Queue<Booking>();
        public List<TransactionLog> Transactions { get; set; } = new List<TransactionLog>();

        public static void Main(string[] args)
        {

        }

        public void AddAnEvent()
        {
            int eCode = 0000, eNumTickets = 0;
            double ePricePerTicket = 0;
            string eName = "";

            Console.Write("Event code (xxxx): ");


            Event _event = new Event
            {
                EventCode = eCode,
                Name = eName,
                NumberOfTickets = eNumTickets,
                NumberOfTicketsAvaliable = eNumTickets,
                PricePerTicket = ePricePerTicket
            };

            Events.Add(_event);

            Transactions.Add(
                new TransactionLog
                {
                    Action = TransactionLog.TransType.Add
                }
            );
        }

        public void UpdateAnEvent(Event _event)
        {

        }

        public void DeleteAnEvent(Event _event)
        {
            if (Events.First(e => e.EventCode == _event.EventCode) != null)
            {
                Events.Remove(_event);

                Transactions.Add(
                    new TransactionLog
                    {
                        Action = TransactionLog.TransType.Delete
                    }
                );
            }
        }

        private Event FindAnEvent(int id)
        {
            Event e = null;



            return e;
        }

        public void BookTickets()
        {

        }

        public void CancelBooking()
        {

        }

        public void DisplayAllEvents()
        {
            foreach (Event e in Events)
            {
                Console.WriteLine(e);
            }
        }

        public void DisplayTransactionLog()
        {

        }
    }
}
