using NWSocial.Dtos;
using NWSocial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NWSocial.Data
{
    public interface INWSRepo
    {
        bool SaveChanges();
        IEnumerable<Guild> GetAllGuilds();
        Guild GetGuildById(int id);
        void CreateGuild(Guild guild);
        void UpdateGuild(Guild guild);
        void DeleteGuild(Guild guild);
        void AddUserGuild(UserGuild userGuild);

        User GetUserById(int id);

        // Posts
        IEnumerable<Post> GetAllPosts();
        Post GetPostById(int id);
        void CreatePost(Post post);
        void UpdatePost(Post post);
        void DeletePost(Post post);
        IEnumerable<Post> GetGuildPosts(int GuildId);
        IEnumerable<Post> GetGuildPost(int GuildId, int PostId);


        IEnumerable<UserGuild> GetGuildUsers(int idGuild);
        IEnumerable<UserGuild> GetUserGuilds(int idUser);
        void CreateUserGuildRequest(UserGuild userGuildRequest);
    }
}
