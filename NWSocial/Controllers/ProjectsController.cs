using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NWSocial.Data;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NWSocial.Models;
using NWSocial.Dtos.ProjectDtos;
using NWSocial.Dtos.ProjectMemberDtos;

namespace NWSocial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly INWSRepo _repo;
        private readonly IMapper _mapper;

        public ProjectsController(INWSRepo repository, IMapper mapper)
        {
            _repo = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProjectReadDto>> GetProjects(string filter, string role, int guildId, int indexPage, int numberPerPage)
        {
            var list = _repo.GetProjects(filter, role, guildId, indexPage, numberPerPage);
            return Ok(_mapper.Map<IEnumerable<ProjectReadDto>>(list));
        }

        [HttpGet("{id}")]
        public ActionResult<ProjectReadDto> GetProject(int projectId)
        {
            var project = _repo.GetProject(projectId);
            if(project == null)
            {
                return NotFound();
            }
            return (_mapper.Map<ProjectReadDto>(project));
        }

        [HttpPost]  
        public ActionResult<ProjectReadDto> AddProject(ProjectCreateDto newProject)
        {
            var project = _mapper.Map<Project>(newProject);
            _repo.AddProject(project);
            _repo.SaveChanges();
            return (Ok(_mapper.Map<ProjectReadDto>(project)));
        }

        [HttpDelete("{id}")]
        public ActionResult RemoveProject(int id)
        {
            var project = _repo.GetProject(id);
            if(project == null)
            {
                return NotFound();
            }
            _repo.RemoveProject(project);
            _repo.SaveChanges();
            return NoContent();
        }

        [HttpGet("{id}/members")]
        public ActionResult<IEnumerable<ProjectMemberReadDto>> GetProjectMembers(int id)
        {
            var list = _repo.GetProjectMembers(id);
            return Ok(_mapper.Map<IEnumerable<ProjectMemberReadDto>>(list));
        }

        [HttpPost("{id}/members")]
        public ActionResult<ProjectMemberReadDto> AddProjectMember(int id, ProjectMemberCreateDto newPm)
        {
            var pm = _mapper.Map<ProjectMember>(newPm);
            pm.ProjectId = id;
            _repo.AddProjectMember(pm);
            _repo.SaveChanges();
            return Ok(_mapper.Map<ProjectMemberReadDto>(pm));
        }

        [HttpDelete("{projectId}/members/{userId}")]
        public ActionResult RemoveProjectMember(int projectId, int userId )
        {
            var pm = _repo.GetProjectMember(projectId, userId);
            if(pm == null)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
