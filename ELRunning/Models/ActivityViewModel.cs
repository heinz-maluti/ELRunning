using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELRunning.Models
{
    public class ActivityViewModel
    {
        public int ID { get; set; }
        public ActivityViewModel()
        {
            Totals = new List<EventTotal>();
            Duration = new List<TimeSpan>();
            ID = 0;
        }

        public bool AddTotal(EventTotal at)
        {
            EventTotal et = Totals.Where(x => x.Email == at.Email).FirstOrDefault();
            
            if (et!=null)
            {
                et.TotalUnits += at.TotalUnits;
                et.Duration = et.Duration.Add(at.Duration);
            }
            else
            {
                this.Totals.Add(at);
            }
            return true;
        }

        public virtual ActivityEvent Event { get; set; }
        public List<EventTotal> Totals { get; set; }
        public List<TimeSpan> Duration { get; set; }
    }

    public class EventTotal
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public int TotalUnits { get; set; }
        public TimeSpan Duration { get; set; }

        public EventTotal()
        {

        }

        public EventTotal(string email, int unit, TimeSpan duration)
        {
            Email = email;
            TotalUnits = unit;
            Duration = duration;
        }
    }
}
