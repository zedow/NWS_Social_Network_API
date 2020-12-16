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
using NWSocial.Dtos.ProjectSlotDtos;
using NWSocial.Dtos.ProjectRequestDtos;
using Microsoft.AspNetCore.JsonPatch;
using NWSocial.Classes;
using Microsoft.AspNetCore.Http;
using NWSocial.Payloads;

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

        /// <summary>
        /// Retourne une liste de projets avec possibilité de paginer et filtrer
        /// </summary>
        /// <returns>Une liste de projets</returns>
        /// <response code="200">Retourne la liste des projects</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<ProjectReadDto>> GetProjects([FromBody] ProjectsPayload payload)
        {
            var list = _repo.GetProjects(payload.Filter.FilterValue, payload.Filter.Role, payload.Filter.IsClosed, payload.Filter.GuildId, payload.Pagination);
            return Ok(_mapper.Map<IEnumerable<ProjectReadDto>>(list));
        }

        /// <summary>
        /// Retourne un projet selon son Id
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns>Un projet</returns>
        /// <response code="200">Retourne le projet</response>
        /// <response code="404">Si l'objet ayant l'id en paramètre n'existe pas</response>
        [HttpGet("{projectId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ProjectReadDto> GetProject(int projectId)
        {
            var project = _repo.GetProject(projectId);
            if(project == null)
            {
                return NotFound();
            }
            return (_mapper.Map<ProjectReadDto>(project));
        }

        /// <summary>
        /// Créer un nouveau projet ajoute le créateur en tant que membre "Chef de projet" au projet
        /// </summary>
        /// <param name="newProject"></param>
        /// <returns>Le nouveau projet créé</returns>
        /// <response code="201">Le nouveau projet créé</response>
        /// <response code="400">Si le projet est null</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ProjectReadDto> AddProject(ProjectCreateDto newProject)
        {
            var project = _mapper.Map<Project>(newProject);
            _repo.AddProject(project);
            _repo.SaveChanges();
            var newSlot = new ProjectSlot { ProjectId = project.Id, Role = "Chef de projet" };
            _repo.AddProjectSlot(newSlot);
            _repo.SaveChanges();
            _repo.AddProjectMember(new ProjectMember { ProjectId = project.Id, SlotId = newSlot.Id, UserId = newProject.UserId});
            return Ok(_mapper.Map<ProjectReadDto>(project));
        }

        /// <summary>
        /// Supprime un projet ayant l'id fourni en paramètre
        /// </summary>
        /// <returns>Aucun contenu</returns>
        /// <response code="404">Si l'id fourni ne correspond à aucun projet</response>
        /// <response code="204">Si le projet a été supprimé</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
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

        /// <summary>
        /// Retourne la liste des membres d'un projet selon son Id
        /// </summary>
        /// <returns>Une liste de membre</returns>
        /// <response code="200">La liste des données mappées</response>
        [HttpGet("{id}/members")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<ProjectMemberReadDto>> GetProjectMembers(int id)
        {
            var list = _repo.GetProjectMembers(id);
            return Ok(_mapper.Map<IEnumerable<ProjectMemberReadDto>>(list));
        }

        /// <summary>
        /// Supprimer un membre d'un projet
        /// </summary>
        /// <returns>Aucun contenu</returns>
        /// <response code="404">Si le projet n'a pas été trouvé</response>
        /// <response code="204">Si le membre du projet a été supprimé avec succès</response>
        [HttpDelete("members")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult RemoveProjectMember([FromBody] ProjectMemberPayload projectMember)
        {
            var pm = _repo.GetProjectMember(projectMember.ProjectId, projectMember.UserId);
            if(pm == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        /// <summary>
        /// Retourne la liste des slots d'un projet
        /// </summary>
        /// <returns>Une liste de slot</returns>
        /// <response code="200">La liste des données mappées</response>
        [HttpGet("{projectId}/slots")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<ProjectSlotReadDto>> GetProjectSlots(int projectId)
        {
            var list = _repo.GetProjectSlots(projectId);
            return Ok(_mapper.Map<IEnumerable<ProjectSlotReadDto>>(list));
        }

        /// <summary>
        /// Ajoute plusieurs slots à un projet
        /// </summary>
        /// <param name="newSlots">Un json array de slotCreateDtos</param>
        /// <returns>Les nouveaux slots créés</returns>
        /// <response code="200">La liste des données mappées</response>
        [HttpPost("slots")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<ProjectSlotReadDto> AddProjectSlots([FromBody]  IEnumerable<ProjectSlotCreateDto> newSlots)
        {
            var slots = _mapper.Map<IEnumerable<ProjectSlot>>(newSlots);
            _repo.AddProjectSlots(slots);
            _repo.SaveChanges();
            return Ok(_mapper.Map<IEnumerable<ProjectSlotReadDto>>(slots));
        }

        /// <summary>
        /// Ajoute une request sur un slot de projet
        /// </summary>
        /// <returns>La request créée</returns>
        /// <response code="200">Le nouvel objet mappé</response>
        [HttpPost("requests")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<ProjectRequestAfterCreationReadDto> AddProjectRequest(ProjectRequestCreateDto newProjectRequest)
        {
            var pr = _mapper.Map<ProjectRequest>(newProjectRequest);
            pr.Status = "En attente";
            _repo.AddProjectRequest(pr);
            _repo.SaveChanges();
            return Ok( _mapper.Map<ProjectRequestAfterCreationReadDto>(pr));
        }

        /// <summary>
        /// Permet de modifier le statut d'une requête 
        /// </summary>
        /// <returns>Aucun contenu</returns>
        /// <response code="404">Si la request n'existe pas</response>
        /// <response code="204">Si la request a été modifiée</response>
        [HttpPatch("requests")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult UpdateRequestStatus([FromBody] ProjectRequestPayload payload)
        {
            var modelFromRepo = _repo.GetProjectRequest(payload.UserId, payload.SlotId);
            if (modelFromRepo == null)
            {
                return NotFound();
            }
            var prToPatch = _mapper.Map<ProjectRequestUpdateDto>(modelFromRepo);
            payload.PatchDocument.ApplyTo(prToPatch, ModelState);
            if (!TryValidateModel(prToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(prToPatch, modelFromRepo);
            _repo.UpdateProjectRequest(modelFromRepo, payload.ProjectId);
            _repo.SaveChanges();
            return NoContent();
        }
    }
}
