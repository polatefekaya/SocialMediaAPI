using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RosanicSocial.Application.Interfaces.DbServices;
using RosanicSocial.Domain.DTO.Request.Post;
using RosanicSocial.Domain.DTO.Response.Post;
using RosanicSocial.WebAPI.Controllers;

namespace RosanicSocial.API.Controllers.v1 {
    [ApiVersion("1.0")]
    public class PostController : CustomControllerBase {
        private readonly IPostDbService _dbService;
        public PostController(IPostDbService dbService) {
            _dbService = dbService;
        }

        #region Get

        [HttpGet]
        public async Task<ActionResult<PostGetResponse>> GetPost(PostGetRequest request) {

            return null;
        }

        [HttpGet]
        public async Task<ActionResult<PostGetResponse[]>> GetAllPostsByUserId([FromQuery]PostGetAllRequest request) {
            //TODO: it has to authenticate user for preventing private account post leaks
            PostGetResponse[] entities = await _dbService.GetAllPosts(request);
            return entities;
        }

        [HttpGet]
        public async Task<ActionResult<PostGetResponse[]>> GetPostsByCategory(PostGetByCategoryRequest request) {
            return null;
        }

        [HttpGet]
        public async Task<ActionResult<PostGetResponse[]>> GetPostsByType(PostGetByTypeRequest request) {
            return null;
        }

        [HttpGet]
        public async Task<ActionResult<PostGetResponse[]>> GetPostsByTopic(PostGetByTopicRequest request) {
            return null;
        }

        #endregion

        #region Post

        [HttpPost]
        public async Task<ActionResult<PostAddResponse>> AddPost(PostAddRequest request) {
            
            return null;
        }

        #endregion





        [HttpDelete]
        public async Task<ActionResult<PostDeleteResponse>> DeletePost(PostDeleteRequest request) {

            return null;
        }

        [HttpDelete]
        public async Task<ActionResult<PostDeleteResponse[]>> DeleteBatchPost(PostDeleteBatchRequest request) {
            return null;
        } 

        [HttpPut]
        public async Task<ActionResult<PostUpdateResponse>> UpdatePost(PostUpdateRequest request) {

            return null;
        }
    }
}
