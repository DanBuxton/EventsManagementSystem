using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsManagementSystem.Models
{
    public class TransactionLog
    {
        public int TransactionId { get; set; }

        public enum TransType
        {
            Add=0,
            Update=1,
            Delete=2,
            Book=3,
            Cancel=4
        }

        public TransType Type { get; set; }

        public DateTime dateOfTransaction { get; set; } = DateTime.Now;

        public TransactionLog(TransType transactionType)
        {
            Type = transactionType;
        }
    }
}
