using Microsoft.EntityFrameworkCore;
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
            var guilds = _context.Guilds.Include(guild => guild.Users).ToList();
            return (guilds);
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
            return (_context.Users.FirstOrDefault(u => u.Id == id));
        }

        // Get list of users from Guild id
        public IEnumerable<UserGuild> GetGuildUsers(int idGuild)
        {
            List<UserGuild> users = _context.UserGuilds.Include(u => u.User).Where(g => g.GuildId == idGuild).ToList();
            return users;
        }

        // Get list of guilds from User id
        public IEnumerable<UserGuild> GetUserGuilds(int idUser)
        {
            List<UserGuild> guilds = _context.UserGuilds.Include(u => u.Guild).Where(g => g.UserId == idUser).ToList();
            return guilds;
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

        public UserGuild GetGuildUser(int idGuild, int idUser)
        {
            var userGuild = _context.UserGuilds.FirstOrDefault(u => (u.UserId == idUser && u.GuildId == idGuild));
            if (userGuild == null)
            {
                throw new ArgumentNullException(nameof(userGuild));
            }
            return userGuild;
        }

        public void UpdateUserGuild(UserGuild userGuild)
        {
            // 
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

        public IEnumerable<Post> GetGuildPosts(int GuildId)
        {
            return (_context.Posts.Where(g => g.GuildId == GuildId));
        }

    }
}
