using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsManagementSystem
{
    public class Transaction
    {
        public enum TransactionType
        {
            Add=0,
            Update=1,
            Delete=2,
            Book=3,
            Cancel=4
        }

        public TransactionType Type { get; set; }

        public DateTime dateOfTransaction { get; set; } = DateTime.Now;

        public Transaction()
        {

        }
    }
}
