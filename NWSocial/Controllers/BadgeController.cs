using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NWSocial.Data;

namespace NWSocial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BadgeController //: ControllerBadge
    {
        private readonly INWSRepo _repository;
        private readonly IMapper _mapper;
    }
}
