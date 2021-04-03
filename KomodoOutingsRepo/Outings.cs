using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoOutingsRepo
{
    public enum EventType
    {
        Golf = 1,
        Bowling,
        AmusementPark,
        Concert
    }
    public class Outings
    {
        public int Attendence { get; set; }
        public EventType Type { get; set; }
        public DateTime Date { get; set; }
        public decimal EventCost { get; set; }
        public decimal CostPerPerson
        {
            get
            {
                decimal cpp = EventCost / Attendence;
                decimal total = Decimal.Round(cpp);
                return total;
            }
        }

        public Outings()
        {

        }

        public Outings( int people, EventType type, DateTime date, decimal cost)
        {
            Attendence = people;
            Type = type;
            Date = date;
            EventCost = cost;
        }
    }
}
