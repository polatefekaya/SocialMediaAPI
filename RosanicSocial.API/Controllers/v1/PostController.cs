using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RosanicSocial.Application.Filters;
using RosanicSocial.Application.Interfaces.DbServices;
using RosanicSocial.Application.Interfaces.Managers;
using RosanicSocial.Domain.DTO.Request.Post;
using RosanicSocial.Domain.DTO.Response.Post;
using RosanicSocial.WebAPI.Controllers;

namespace RosanicSocial.API.Controllers.v1 {
    [ApiVersion("1.0")]
    [TypeFilter(typeof(NotAutherizedUserActionFilter))]
    public class PostController : CustomControllerBase {
        private readonly IPostDbService _dbService;
        private readonly ISharingsDbManagerService _sharingsDbManager;
        public PostController(IPostDbService dbService, ISharingsDbManagerService sharingsDbManager) {
            _dbService = dbService;
            _sharingsDbManager = sharingsDbManager;
        }

        #region Get

        [HttpGet]
        public async Task<ActionResult<PostGetResponse>> GetPost([FromQuery] PostGetRequest request) {
            PostGetResponse response = await _dbService.GetPost(request);
            return response;
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
            PostGetResponse[] responses = await _dbService.GetByTypePost(request);
            return responses;
        }

        [HttpGet]
        public async Task<ActionResult<PostGetResponse[]>> GetPostsByTopic([FromQuery] PostGetByTopicRequest request) {
            PostGetResponse[] responses = await _dbService.GetByTopicPost(request);
            return responses;
        }

        #endregion

        #region Post

        [HttpPost]
        public async Task<ActionResult<PostAddResponse>> AddPost(PostAddRequest request) {
            PostAddResponse? response = await _sharingsDbManager.AddPost(request);
            if (response == null) { return BadRequest(); }

            return Ok(response);
            //return await _dbService.AddPost(request);
        }

        #endregion





        [HttpDelete]
        public async Task<ActionResult<PostDeleteResponse>> DeletePost(PostDeleteRequest request) {
            //PostDeleteResponse response = await _dbService.DeletePost(request); 
            PostDeleteResponse? response = await _sharingsDbManager.DeletePost(request);
            if (response is null) { return BadRequest(); }

            return Ok(response);
        }

        [HttpDelete]
        public async Task<ActionResult<PostDeleteResponse[]>> DeleteBatchPost(PostDeleteBatchRequest request) {
            PostDeleteResponse[] responses = await _dbService.DeleteBatchPost(request);
            return responses;
        }

        [HttpDelete]
        public async Task<ActionResult<PostDeleteResponse[]>> DeleteAllPostsByUserId(PostDeleteAllRequest request) {
            PostDeleteResponse[] responses = await _dbService.DeleteAllPosts(request);
            return responses;
        }

        [HttpPut]
        public async Task<ActionResult<PostUpdateResponse>> UpdatePost(PostUpdateRequest request) {
            PostUpdateResponse response = await _dbService.UpdatePost(request); 
            return response;
        }
    }
}
