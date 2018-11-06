using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using EventsManagementSystem.Models;

namespace EventsManagementSystem
{
    public class Program
    {
        public static List<Event> Events { get; set; } = new List<Event>();
        public static List<Booking> Bookings { get; set; } = new List<Booking>();
        public static List<TransactionLog> Transactions { get; set; } = new List<TransactionLog>();

        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Gray;

            const int ADD_EVENT = 1;
            const int UPDATE_EVENT = 2;
            const int DELETE_EVENT = 3;

            const int BOOK_TICKET = 4;
            const int CANCEL_BOOKING = 5;

            const int LIST_EVENTS = 6;
            const int LIST_TRANSACTIONS = 7;

            const int EXIT = 8;

            int choice = DisplayMenu();

            Console.WriteLine(choice);

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
                        Console.WriteLine("Not an option");
                        break;
                }

                Console.WriteLine("\nPress any key to continue");
                Console.ReadKey();

                choice = DisplayMenu();
            }
        }

        #region Read Input
        private static void ReadCode(string str, out int id)
        {
            int eCode = -1;

            Console.Write($"{str} code (xxxx): ");
            int.TryParse(Console.ReadLine(), out eCode);

            while ((eCode < 1000) || (eCode > 10000))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Must be a number 4-digits long");
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.Write($"{str} code (xxxx): ");
                int.TryParse(Console.ReadLine(), out eCode);
            }

            id = eCode;
        }
        private static void ReadName(string str, out string name)
        {
            Console.Write($"{str} name: ");
            name = Console.ReadLine();
        }
        private static void ReadNumberOfTickets(out int num)
        {
            // 17
            int eNumTickets = -1;

            Console.Write("Number of tickets: ");
            int.TryParse(Console.ReadLine(), out eNumTickets);

            while (eNumTickets < 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Must be greater than 0");
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.Write("Number of tickets: ");
                int.TryParse(Console.ReadLine(), out eNumTickets);
            }

            num = eNumTickets;
        }
        private static void ReadPricePerTicket(out double price)
        {
            // 18
            Console.Write("Price of ticket: ");
            double.TryParse(Console.ReadLine(), out double ePricePerTicket);

            while (ePricePerTicket <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Must be greater than 0");
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.Write("Price of ticket: ");
                double.TryParse(Console.ReadLine(), out ePricePerTicket);
            }

            price = ePricePerTicket;
        }
        #endregion

        #region Events
        public static void AddAnEvent()
        {
            ReadCode("Event", out int eCode);
            ReadName("Event", out string eName);
            ReadNumberOfTickets(out int eNumTickets);
            ReadPricePerTicket(out double ePricePerTicket);

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
                    Action = TransactionLog.Type.Add,
                    _eventDetails = _event
                }
            );
        }

        public static void UpdateAnEvent()
        {
            ReadCode("Event", out int eCode);

            FindAnEvent(eCode, out Event e);

            if (e != null)
            {
                ReadName("Event", out string eName);
                ReadNumberOfTickets(out int eNumTickets);
                ReadPricePerTicket(out double ePricePerTicket);


                e.Name = eName;
                e.NumberOfTickets = eNumTickets;
                e.NumberOfTicketsAvaliable = eNumTickets;
                e.PricePerTicket = ePricePerTicket;

                Booking[] bookings = BookingsForEvent(e.EventCode);
                for (int i = 0; i < bookings.Length; i++)
                {
                    // Alter number of tickets
                }

                Transactions.Add(
                    new TransactionLog
                    {
                        Action = TransactionLog.Type.Update,
                        _eventDetails = e
                    }
                );
            }
            else
            {
                Console.WriteLine("No such event!");
            }
        }

        public static void DeleteAnEvent()
        {
            ReadCode("Event", out int eCode);

            Event _event = FindAnEvent(eCode);

            if (_event != null)
            {
                // Remove event
                Events.Remove(_event);

                Transactions.Add(
                    new TransactionLog
                    {
                        Action = TransactionLog.Type.Delete,
                        EventCode = eCode
                    }
                );
            }
            else
            {
                Console.WriteLine("No such event!");
            }
        }

        private static void FindAnEvent(int id, out Event e)
        {
            e = null;

            foreach (var ev in Events)
            {
                if (ev.EventCode == id)
                {
                    e = ev;
                    break;
                }
            }
        }
        private static Event FindAnEvent(int id)
        {
            Event e = null;

            foreach (var ev in Events)
            {
                if (ev.EventCode == id)
                {
                    e = ev;
                }
            }

            return e;
        }
        #endregion

        #region Bookings
        public static void BookTickets()
        {
            ReadCode("Booking", out int bCode);

            ReadCode("Event", out int eCode);

            FindAnEvent(eCode, out Event e);

            ReadName("Customer", out string cName);

            Console.Write("Customer address: ");
            string cAddress = Console.ReadLine();

            ReadNumberOfTickets(out int numOfTickets);

            while (numOfTickets > e.NumberOfTicketsAvaliable)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"There are only {e.NumberOfTicketsAvaliable} ticket{(e.NumberOfTicketsAvaliable > 1 ? "s" : "")} remaining");
                Console.ForegroundColor = ConsoleColor.Gray;

                ReadNumberOfTickets(out numOfTickets);
            }

            if (e != null)
            {
                // TODO: Validate
                e.NumberOfTicketsAvaliable -= numOfTickets;

                Booking b = new Booking
                {
                    BookingCode = bCode,
                    EventCode = eCode,
                    CustomerName = cName,
                    CustomerAddress = cAddress,
                    NumberOfTicketsToBuy = numOfTickets,
                    PricePerTicket = e.PricePerTicket
                };

                Bookings.Add(b);

                Transactions.Add(
                    new TransactionLog
                    {
                        Action = TransactionLog.Type.Book,
                        BookType = new BookType { EventCode = eCode, BookingCode = bCode, NumOfTickets = numOfTickets }
                    }
                );
            }
        }

        public static void CancelBooking()
        {
            ReadCode("Booking", out int bCode);

            Booking b = GetBooking(bookingCode: bCode);

            if (b != null)
            {
                FindAnEvent(b.EventCode, out Event e);

                e.NumberOfTicketsAvaliable += b.NumberOfTicketsToBuy;

                Bookings.Remove(b);

                Transactions.Add(new TransactionLog
                {
                    Action = TransactionLog.Type.Cancel,
                    CancelType = new CancelType { BookingCode = bCode, NumOfTickets = b.NumberOfTicketsToBuy }
                }
                );
            }
        }

        private static Booking GetBooking(int bookingCode)
        {
            try
            {
                return Bookings.Where(b => b.BookingCode == bookingCode).ToArray()[0];
            }
            catch (Exception)
            {
                return null;
            }
        }
        private static void GetBooking(int bookingCode, out Booking booking)
        {
            try
            {
                booking = Bookings.Where(b => b.BookingCode == bookingCode).ToArray()[0];
            }
            catch (Exception)
            {
                booking = null;
            }
        }

        private static Booking[] BookingsForEvent(int id)
        {
            return Bookings?.Where(b => b.EventCode == id).ToArray();
        }
        #endregion

        #region Display
        public static void DisplayAllEvents()
        {
            Console.WriteLine();

            if (Events.Count > 0)
            {
                for (int i = 0; i < Events.Count; i++)
                {
                    Event e = Events[i];

                    Booking[] bookings = BookingsForEvent(e.EventCode);

                    Console.WriteLine(e);

                    Console.WriteLine();
                    Console.WriteLine("\tBookings:");

                    if ((bookings != null) && (bookings.Length > 0))
                    {
                        for (int b = 0; b < bookings.Length; b++)
                        {
                            Booking book = bookings[b];

                            Console.Write($"\t({book.BookingCode})\nTickets:\t{book.NumberOfTicketsToBuy}\n");
                            Console.Write($"Price:\t\t{book.Price}\n");
                            Console.Write($"Price:\t\t{book.Price}\n");
                            Console.Write($"Price:\t\t{book.Price}\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\tN/A");
                    }
                }
            }
            else
            {
                Console.WriteLine("No events");
            }
        }

        public static void DisplayTransactions()
        {
            Console.WriteLine();

            if (Transactions.Count > 0)
            {
                for (int i = 0; i < Transactions.Count; i++)
                {
                    Console.WriteLine($"Date:\t{Transactions[i].DateOfTransaction}");
                    Console.WriteLine($"Type:\t{Transactions[i].Action}");

                    switch (Transactions[i].Action)
                    {
                        case TransactionLog.Type.Add:
                            Console.WriteLine(Transactions[i]._eventDetails);
                            break;
                        case TransactionLog.Type.Update:
                            Console.WriteLine(Transactions[i]._eventDetails);
                            break;
                        case TransactionLog.Type.Delete:
                            Console.WriteLine(Transactions[i].EventCode);
                            break;
                        case TransactionLog.Type.Book:
                            Console.WriteLine(Transactions[i].BookType);
                            break;
                        case TransactionLog.Type.Cancel:
                            Console.WriteLine(Transactions[i].CancelType);
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("No transactions");
            }
        }
        #endregion

        public static int DisplayMenu()
        {
            Console.Clear();

            Console.WriteLine("\n1\t- Add an event");
            Console.WriteLine("2\t- Update an event");
            Console.WriteLine("3\t- Delete an event\n");

            Console.WriteLine("4\t- Book tickets");
            Console.WriteLine("5\t- Cancel booking\n");

            Console.WriteLine("6\t- Display all events");
            Console.WriteLine("7\t- Display all transactions\n");

            Console.WriteLine("8\t- Exit");


            Console.WriteLine();
            Console.Write("choice > ");

            char.TryParse(Console.ReadLine(), out char opt);

            while ((opt < 48) || (opt > 57))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Only numbers are allowed!");
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.WriteLine();
                Console.Write("choice > ");

                char.TryParse(Console.ReadLine(), out opt);
            }

            return Convert.ToInt32(opt.ToString());
        }
    }
}
