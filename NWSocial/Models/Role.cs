using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NWSocial.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(255)]
        public string RoleName { get; set; }
        public List<ProjectMember> ProjectMembers { get; set; }
    }
}
