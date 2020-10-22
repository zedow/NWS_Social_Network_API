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
            Guild guild = _context.Guilds.Where(g => g.Id == idGuild).FirstOrDefault();
            if(guild == null)
            {
                throw new ArgumentNullException(nameof(guild));
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
            User user = _context.Users.Where(u => u.Id == idUser).FirstOrDefault();
            if(user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            List<UserGuild> guilds = _context.UserGuilds.Where(g => g.UserId == idUser).ToList();
            List<Guild> guildList = new List<Guild>();
            foreach(UserGuild guild in guilds)
            {
                guildList.Add(GetGuildById(guild.GuildId));
            }
            return guildList;
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return (_context.Posts.ToList());
        }

        public Guild GetGuildById(int id)
        {
            return (_context.Guilds.FirstOrDefault(i => i.Id == id));
        }
        public Post GetPostById(int id)
        {
            return (_context.Posts.FirstOrDefault(i => i.Id == id));
        }

        public void CreatePost(Post post)
        {
            if (post == null)
            {
                throw new ArgumentNullException(nameof(post));
            }
            _context.Posts.Add(post);
        }


        public void DeletePost(Post post)
        {
            if (post == null)
            {
                throw new ArgumentNullException(nameof(post));
            }
            _context.Posts.Remove(post);
        }
        public void UpdatePost(Post post)
        {
            //Nothing
            //Géré par le controlleur, pas besoin pour le moment
        }
    }
}
