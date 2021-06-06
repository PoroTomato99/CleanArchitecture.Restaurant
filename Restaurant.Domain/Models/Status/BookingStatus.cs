using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Models.Status
{
    public class BookingStatus
    {
        public const string Pending = "Pending";
        public const string Reserved = "Reserved";
        public const string Rejected = "Rejected";
        public const string Completed = "Completed";
        public const string Cancelled = "Cancelled";

        public static List<string> InititalStatus()
        {
            return new List<string>()
            {
                Pending,
                Reserved,
                Rejected,
                Completed,
                Cancelled
            };
        }
    }
}
