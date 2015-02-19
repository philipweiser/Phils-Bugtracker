using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTracker_The_Reckoning.Models
{
    public class TypePriorityStatus
    {
        public IPagedList<TicketPriority> priorities { get; set; }
        public IPagedList<TicketStatus> statuses { get; set; }
        public IPagedList<TicketType> types { get; set; }
    }
}