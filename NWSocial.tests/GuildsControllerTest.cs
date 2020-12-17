using System;
using Xunit;
using Moq;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.JsonPatch;
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
        public async void GetAllGuilds_EmptyFilterAndEmptyPagination_200OK()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.GetAllGuildsAsync(null, new Pagination(0,7))).ReturnsAsync(_guildsSeed.GetGuildsTestData());

            // Act
            var result = await _guildsController.GetAllGuilds(null, null,null);

            //Assert
           Assert.IsType<ActionResult<IEnumerable<GuildReadDto>>>(result);
        }

        [Fact]
        public void GetGuildById_IdEqual1_200OK()
        {
            _mockRepo.Setup(repo => repo.GetGuildById(1)).Returns(_guildsSeed.GetGuildsTestData().Find(g => g.Id == 1));

            var result = _guildsController.GetGuildById(1);

            Assert.IsType<ActionResult<GuildReadDto>>(result);
        }

        [Fact]
        public void GetGuildById_IdEqual99_404NotFound()
        {
            _mockRepo.Setup(repo => repo.GetGuildById(99)).Returns(() => null);

            var result = _guildsController.GetGuildById(99);

            Assert.IsType<Microsoft.AspNetCore.Mvc.NotFoundResult>(result.Result);
        }

        [Fact]
        public void UpdateGuild_IdEqual99_404NotFound()
        {
            var fakeId = 99;
            var result = _guildsController.UpdateGuild(fakeId, new GuildUpdateDto { Name="test new name"});
            Assert.IsType<Microsoft.AspNetCore.Mvc.NotFoundResult>(result);
        }

        [Fact]
        public void PartialGuildUpdate_IdEqual99_404NotFound()
        {
            var fakeId = 99;
            var result = _guildsController.PartialGuildUpdate(fakeId, new JsonPatchDocument<GuildUpdateDto>());
            
            Assert.IsType<Microsoft.AspNetCore.Mvc.NotFoundResult>(result);
        }


    }
}
