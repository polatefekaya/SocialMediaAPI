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
        public async Task<ActionResult<PostGetResponse>> GetPost([FromQuery] PostGetRequest request) {

            return null;
        }

        [HttpGet]
        public async Task<ActionResult<PostGetResponse[]>> GetAllPostsByUserId([FromQuery]PostGetAllRequest request) {
            //TODO: it has to authenticate user for preventing private account post leaks
            PostGetResponse[] entities = await _dbService.GetAllPostsById(request);
            return entities;
        }

        [HttpGet]
        public async Task<ActionResult<PostGetResponse[]>> GetPostsByCategory([FromQuery]PostGetByCategoryRequest request) {
            PostGetResponse[] responses = await _dbService.GetByCategoryPost(request);
            return responses;
        }

        [HttpGet]
        public async Task<ActionResult<PostGetResponse[]>> GetPostsByType([FromQuery]PostGetByTypeRequest request) {
            return null;
        }

        [HttpGet]
        public async Task<ActionResult<PostGetResponse[]>> GetPostsByTopic([FromQuery] PostGetByTopicRequest request) {
            return null;
        }

        #endregion

        #region Post

        [HttpPost]
        public async Task<ActionResult<PostAddResponse>> AddPost(PostAddRequest request) {
            return await _dbService.AddPost(request);
        }

        #endregion





        [HttpDelete]
        public async Task<ActionResult<PostDeleteResponse>> DeletePost(PostDeleteRequest request) {
            PostDeleteResponse response = await _dbService.DeletePost(request); 
            return response;
        }

        [HttpDelete]
        public async Task<ActionResult<PostDeleteResponse[]>> DeleteBatchPost(PostDeleteBatchRequest request) {
            PostDeleteResponse[] responses = await _dbService.DeleteBatchPost(request);
            return responses;
        } 

        [HttpPut]
        public async Task<ActionResult<PostUpdateResponse>> UpdatePost(PostUpdateRequest request) {

            return null;
        }
    }
}
