using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NWSocial.Models
{
    public class ProjectMember
    {
        [Key]
        public int ProjectId { get; set; }
        public Project Project {get; set;}
        [Key]
        public int UserId { get; set; }
        public User User {get; set;}
        public string Role { get; set; }
    }
}
