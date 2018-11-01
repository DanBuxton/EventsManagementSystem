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
        public static List<Event> Events { get; set; } = new List<Event>();
        public static Queue<Booking> Bookings { get; set; } = new Queue<Booking>();
        public static List<TransactionLog> Transactions { get; set; } = new List<TransactionLog>();

        public static void Main(string[] args)
        {
            const int ADD_EVENT = 1;
            const int UPDATE_EVENT = 2;
            const int DELETE_EVENT = 3;

            const int BOOK_TICKET = 4;
            const int CANCEL_BOOKING = 5;

            const int LIST_EVENTS = 6;
            const int LIST_TRANSACTIONS = 7;

            const int EXIT = 8;

            int choice = DisplayMenu();

            while (choice != EXIT)
            {
                switch (choice)
                {
                    case ADD_EVENT:
                        AddAnEvent();
                        break;
                    case UPDATE_EVENT:
                        UpdateAnEvent();
                        break;
                    case DELETE_EVENT:
                        DeleteAnEvent();
                        break;
                    case BOOK_TICKET:
                        BookTickets();
                        break;
                    case CANCEL_BOOKING:
                        CancelBooking();
                        break;
                    case LIST_EVENTS:
                        DisplayAllEvents();
                        break;
                    case LIST_TRANSACTIONS:
                        DisplayTransactions();
                        break;
                    default:
                        break;
                }

                choice = DisplayMenu();
            }
        }

        #region Events
        public static void AddAnEvent()
        {
            Console.Write("Event code (xxxx): ");
            int.TryParse(Console.ReadLine(), out int eCode);

            Console.Write("Event name: ");
            string eName = Console.ReadLine();

            Console.Write("Number of tickets: ");
            int.TryParse(Console.ReadLine(), out int eNumTickets);

            Console.Write("Price of ticket: ");
            double.TryParse(Console.ReadLine(), out double ePricePerTicket);

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
                    Action = TransactionLog.TransType.Add,
                    _eventDetails = _event
                }
            );
        }

        public static void UpdateAnEvent()
        {
            Console.Write("Event code (xxxx): ");
            int.TryParse(Console.ReadLine(), out int eCode);

            if (FindAnEvent(eCode) != null)
            {
                Console.Write("Event name: ");
                string eName = Console.ReadLine();

                Console.Write("Number of tickets: ");
                int.TryParse(Console.ReadLine(), out int eNumTickets);

                Console.Write("Price of ticket: ");
                double.TryParse(Console.ReadLine(), out double ePricePerTicket);

                Event _event = new Event
                {
                    EventCode = eCode,
                    Name = eName,
                    NumberOfTickets = eNumTickets,
                    NumberOfTicketsAvaliable = eNumTickets,
                    PricePerTicket = ePricePerTicket
                };
            }
            else
            {
                Console.WriteLine("No such event!");
            }
        }

        public static void DeleteAnEvent()
        {
            Console.Write("Event code (xxxx): ");
            int.TryParse(Console.ReadLine(), out int eCode);

            Event _event = FindAnEvent(eCode);

            if (_event != null)
            {
                Events.Remove(_event);

                Transactions.Add(
                    new TransactionLog
                    {
                        Action = TransactionLog.TransType.Delete,
                        _eventDetails = new Event { EventCode = eCode }
                    }
                );
            }
            else
            {
                Console.WriteLine("No such event!");
            }
        }

        private static Event FindAnEvent(int id)
        {
            Event _event = null;

            foreach (var e in Events)
            {
                if (e.EventCode == id)
                {
                    _event = e;
                }
            }

            return _event;
        }
        #endregion

        #region Bookings
        public static void BookTickets()
        {

        }

        public static void CancelBooking()
        {

        }
        #endregion

        #region Display
        public static void DisplayAllEvents()
        {
            foreach (Event e in Events)
            {
                Console.WriteLine(e);
            }
        }

        public static void DisplayTransactions()
        {

        }
        #endregion

        public static int DisplayMenu()
        {
            int opt = 0;

            do
            {
                opt = 0;

                //Console.Clear();

                Console.WriteLine("1\t- Add an event");
                Console.WriteLine("2\t- Update an event");
                Console.WriteLine("3\t- Delete an event");
                Console.WriteLine();
                Console.WriteLine("4\t- Book tickets");
                Console.WriteLine("5\t- Cancel booking");
                Console.WriteLine();
                Console.WriteLine("6\t- Display events");
                Console.WriteLine("7\t- Display transactions");
                Console.WriteLine();
                Console.WriteLine("8\t- Exit");

                int.TryParse(Console.ReadLine(), out opt);
            } while (opt == 0);

            return opt;
        }
    }
}
