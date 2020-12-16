using Microsoft.AspNetCore.Mvc;
using NWSocial.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NWSocial.Dtos.UserGuildRequestDtos;
using NWSocial.Models;
using NWSocial.Dtos.ProjectDtos;
using NWSocial.Dtos;
using NWSocial.Classes;
using NWSocial.Payloads;

namespace NWSocial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly INWSRepo _repository;
        private readonly IMapper _mapper;

        public UsersController(INWSRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // UserGuild relation

        [HttpGet("{userId}/guilds")]
        public ActionResult<List<UserGuildListItemDto>> GetUserGuilds(int userId)
        {
            List<UserGuild> userGuilds = _repository.GetUserGuilds(userId).ToList();
            List<UserGuildListItemDto> guildList = new List<UserGuildListItemDto>();
            userGuilds.ForEach(u =>
            {
                UserGuildListItemDto guildDto = _mapper.Map<UserGuildListItemDto>(u.Guild);
                guildDto.UserRole = u.Role;
                guildList.Add(guildDto);
            });
            return Ok(guildList);
        }

        [HttpGet("{id}/posts")]
        public ActionResult<IEnumerable<PostReadDto>> GetUserPosts(int id, string filter,[FromBody] Pagination pagination)
        {
            var list = _repository.GetUserPosts(id, filter, pagination);
            return Ok(_mapper.Map<IEnumerable<PostReadDto>>(list));
        }

        [HttpGet("{id}/projects")]
        public ActionResult<IEnumerable<ProjectReadDto>> GetUserProjects(int id, [FromBody] ProjectsPayload payload)
        {
            var list = _repository.GetUserProjects(id, payload.Filter.FilterValue, payload.Filter.Role, payload.Filter.IsPrivate, payload.Filter.GuildId, payload.Pagination);
            return Ok(_mapper.Map<IEnumerable<ProjectReadDto>>(list));
        }
    }
}
