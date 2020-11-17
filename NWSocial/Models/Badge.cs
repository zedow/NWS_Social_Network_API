using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NWSocial.Models
{
    public class Badge
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Caption { get; set; }
        public UserBadge UserBadge { get; set; }
        public List<UserBadge> UserBadges { get; set; }
    }
}
