using Microsoft.AspNetCore.Mvc;
using NWSocial.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NWSocial.Dtos.UserGuildRequestDtos;
using NWSocial.Models;

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

        //Get api/users/{id}/guilds
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
    }
}
