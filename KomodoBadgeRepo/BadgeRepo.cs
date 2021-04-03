using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadgeRepo
{
    public class BadgeRepo
    {
        Dictionary<int, Badges> badge = new Dictionary<int, Badges>();

        public void AddABadge(Badges badges)
        {
            badge.Add(badges.BadgeID, badges);
        }
        public void EditABadge(int id, bool remove, string door)
        {
            if (remove)
            {
                if (badge[id].Doors.Contains(door))
                {
                    badge[id].RemoveADoor(door);
                }
            }
            else
            {
                badge[id].AddADoor(door);
            }
        }

        public Dictionary<int, Badges> ShowBadges()
        {
            return badge;
        }
    }
}
