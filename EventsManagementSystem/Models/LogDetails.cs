using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsManagementSystem.Models
{
    public class LogDetails
    {
        public string Action { get; set; } = "Add";

        public string Details { get; set; }

        public DateTime DateOfTransaction { get; protected internal set; } = DateTime.Now;
    }
}
