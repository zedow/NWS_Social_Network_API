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
        IEnumerable<Guild> GetAllGuilds(string filter, int? indexPage, int? numberPerPage = 10);
        Guild GetGuildById(int id);
        void CreateGuild(Guild guild);
        void UpdateGuild(Guild guild);
        void DeleteGuild(Guild guild);
        void AddUserGuild(UserGuild userGuild);

        User GetUserById(int id);

        // Posts
        IEnumerable<Post> GetAllPosts(string filter, int? idGuild, int? indexPage, int? numberPerPage = 10);
        Post GetPostById(int id);
        void CreatePost(Post post);
        void UpdatePost(Post post);
        void DeletePost(Post post);

        IEnumerable<Post> GetUserPosts(int id, string filter, int? indexPage, int? numberPerPage);

        //UserGuild
        IEnumerable<UserGuild> GetGuildUsers(int idGuild);
        UserGuild GetGuildUser(int idGuild, int idUser);
        void UpdateUserGuild(UserGuild userGuild);
        IEnumerable<UserGuild> GetUserGuilds(int idUser);
        void CreateUserGuildRequest(UserGuild userGuildRequest);
        void RemoveUserFromGuild(UserGuild userGuild);

        // Projects functions

        // Sylvio
        IEnumerable<Project> GetProjects(string filter, string role, int? guildId, int? indexPage, int? numberPerPage = 10);

        // Valentin
        IEnumerable<ProjectMember> GetProjectMembers(int projectId);
        IEnumerable<Project> GetUserProjects(int userId, string filter, string role, bool? isClosed, int? guildId, int? indexPage, int? numberPerPage = 10);

        // Sylvio
        void AddProject(Project project);
        void RemoveProject(Project project);
        void UpdateProject(Project project);

        // Valentin
        Project GetProject(int projectId);

        ProjectMember GetProjectMember(int projectId, int userId);
        void RemoveProjectMember(ProjectMember projectMember);
        void AddProjectMember(ProjectMember projectMember);
        void AddProjectRequest(ProjectRequest pr);
        void AddProjectSlot(ProjectSlot slot);
        void AddProjectSlots(IEnumerable<ProjectSlot> slots);
        void RemoveProjectSlot(ProjectSlot slot);
        IEnumerable<ProjectSlot> GetProjectSlots(int projectId);
        IEnumerable<ProjectRequest> GetProjectSlotRequests(int slotId);
        ProjectRequest GetProjectRequest(int userId, int slotId);
        void UpdateProjectRequest(ProjectRequest pr,int projectId);
    }
}
