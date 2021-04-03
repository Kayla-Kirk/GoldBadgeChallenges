using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadgeRepo
{
    public class Badges
    {
        public int BadgeID { get; set; }
        public List<string> Doors { get; set; }
        public string Name { get; set; }

        public Badges(int id, List<string> doors)
        {
            BadgeID = id;
            Doors = doors;
        }

        public void RemoveADoor (string door)
        {
            Doors.Remove(door);
        }

        public void AddADoor (string door)
        {
            Doors.Add(door);
        }
    }
}
