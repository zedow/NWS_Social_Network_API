using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NWSocial.Models
{
    public class UserBadge
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int BadgeId { get; set; }
        public Badge Badge { get; set; }
    }
}
