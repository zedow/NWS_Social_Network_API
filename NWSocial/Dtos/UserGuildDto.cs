using System.ComponentModel.DataAnnotations;


namespace NWSocial.Dtos
{
    public class UserGuildDto
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int GuildId { get; set; }
    }
}
