﻿using System;
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

        public enum TransType
        {
            Add = 0,
            Update = 1,
            Delete = 2,
            Book = 3,
            Cancel = 4
        }

        public TransType Action { get; set; } = TransType.Add;

        #region TransactionType
        public Event _eventDetails { get; set; }

        public int BookingCode { get; set; } = 1000;
        public int NumberOfTickes { get; set; } = 0;
        #endregion

        public DateTime DateOfTtansaction { get; } = DateTime.Now;
    }
}
