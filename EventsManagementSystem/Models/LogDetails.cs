using System;

namespace EventsManagementSystem.Models
{
    public sealed class LogDetails
    {
        public string Action { get; set; }

        public string Details { get; set; }

        public DateTime DateOfTransaction { get; set; } = DateTime.Now;

        public LogDetails(string action, string details)
        {
            Action = action;
            Details = details;

            DateOfTransaction = DateTime.Now;
        }
    }
}
