using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsManagementSystem.Models
{
    public class LogDetails
    {
        public enum Type
        {
            Add = 0,
            Update = 1,
            Delete = 2,
            Book = 3,
            Cancel = 4
        }

        public Type Action { get; set; } = Type.Add;

        public string Details;

        #region TransactionType
        //public EventDetails EventDetails { get; set; }
        //public int EventCode { get; set; }
        //public BookType BookType { get; set; }
        //public CancelType CancelType { get; set; }
        #endregion

        public DateTime DateOfTransaction { get; protected internal set; } = DateTime.Now;
    }
}
