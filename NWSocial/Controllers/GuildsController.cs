using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using NWSocial.Data;
using NWSocial.Dtos;
using NWSocial.Dtos.UserGuildRequestDtos;
using NWSocial.Models;
using NWSocial.Classes;
using NWSocial.Payloads;
using System.Threading.Tasks;

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
        [HttpGet("{guildID}/members")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<UserGuildReadDto>>> GetGuildMembers(int guildID)
        {
            var userGuilds = await _repository.GetGuildMembersAsync(guildID);
            return Ok(_mapper.Map<IEnumerable<UserGuildReadDto>>(userGuilds));
        }

        //GET api/guilds
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<GuildReadDto>>> GetAllGuilds(string filter,int? index, int? items)
        {
            var guildItems = await _repository.GetAllGuildsAsync(filter,new Pagination(index,items));
            return Ok(_mapper.Map<IEnumerable<GuildReadDto>>(guildItems));
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

        /// <summary>
        /// Permet de modifier un ou plusieurs champs d'une guild
        /// </summary>
        /// <param name="id"></param>
        /// <param name="patchDocument"></param>
        /// <returns></returns>
        /// <response code="200">Modifie les champs modifier</response>
        /// <response code="404">Si aucune guild correspondant à l'id</response>
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

        /// <summary>
        /// Permet de supprimer une guild 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Supprime la guild et réactualise</response>
        /// <response code="404">Si aucune guild correspondant à l'id</response>
        [HttpDelete("{id}")]
        public ActionResult DeleteGuild(int id)
        {
            var guildModelFromRepo = _repository.GetGuildById(id);
            if (guildModelFromRepo == null) return NotFound();
            _repository.DeleteGuild(guildModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        /// <summary>
        /// Permet d'accepter la demande d'ajout d'un user dans la guild
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userGuildRequest"></param>
        /// <returns></returns>
        /// <response code="200">Rajoute le user dans la guild</response>
        [HttpPost("{id}/members")]
        public ActionResult AddUsertoGuild(int id,UserGuildCreateRequestDto userGuildRequest)
        {
            UserGuild userGuild = new UserGuild
            {
                Role = "En attente",
                UserId = userGuildRequest.UserId,
                GuildId = id
            };
            _repository.CreateUserGuildRequest(userGuild);
            _repository.SaveChanges();
            return Ok(_mapper.Map<UserGuildReadDto>(userGuild));
        }

        /// <summary>
        /// Permet de supprimer un user d'une guild
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="guildId"></param>
        /// <returns></returns>
        /// <response code="404">Si aucune guild correspondant à l'id</response>
        /// <response code="204">Supprime un user de la guild et réactualise</response>
        [HttpDelete("{guildId}/users/{userId}")]
        public ActionResult RemoveUserFromGuild(int userId, int guildId)
        {
            var userGuildModelFromRepo = _repository.GetGuildUser(guildId, userId);
            if (userGuildModelFromRepo == null) return NotFound();
            _repository.RemoveUserFromGuild(userGuildModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        /// <summary>
        /// Modifie le rôle d'un membre d'une guilde
        /// </summary>
        /// <param name="payload"></param>
        /// <returns>Aucun contenu</returns>
        /// <response code="404">En cas d'echec</response>
        /// <response code="204">En cas de réussite</response>
        [HttpPatch("members")]
        public ActionResult ModifyUserRole([FromBody] UpdateGuildMemberPayload payload)
        {
            var userGuild = _repository.GetGuildUser(payload.GuildId, payload.UserId);
            if (userGuild == null) return NotFound();

            var userGuildToPatch = _mapper.Map<UserGuildRequestUpdateDto>(userGuild);
            payload.PatchDocument.ApplyTo(userGuildToPatch, ModelState);
            if (!TryValidateModel(userGuildToPatch)) return ValidationProblem(ModelState);

            _mapper.Map(userGuildToPatch, userGuild);
            _repository.UpdateUserGuild(userGuild);
            _repository.SaveChanges();
            return NoContent();
        }

        /// <summary>
        /// Changer le chef de guild
        /// </summary>
        /// <param name="OwnerArray"></param>
        /// <returns></returns>
        /// <response code="204">Change le chef de la guild et réactualise</response
        /// <response code="404"></response>
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


        /// <summary>
        ///  Permet d'accepter la demande d'un utilisateur pour rejoindre la guild 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <response code="204">Accepte l'utilisateur dans la guild</response>
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

        /// <summary>
        /// Retourne la liste des posts d'une guild
        /// </summary>
        /// <param name="id"></param>
        /// <param name="payload"></param>
        /// <returns></returns>
        /// <response code="200">Retourne la listes des posts</response>
        /// <response code="404">Si aucune guild correspondant à l'id</response>
        [HttpGet("{id}/posts")]
        public ActionResult<List<Post>> GuildPosts(int id,[FromBody] GuildsPayload payload)
        {
            return Ok(_repository.GetAllPosts(payload.Filter.FilterValue, id, payload.Pagination).ToList());
        }
    }
}
