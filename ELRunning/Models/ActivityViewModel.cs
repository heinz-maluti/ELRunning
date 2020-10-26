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
            ID = 0;
        }

        public bool AddTotal(EventTotal at)
        {
            EventTotal et = Totals.Where(x => x.Email == at.Email).FirstOrDefault();
            
            if (et!=null)
            {
                et.TotalUnits += at.TotalUnits;
            }
            else
            {
                this.Totals.Add(at);
            }
            return true;
        }

        public virtual ActivityEvent Event { get; set; }
        public List<EventTotal> Totals { get; set; }
    }

    public class EventTotal
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public int TotalUnits { get; set; }

        public EventTotal()
        {

        }

        public EventTotal(string email, int unit)
        {
            Email = email;
            TotalUnits = unit;
        }
    }
}
