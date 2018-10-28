using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsManagementSystem.Models
{
    public class TransactionLog
    {
        private static int _PrevId { get; set; } = 999;
        public int TransactionId { get; private set; } = 1000;

        public enum TransType
        {
            Add=0,
            Update=1,
            Delete=2,
            Book=3,
            Cancel=4
        }

        public TransType Type { get; private set; } = TransType.Add;

        public DateTime DateOfTransaction { get; private set; } = DateTime.Now;

        public TransactionLog(TransType transactionType)
        {
            _PrevId++;
            TransactionId = _PrevId;

            Type = transactionType;
        }
    }
}
