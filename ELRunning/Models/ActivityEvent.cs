using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace ELRunning.Models
{
    public class ActivityEvent
    {
        public Guid ActivityEventID { get; set; }
        [Required]
        [Display(Name = "Event Name", Prompt = "Your event name", Description = "Event Name")]
        public string EventName { get; set; }
        [Required]
        [Display(Name = "Start Date", Prompt = "The date your event becomes available", Description = "Start Date")]
        public DateTime StartDate { get; set; }
        [Display(Name = "End Date", Prompt = "The date your event closes", Description = "End Date")]
        public DateTime? EndDate { get; set; }
        public int Distance { get; set; }
        [Required]
        [Display(Prompt = "Enter the event description")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Activity Type", Prompt = "The type of the event", Description = "Activity Type")]
        public Guid EventTypeID { get; set; }
        public EventType EventType { get; set; }
        public virtual ICollection<ActivityLog> Logs { get; set; }
    }

    public class ActivityLog
    {
        public ActivityLog()
        {
            ActivityLogID = Guid.NewGuid();
            TimeLogged = DateTime.Now;
        }

        public Guid ActivityLogID { get; set; }
        public DateTime TimeLogged { get; set; }
        [DisplayFormat(DataFormatString = "{HH:mm:ss:ms}")]
        //[DataType(TimeSpan)]
        public TimeSpan Duration { get; set; }
        public int Units { get; set; }
        public Guid UserId { get; set; }
        public virtual AppUser User { get; set;}
        public virtual ActivityEvent Event { get; set; }

        internal object Select(Func<object, object> p)
        {
            throw new NotImplementedException();
        }
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