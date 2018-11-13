using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsManagementSystem.Models
{
    public class TransactionLog
    {
        //private int transactionId = 1000;
        //public int TransactionId
        //{
        //    get => transactionId;

        //    set
        //    {
        //        if (value > 999) transactionId = value;
        //    }
        //}

        public enum Type
        {
            Add = 0,
            Update = 1,
            Delete = 2,
            Book = 3,
            Cancel = 4
        }

        public Type Action { get; set; } = Type.Add;

        #region TransactionType
        public Event EventDetails { get; set; }
        public int EventCode { get; set; }

        public BookType BookType { get; set; }
        public CancelType CancelType { get; set; }
        #endregion

        public DateTime DateOfTransaction { get; } = DateTime.Now;
    }
}
