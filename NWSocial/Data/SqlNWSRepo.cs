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
            if (guild == null)
            {
                throw new ArgumentNullException(nameof(guild));
            }
            _context.Guilds.Add(guild);
        }

        public void DeleteGuild(Guild guild)
        {
            if (guild == null)
            {
                throw new ArgumentNullException(nameof(guild));
            }
            _context.Guilds.Remove(guild);
        }

        public IEnumerable<Guild> GetAllGuilds(string filter, int? indexPage, int? numberPerPage = 10)
        {
            IQueryable<Guild> guilds = _context.Guilds;
            if (filter != null)
            {
                guilds = guilds.Where(g => g.Name.Contains(filter) || g.Description.Contains(filter));
            }
            if (indexPage.HasValue)
            {
                guilds = guilds.Skip((indexPage.Value - 1) * numberPerPage.Value).Take(numberPerPage.Value);
            }
            return (guilds.ToList());
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

        public void RemoveUserFromGuild(UserGuild userGuild)
        {
            if (userGuild == null)
            {
                throw new NullReferenceException(nameof(userGuild));
            }
            _context.UserGuilds.Remove(userGuild);
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
            List<UserGuild> users = _context.UserGuilds.Include(u => u.User).Where(g => g.GuildId == idGuild).Include(ug => ug.User).ToList();
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
            if (userGuildRequest == null)
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

        public IEnumerable<Post> GetAllPosts(string filter, int? guildId, int? indexPage, int? numberPerPage = 10)
        {
            IQueryable<Post> posts;
            if (guildId.HasValue)
            {
                posts = _context.Posts.Where(p => p.GuildId == guildId);
            }
            else
            {
                posts = _context.Posts.Where(g => g.GuildId == null);
            }
            if (filter != null)
            {
                posts = posts.Where(p => p.Title.Contains(filter) || p.Text.Contains(filter));
            }
            if (indexPage.HasValue)
            {
                posts = posts.Skip((indexPage.Value - 1) * numberPerPage.Value).Take(numberPerPage.Value);
            }
            return (posts.ToList());
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
            //Si nécessaire de faire du traitement supplémentaire
            // Exemple : Si le nom du poste est à update dans une table archive
        }

        // Projects functions
        public IEnumerable<Project> GetProjects(string filter, string role, int? guildId, int? indexPage, int? numberPerPage = 10)
        {
            IQueryable<Project> projects;
            if (guildId.HasValue)
            {
                projects = _context.Projects.Where(p => p.GuildId == guildId);
            }
            else
            {
                projects = _context.Projects.Where(g => g.GuildId == null);
            }
            if (filter != null)
            {
                projects = projects.Where(p => p.Name.Contains(filter) || p.Description.Contains(filter));
            }
            if(role != null)
            {
                projects = (from p in projects
                            join pm in _context.ProjectMembers.Where(pm => pm.Role.Contains(role)) on p.Id equals pm.ProjectId into resultJoin

                            from ppm in resultJoin
                            select new Project
                            {
                                Id = p.Id,
                                Name = p.Name,
                                Description = p.Description,
                                Date = p.Date,
                                DeadLine = p.DeadLine
                            });
            }
            if (indexPage.HasValue)
            {
                projects = projects.Skip((indexPage.Value - 1) * numberPerPage.Value).Take(numberPerPage.Value);
            }
            return (projects.ToList());
        }

        public void AddProject(Project project)
        {
            if (project == null)
            {
                throw new ArgumentNullException(nameof(project));
            }
            _context.Projects.Add(project);
        }

        public void RemoveProject(Project project)
        {
            if (project == null)
            {
                throw new NullReferenceException(nameof(project));
            }
            _context.Projects.Remove(project);
        }
        public void UpdateProject(Project project)
        {
            //
        }

        public IEnumerable<ProjectMember> GetProjectMembers(int projectId)
        {
            return _context.ProjectMembers.Where(pm => pm.ProjectId == projectId).Include(p => p.Project).Include(p => p.User).ToList();
        }

        // Permet de trier (par Nom, Description, ou rôle dans le projet), project clos ou non, projet d'une guilde, et pagination
        public IEnumerable<Project> GetUserProjects(int userId, string filter,bool? isClosed, int ? guildId, int? indexPage, int? numberPerPage = 10)
        {
            var model = (
                    from pm in (
                        (filter != null) 
                            ?  _context.ProjectMembers.Where(pm => pm.UserId == userId && pm.Role.Contains(filter)) 
                            : _context.ProjectMembers.Where(pm => pm.UserId == userId)
                    )
                    join p in _context.Projects on pm.ProjectId equals p.Id into projectJoin

                    from joinResult in projectJoin
                    select new Project
                    {
                        Id = joinResult.Id,
                        Name = joinResult.Name,
                        Description = joinResult.Description,
                        Date = joinResult.Date,
                        DeadLine = joinResult.DeadLine
                    }
            );
            if(filter != null)
            {
                model.Where(jr => jr.Name.Contains(filter) ||  jr.Description.Contains(filter));
            }
            if(isClosed.HasValue)
            {
                model.Where(jr => jr.isClosed == isClosed);
            }
            if(guildId.HasValue)
            {
                model.Where(jr => jr.GuildId == guildId);
            }
            if(indexPage.HasValue)
            {
                model.Skip((indexPage.Value - 1) * numberPerPage.Value).Take(numberPerPage.Value);
            }
            return model.ToList();
        }

        public Project GetProject(int projectId)
        {
            return _context.Projects.FirstOrDefault(p => p.Id == projectId);
        }
        public void RemoveProjectMember(ProjectMember projectMember)
        {
            if(projectMember == null)
            {
                throw new ArgumentNullException(nameof(projectMember));
            }
            _context.ProjectMembers.Remove(projectMember);
        }
        public void AddProjectMember(ProjectMember projectMember)
        {
            if (projectMember == null)
            {
                throw new ArgumentNullException(nameof(projectMember));
            }
            _context.ProjectMembers.Add(projectMember);
        }

        public ProjectMember GetProjectMember(int projectId, int userId)
        {
            return _context.ProjectMembers.FirstOrDefault(pm => pm.ProjectId == projectId && pm.UserId == userId);
        }
    }
}
