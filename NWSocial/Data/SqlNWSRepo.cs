using NWSocial.Dtos;
using NWSocial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NWSocial.Data
{
    public class SqlNWSRepo : INWSRepo
    {
        private readonly NWSContext _context;

        public SqlNWSRepo(NWSContext context)
        {
            _context = context;
        }

        public void CreateGuild(Guild guild)
        {
            if(guild == null)
            {
                throw new ArgumentNullException(nameof(guild));
            }
            _context.Guilds.Add(guild);
        }

        public void DeleteGuild(Guild guild)
        {
            if(guild == null)
            {
                throw new ArgumentNullException(nameof(guild));
            }
            _context.Guilds.Remove(guild);
        }

        public IEnumerable<Guild> GetAllGuilds()
        {
            return (_context.Guilds.ToList());
        }

        public Guild GetGuildById(int id)
        {
            return (_context.Guilds.FirstOrDefault(i => i.Id == id));
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateGuild(Guild guild)
        {
            //Nothing
            //Géré par le controlleur, pas besoin pour le moment
        }

        public IEnumerable<UserGuild> GetGuildUsers(int guildId)
        {
            Guild guild = _context.Guilds.Where(g => g.Id == guildId).FirstOrDefault();
            return (guild.UserGuilds);
        }

        public void AddUserGuild(UserGuild newUserGuild)
        {
            if (newUserGuild == null)
            {
                throw new ArgumentNullException(nameof(newUserGuild));
            }
            _context.UserGuilds.Add(newUserGuild);
        }

        List<User> INWSRepo.GetGuildUsers(int id)
        {

            throw new NotImplementedException();
        }

        public User GetUserById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
