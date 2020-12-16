using System;
using Xunit;
using Moq;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using NWSocial.Models;
using NWSocial.Data;
using NWSocial.Seed;
using NWSocial.Classes;
using NWSocial.Profiles;
using NWSocial.Controllers;
using Microsoft.AspNetCore.Mvc;
using NWSocial.Dtos;

namespace NWSocial.tests
{
    public class GuildsControllerTest : IDisposable
    {
        Mock<INWSRepo> _mockRepo;
        IMapper _mapper;
        MapperConfiguration _configuration;
        GuildsController _guildsController;
        readonly GuildsSeed _guildsSeed;

        public GuildsControllerTest()
        {
            _mockRepo = new Mock<INWSRepo>();
            _configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new GuildsProfile());
            });
            _mapper = new Mapper(_configuration);
            _guildsController = new GuildsController(_mockRepo.Object, _mapper);
            _guildsSeed = new GuildsSeed();
        }
        public void Dispose()
        {
            _mockRepo = null;
            _mapper = null;
            _configuration = null;
            _guildsController = null;
        }

        [Fact]
        public void GetAllGuilds_EmptyFilterAndEmptyPagination_200OK()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.GetAllGuilds("", new Pagination(null,null))).Returns(_guildsSeed.GetGuildsTestData());
            var countElements = _guildsSeed.GetGuildsTestData().Count;
            // Act
            var result = _guildsController.GetAllGuilds("", null, null);

            //Assert
            Assert.IsType<ActionResult<IEnumerable<GuildReadDto>>>(result.Result);
            Assert.Equal(countElements, result.Result.Value.Count());
        }
    }
}
