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
    public class PostsController : ControllerBase
    {
        private readonly INWSRepo _repository;
        private readonly IMapper _mapper;

        public PostsController(INWSRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/posts
        [HttpGet]
        public ActionResult<IEnumerable<PostReadDto>> GetAllPosts()
        {
            var postItems = _repository.GetAllPosts();
            return Ok(_mapper.Map<IEnumerable<PostReadDto>>(postItems));
        }

        // GET api/posts/{id}
        [HttpGet("{id}")]
        public ActionResult<PostReadDto> GetPostByID(int id)
        {
            var postItem = _repository.GetPostById(id);
            if (postItem != null)
            {
                return Ok(_mapper.Map<PostReadDto>(postItem));
            }
            return NotFound();
        }

        //POST api/posts
        [HttpPost]
        public ActionResult<PostReadDto> CreatePost(PostCreateDto post)
        {
            var postModel = _mapper.Map<Post>(post);
            _repository.CreatePost(postModel);
            _repository.SaveChanges();
            return Ok(postModel);
        }

        //PATCH api/posts/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialPostUpdate(int id, JsonPatchDocument<PostUpdateDto> patchDocument)
        {
            var postModelFromRepo = _repository.GetPostById(id);
            if (postModelFromRepo == null)
            {
                return NotFound();
            }
            var postToPatch = _mapper.Map<PostUpdateDto>(postModelFromRepo);
            patchDocument.ApplyTo(postToPatch, ModelState);
            if (!TryValidateModel(postToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(postToPatch, postModelFromRepo);
            _repository.UpdatePost(postModelFromRepo);
            _repository.SaveChanges();
            return (NoContent());
        }


        //DELETE api/posts/{id}
        [HttpDelete("{id}")]
        public ActionResult DeletePost(int id)
        {
            var postModelFromRepo = _repository.GetPostById(id);
            if (postModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeletePost(postModelFromRepo);
            _repository.SaveChanges();

            return (NoContent());
        }



        
    }
}
