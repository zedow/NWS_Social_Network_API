using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using NWSocial.Data;
using NWSocial.Dtos;
using NWSocial.Dtos.UserGuildRequestDtos;
using NWSocial.Models;

namespace NWSocial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuildsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly INWSRepo _repository;

        public GuildsController(INWSRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/guilds/{id}/users
        [HttpGet("{guildID}/users")]
        public ActionResult<List<UserGuildReadDto>> GetGuildUsers(int guildID)
        {
            var userGuilds = _repository.GetGuildUsers(guildID);
            var users = new List<UserGuildReadDto>();
            userGuilds.ToList().ForEach(u =>
            {
                var user = u.User;
                if (user != null)
                {
                    var mappedUser = _mapper.Map<UserGuildReadDto>(user);
                    mappedUser.Role = u.Role;
                    users.Add(mappedUser);
                }
            });
            return Ok(users);
        }

        //GET api/guilds
        [HttpGet]
        public ActionResult<IEnumerable<GuildReadDto>> GetAllGuilds()
        {
            var guildItems = _repository.GetAllGuilds();
            return Ok(_mapper.Map<List<GuildReadDto>>(guildItems));
        }

        // GET api/guilds/{id}
        [HttpGet("{id}")]
        public ActionResult<GuildReadDto> GetGuildById(int id)
        {
            var guildItem = _repository.GetGuildById(id);
            if (guildItem != null) return Ok(_mapper.Map<GuildReadDto>(guildItem));
            return NotFound();
        }

        //POST api/guilds
        [HttpPost]
        public ActionResult<GuildReadDto> CreateGuild(GuildCreateDto guild)
        {
            var guildModel = _mapper.Map<Guild>(guild);
            _repository.CreateGuild(guildModel);
            _repository.SaveChanges();
            return Ok(_mapper.Map<GuildReadDto>(guildModel));
        }

        //PUT api/guilds/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateGuild(int id, GuildUpdateDto guildDto)
        {
            var guildModelFromRepo = _repository.GetGuildById(id);
            if (guildModelFromRepo == null) return NotFound();
            _mapper.Map(guildDto, guildModelFromRepo);
            _repository.UpdateGuild(guildModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        //PATCH api/guilds/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialGuildUpdate(int id, JsonPatchDocument<GuildUpdateDto> patchDocument)
        {
            var guildModelFromRepo = _repository.GetGuildById(id);
            if (guildModelFromRepo == null) return NotFound();
            var guildToPatch = _mapper.Map<GuildUpdateDto>(guildModelFromRepo);
            patchDocument.ApplyTo(guildToPatch, ModelState);
            if (!TryValidateModel(guildToPatch)) return ValidationProblem(ModelState);

            _mapper.Map(guildToPatch, guildModelFromRepo);
            _repository.UpdateGuild(guildModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        //DELETE api/guilds/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteGuild(int id)
        {
            var guildModelFromRepo = _repository.GetGuildById(id);
            if (guildModelFromRepo == null) return NotFound();
            _repository.DeleteGuild(guildModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpPost]
        public ActionResult AddUsertoGuild(UserGuildCreateRequestDto userGuildRequest)
        {
            UserGuild userGuild = new UserGuild
            {
                Role = "En attente",
                UserId = userGuildRequest.UserId,
                GuildId = userGuildRequest.GuildId
            };
            _repository.CreateUserGuildRequest(userGuild);
            _repository.SaveChanges();
            return Ok(_mapper.Map<UserGuildReadDto>(userGuild));
        }


        /// <summary>
        ///     Modifie le role d'un utilisateur
        /// </summary>
        /// <param name="guildId"></param>
        /// <param name="userId"></param>
        /// <param name="patchDocument"></param>
        /// <returns>Objet HTTP pas de contenu en cas de réussite</returns>
        [HttpPatch("{guildId}/users/{userId}")]
        public ActionResult ModifyUserRole(int guildId, int userId, JsonPatchDocument<UserGuildRequestUpdateDto> patchDocument)
        {
            var userGuild = _repository.GetGuildUser(guildId, userId);
            if (userGuild == null) return NotFound();

            var userGuildToPatch = _mapper.Map<UserGuildRequestUpdateDto>(userGuild);
            patchDocument.ApplyTo(userGuildToPatch, ModelState);
            if (!TryValidateModel(userGuildToPatch)) return ValidationProblem(ModelState);

            _mapper.Map(userGuildToPatch, userGuild);
            _repository.UpdateUserGuild(userGuild);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpPost("[action]")]
        public ActionResult ChangeGuildOwner(ChangeGuildOwnerDto OwnerArray)
        {
            // ADD middleware verification

            UserGuild currentOwner = _repository.GetGuildUser(OwnerArray.GuildId, OwnerArray.CurrentUserOwnerId);
            UserGuild newOwner = _repository.GetGuildUser(OwnerArray.GuildId, OwnerArray.NewUserOwnerId);
            if (currentOwner == null || newOwner == null)
            {
                return NotFound();
            }
            currentOwner.Role = "Membre";
            newOwner.Role = "Admin";
            _repository.UpdateUserGuild(currentOwner);
            _repository.UpdateUserGuild(newOwner);
            _repository.SaveChanges();
            return NoContent();
        }
        
        [HttpPost("validate")]
        public ActionResult AcceptUser(UserGuildAcceptDto user)
        {
            UserGuild userToAccept = _repository.GetGuildUser(user.GuildId, user.UserId);
            if(userToAccept == null)
            {
                return NotFound();
            }
            userToAccept.Role = "Membre";
            _repository.UpdateUserGuild(userToAccept);
            _repository.SaveChanges();
            return NoContent();
        }
        [HttpGet("{id}/posts")]
        public ActionResult<List<Post>> GuildPosts(int id)
        {
            return Ok(_repository.GetGuildPosts(id).ToList());
        }

        [HttpGet("{GuildId}/posts/{PostId}")]
        public ActionResult<List<Post>> GuildPost(int GuildId, int PostId)
        {
            return Ok(_repository.GetGuildPost(GuildId, PostId).ToList());
        }
    }
}