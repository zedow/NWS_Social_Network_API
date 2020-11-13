using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NWSocial.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(255)]
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public DateTime? DeadLine { get; set; }
        public string Description { get; set; }
        public bool isClosed { get; set; }
        public Guild Guild { get; set; }
        public int? GuildId { get; set; }
        public List<ProjectMember> Members { get; set; }
        public List<ProjectSlot> ProjectSlots { get; set; }
    }
}
