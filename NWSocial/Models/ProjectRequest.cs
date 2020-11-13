using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NWSocial.Models
{
    public class ProjectRequest
    {
        [Key]
        public int UserId { get; set; }
        public User User { get; set; }
        [Key]
        public int SlotId { get; set; }
        public ProjectSlot ProjectSlot { get; set; }
        public string Status { get; set; }
    }
}
