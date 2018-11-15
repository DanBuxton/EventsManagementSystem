using System;
using System.Collections;
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
        public static ArrayList Events { get; set; } = new ArrayList();
        public static BookingLinkedListNode Bookings { get; set; }
        public static ArrayList TransactionLog { get; set; } = new ArrayList();

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
                        DisplayAllEvents();
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
        private static void ReadCode(string str, out int id, int len = 4)
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
        private static void ReadName(string str, out string name, int maxLength /*= 40*/, int minLength = 4)
        {
            Console.Write($"{str} name: ");
            name = Console.ReadLine();

            while ((name.Length < minLength) || (name.Length > maxLength))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Must be between {minLength} and {maxLength} characters long");
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.Write($"{str} name: ");
                name = Console.ReadLine();
            }
        }
        private static void ReadNumberOfTickets(out int num)
        {
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
            ReadName(str: "Event", name: out string eName, maxLength: 50);
            ReadNumberOfTickets(out int eNumTickets);
            ReadPricePerTicket(out double ePricePerTicket);

            EventDetails _event = new EventDetails
            {
                EventCode = eCode,
                Name = eName,
                NumberOfTickets = eNumTickets,
                NumberOfTicketsAvaliable = eNumTickets,
                PricePerTicket = ePricePerTicket
            };

            Events.Add(_event);

            TransactionLog.Add(
                new LogDetails
                {
                    Action = LogDetails.Type.Add,
                    EventDetails = _event
                }
            );
        }

        public static void UpdateAnEvent()
        {
            ReadCode("Event", out int eCode);
            FindAnEvent(eCode, out EventDetails e);

            ReadName(str: "Event", name: out string eName, maxLength: 50);

            int eNumTickets = -1;

            Console.Write("Number of tickets to add: ");
            int.TryParse(Console.ReadLine(), out eNumTickets);

            while (eNumTickets < 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Must be greater than 0");
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.Write("Number of tickets: ");
                int.TryParse(Console.ReadLine(), out eNumTickets);
            }

            ReadPricePerTicket(out double ePricePerTicket);

            if (e != null)
            {
                e.Name = eName;
                e.NumberOfTickets += eNumTickets;
                e.NumberOfTicketsAvaliable += eNumTickets;
                e.PricePerTicket = ePricePerTicket;
                e.DateUpdated = DateTime.Now;

                BookingDetails[] bookings = BookingsForEvent(e.EventCode);
                for (int i = 0; i < bookings.Length; i++)
                {
                    // Alter number of tickets
                }

                TransactionLog.Add(
                    new LogDetails
                    {
                        Action = LogDetails.Type.Update,
                        EventDetails = e
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
            FindAnEvent(eCode, out EventDetails e);

            if (e != null)
            {
                // Remove event
                Events.Remove(e);

                // Remove bookings

                BookingDetails[] books = BookingsForEvent(e.EventCode);
                foreach (BookingDetails b in books)
                {
                    DeleteBooking(b);
                }

                TransactionLog.Add(
                    new LogDetails
                    {
                        Action = LogDetails.Type.Delete,
                        EventCode = e.EventCode
                    }
                );
            }
            else
            {
                Console.WriteLine("No such event!");
            }
        }

        private static void FindAnEvent(int id, out EventDetails e)
        {
            e = null;

            foreach (EventDetails ev in Events)
            {
                if (ev.EventCode == id)
                {
                    e = ev;
                    break;
                }
            }
        }
        #endregion

        #region Bookings
        public static void BookTickets()
        {
            ReadCode("Event", out int eCode);
            ReadName(str: "Customer", name: out string cName, maxLength: 50);

            Console.Write("Customer address: ");
            string cAddress = Console.ReadLine();

            ReadNumberOfTickets(out int numOfTickets);
            FindAnEvent(eCode, out EventDetails e);

            if (e != null && e.NumberOfTicketsAvaliable > 0)
            {
                while (numOfTickets > e.NumberOfTicketsAvaliable)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"There is only {e.NumberOfTicketsAvaliable} ticket{(e.NumberOfTicketsAvaliable > 1 ? "s" : "")} remaining");
                    Console.ForegroundColor = ConsoleColor.Gray;

                    ReadNumberOfTickets(out numOfTickets);
                }

                e.NumberOfTicketsAvaliable -= numOfTickets;

                BookingDetails b = new BookingDetails
                {
                    //BookingCode = bCode,
                    EventCode = e.EventCode,
                    CustomerName = cName,
                    CustomerAddress = cAddress,
                    NumberOfTicketsToBuy = numOfTickets,
                    PricePerTicket = e.PricePerTicket
                };

                AddBooking(
                    new BookingLinkedListNode
                    {
                        Data = b
                    }
                );

                TransactionLog.Add(
                    new LogDetails
                    {
                        Action = LogDetails.Type.Book,
                        BookType = new BookType { EventCode = e.EventCode, BookingCode = b.BookingCode, NumOfTickets = numOfTickets }
                    }
                );
            }
            else
            {
                // No event
                Console.WriteLine();
            }
        }

        public static void CancelBooking()
        {
            ReadCode("Booking", out int bCode);

            BookingDetails b = GetBooking(bookingCode: bCode);

            if (b != null)
            {
                FindAnEvent(b.EventCode, out EventDetails e);

                e.NumberOfTicketsAvaliable += b.NumberOfTicketsToBuy;

                DeleteBooking(b);

                TransactionLog.Add(new LogDetails
                {
                    Action = LogDetails.Type.Cancel,
                    CancelType = new CancelType { BookingCode = bCode, NumOfTickets = b.NumberOfTicketsToBuy }
                }
                );
            }
            else
            {
                // No booking
            }
        }

        public static void AddBooking(BookingLinkedListNode newBooking)
        {
            BookingLinkedListNode current = Bookings, prev = current;

            while (current != null && current.Data.DateAdded < newBooking.Data.DateAdded)
            {
                prev = current;
                current = prev.NextNode;
            }

            if (current == prev)
            {
                // New head
                newBooking.NextNode = Bookings;
                Bookings = newBooking;
            }
            else if (current == null)
            {
                // New tail
                prev.NextNode = newBooking;
            }
            else
            {
                newBooking.NextNode = current;
                prev.NextNode = newBooking;
            }
        }
        public static void DeleteBooking(BookingDetails b)
        {
            BookingLinkedListNode current = Bookings, prev = current;

            while (current != null && current.Data.BookingCode != b.BookingCode)
            {
                prev = current;
                current = prev.NextNode;
            }

            if (current != null)
            {
                if (current == prev)
                {
                    // Delete head
                    Bookings = current.NextNode;
                }
                else
                {
                    prev.NextNode = current.NextNode;
                }
            }
        }

        private static BookingDetails GetBooking(int bookingCode)
        {
            try
            {
                BookingLinkedListNode current = Bookings;

                while (current != null && current.Data.BookingCode != bookingCode)
                {
                    current = current.NextNode;
                }

                return (current.Data.BookingCode == bookingCode ? current.Data : null);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private static BookingDetails[] BookingsForEvent(int id)
        {
            Queue<BookingDetails> bookings = new Queue<BookingDetails>();

            BookingLinkedListNode current = Bookings;

            while (current != null)
            {
                if (current.Data.EventCode == id)
                {
                    bookings.Enqueue(current.Data);
                }

                current = current.NextNode;
            }

            return bookings.ToArray();
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
                    EventDetails e = Events[i] as EventDetails;
                    BookingDetails[] bookings = BookingsForEvent(e.EventCode);

                    Console.WriteLine("Event(s):");
                    Console.WriteLine("\t" + e);

                    Console.WriteLine();

                    if ((bookings != null) && (bookings.Length > 0))
                    {
                        Console.WriteLine($"\tBookings: ({bookings.Length})");

                        for (int b = 0; b < bookings.Length; b++)
                        {
                            Console.WriteLine();

                            Console.Write("\t\tRef: " + bookings[b].BookingCode + Environment.NewLine);
                            Console.Write("\t\t\tCustomer name: " + bookings[b].CustomerName + Environment.NewLine);
                            Console.Write("\t\t\tAddress: " + bookings[b].CustomerAddress + Environment.NewLine);
                            Console.Write("\t\t\tNumber of tickets: " + bookings[b].NumberOfTicketsToBuy + Environment.NewLine);
                            Console.Write("\t\t\tPrice: {0:c}" + Environment.NewLine, bookings[i].Price);
                        }
                    }
                    else
                    {
                        Console.WriteLine("\tNo bookings");
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
            if (TransactionLog.Count > 0)
            {
                for (int i = 0; i < TransactionLog.Count; i++)
                {
                    LogDetails t = TransactionLog[i] as LogDetails;

                    Console.WriteLine($"\nDate:\t{t.DateOfTransaction}");
                    Console.WriteLine($"Type:\t{t.Action}");

                    switch (t.Action)
                    {
                        case LogDetails.Type.Add:
                            Console.WriteLine(t.EventDetails);
                            break;
                        case LogDetails.Type.Update:
                            Console.WriteLine(t.EventDetails);
                            break;
                        case LogDetails.Type.Delete:
                            Console.WriteLine(t.EventCode);
                            break;
                        case LogDetails.Type.Book:
                            Console.WriteLine(t.BookType);
                            break;
                        case LogDetails.Type.Cancel:
                            Console.WriteLine(t.CancelType);
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("No TransactionLog");
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
            Console.WriteLine("7\t- Display all TransactionLog\n");

            Console.WriteLine("8\t- Exit");

            Console.WriteLine();
            Console.Write("choice > ");

            char.TryParse(Console.ReadLine(), out char opt);

            while ((opt < 48) || (opt > 57))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Only positive numbers are allowed!");
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.WriteLine();
                Console.Write("choice > ");

                char.TryParse(Console.ReadLine(), out opt);
            }

            return Convert.ToInt32(opt.ToString());
        }
    }
}
