﻿using AutoMapper;
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
    [Route("api")]
    [ApiController]
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
        [HttpGet("guilds/{guildID}/users")]
        public ActionResult<List<UserReadDto>> GetGuildUsers(int guildID)
        {
            var guildUsers = _repository.GetGuildUsers(guildID);
            return Ok(_mapper.Map<IEnumerable<GuildReadDto>>(guildUsers));
        }

        //Get api/users/{id}/guilds
        [HttpGet("users/{userId}/guilds")]
        public ActionResult<List<GuildReadDto>> GetUserGuilds(int userId)
        {

            var userGuilds = _repository.GetUserGuilds(userId);
            return Ok(_mapper.Map<IEnumerable<GuildReadDto>>(userGuilds));
        }

        //POST api/guilds
        [HttpPost]
        public ActionResult<GuildReadDto> AddUserToGuild(UserGuildCreateRequestDto request)
        {
            var userGuildRequest = _mapper.Map<UserGuild>(request);
            userGuildRequest.Id = Guid.NewGuid();
            _repository.CreateUserGuildRequest(userGuildRequest);
            _repository.SaveChanges();
            return Ok(userGuildRequest);
        }

        //POST api/users/{id}/guilds/{id}
        //[HttpPost("")]
    }
}
