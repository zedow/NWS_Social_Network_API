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

        public void AddUserGuild(UserGuild newUserGuild)
        {
            if (newUserGuild == null)
            {
                throw new ArgumentNullException(nameof(newUserGuild));
            }
            _context.UserGuilds.Add(newUserGuild);
        }

        public User GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        // Get list of users from Guild id
        public IEnumerable<User> GetGuildUsers(int idGuild)
        {
            bool isGuild = _context.Guilds.Any(g => g.Id == idGuild);
            if(!isGuild)
            {
                throw new ArgumentNullException(nameof(isGuild));
            }
            List<UserGuild> users = _context.UserGuilds.Where(u => u.GuildId == idGuild).ToList();
            List<User> guildUsers = new List<User>();
            foreach (UserGuild user in users)
            {
                guildUsers.Add(GetUserById(user.UserId));
            }
            return guildUsers;
        }

        // Get list of guilds from User id
        public IEnumerable<Guild> GetUserGuilds(int idUser)
        {
            bool isUser = _context.Users.Any(u => u.Id == idUser);
            if(!isUser)
            {
                throw new ArgumentNullException(nameof(isUser));
            }
            List<UserGuild> guilds = _context.UserGuilds.Where(g => g.UserId == idUser).ToList();
            List<Guild> guildList = new List<Guild>();
            guilds.ForEach(g => guildList.Add(GetGuildById(g.GuildId)));
            return guildList;
        }

        // Create a request for an user to enter a guild
        public void CreateUserGuildRequest(UserGuild userGuildRequest)
        {
            if(userGuildRequest == null)
            {
                throw new ArgumentNullException(nameof(userGuildRequest));
            }
            _context.UserGuilds.Add(userGuildRequest);
        }
    }
}
