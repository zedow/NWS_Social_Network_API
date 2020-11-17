using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NWSocial.Data;
using NWSocial.Dtos;

namespace NWSocial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BadgeController : ControllerBase
    {
        private readonly INWSRepo _repository;
        private readonly IMapper _mapper;

        public BadgeController(INWSRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        ////GET api/badges
        //[HttpGet]
        //public ActionResult<IEnumerable<BadgeReadDto>> GetAllBadges(string filter, int? indexPage, int? numberPerPage)
        //{
        //    var badgeItems = _repository.GetAllBadges(filter, null, indexPage, numberPerPage);
        //    return Ok(_mapper.Map<IEnumerable<BadgeReadDto>>(badgeItems));
        //}
    }
}
