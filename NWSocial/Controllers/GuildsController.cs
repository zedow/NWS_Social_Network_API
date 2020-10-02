using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
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

        //PUT api/guilds/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateGuild(int id, GuildUpdateDto guildDto)
        {
            var guildModelFromRepo = _repository.GetGuildById(id);
            if(guildModelFromRepo == null)
            {
                return NotFound();
            }
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
            if (guildModelFromRepo == null)
            {
                return NotFound();
            }
            var guildToPatch = _mapper.Map<GuildUpdateDto>(guildModelFromRepo);
            patchDocument.ApplyTo(guildToPatch, ModelState);
            if(!TryValidateModel(guildToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(guildToPatch, guildModelFromRepo);
            _repository.UpdateGuild(guildModelFromRepo);
            _repository.SaveChanges();
            return (NoContent());
        }

        //DELETE api/guilds/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteGuild(int id)
        {
            var guildModelFromRepo = _repository.GetGuildById(id);
            if (guildModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteGuild(guildModelFromRepo);
            _repository.SaveChanges();

            return (NoContent());
        }
    }
}
