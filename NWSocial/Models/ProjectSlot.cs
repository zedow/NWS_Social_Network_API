using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NWSocial.Models
{
    public class ProjectSlot
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(255)]
        public string Role { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public ProjectMember ProjectMember { get; set; }
        public List<ProjectRequest> ProjectRequests { get; set; }
    }

    public class ProjectSlotStatus : ProjectSlot
    {
        public User TakenBy { get; set; }
    }
}
