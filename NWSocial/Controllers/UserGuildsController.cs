using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NWSocial.Data;
using NWSocial.Dtos;
using NWSocial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NWSocial.Controllers
{
    public class UserGuildsController : ControllerBase
    {
        private readonly INWSRepo _repository;
        private readonly IMapper _mapper;

        public UserGuildsController(INWSRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/guilds/{id}/users
        [HttpGet("guilds/{id}/users")]
        public ActionResult<List<UserReadDto>> GetGuildUsers(int guildID)
        {
            var guildUsers = _repository.GetGuildUsers(guildID);
            return Ok(_mapper.Map<IEnumerable<GuildReadDto>>(guildUsers));
        }

        //Get api/users/{id}/guilds
        [HttpGet("users/{id}/guilds")]
        public ActionResult<List<GuildReadDto>> GetUserGuilds(int userId)
        {

            var userGuilds = _repository.GetUserGuilds(userId);
            return Ok(_mapper.Map<IEnumerable<GuildReadDto>>(userGuilds));
        }
    }
}
