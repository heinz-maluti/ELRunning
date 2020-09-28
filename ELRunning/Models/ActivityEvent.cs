using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELRunning.Models
{
    public class ActivityEvent
    {
        public Guid ActivityEventID { get; set; }
        public string EventName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Distance { get; set; }
        public virtual EventType EventType { get; set; }

        public virtual ICollection<ActivityLog> Logs { get; set; }
    }

    public class ActivityLog
    {
        public Guid ActivityLogID { get; set; }
        public DateTime TimeLogged { get; set; }
        public int Units { get; set; }
        public virtual AppUser User { get; set;}
        public virtual ActivityEvent Event { get; set; }
    }

    public class EventType
    {
        public Guid EventTypeID { get; set; }
        public string TypeName { get; set; }
        public string UnitType { get; set; }

        public virtual ICollection<ActivityEvent> Events { get; set; }
        public virtual ICollection<ActivityLog> Logs { get; set; }
    }
}