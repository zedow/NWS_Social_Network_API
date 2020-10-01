using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NWSocial.Data;
using NWSocial.Dtos;
using NWSocial.Models;

namespace NWSocial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuildsController : ControllerBase
    {
        private readonly INWSRepo _repository;
        private readonly IMapper _mapper;

        public GuildsController(INWSRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/guilds
        [HttpGet]
        public ActionResult<IEnumerable<GuildReadDto>> GetAllGuilds()
        {
            var guildItems = _repository.GetAllGuilds();
            return Ok(_mapper.Map<IEnumerable<GuildReadDto>>(guildItems));
        }

        // GET api/guilds/{id}
        [HttpGet("{id}")]
        public ActionResult <GuildReadDto> GetGuildByID(int id)
        {
            var guildItem = _repository.GetGuildById(id);
            if(guildItem != null)
            {
                return Ok(_mapper.Map<GuildReadDto>(guildItem)) ;
            }
            return NotFound();
        }

        //POST api/guilds
        [HttpPost]
        public ActionResult<GuildReadDto> CreateGuild(GuildCreateDto guild)
        {
            var guildModel = _mapper.Map<Guild>(guild);
            _repository.CreateGuild(guildModel);
            _repository.SaveChanges();
            return Ok(guildModel);
        }
    }
}
