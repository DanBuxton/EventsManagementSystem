using System;

namespace EventsManagementSystem.Models
{
    public class LogDetails
    {
        public string Action { get; set; }

        public string Details { get; set; }

        public DateTime DateOfTransaction { get; set; } = DateTime.Now;
    }
}
