using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RosanicSocial.Domain.DTO.Request.Post;
using RosanicSocial.Domain.DTO.Response.Post;
using RosanicSocial.WebAPI.Controllers;

namespace RosanicSocial.API.Controllers.v1 {
    [ApiVersion("1.0")]
    public class PostController : CustomControllerBase {

        public PostController() {

        }

        #region Get

        [HttpGet]
        [Route("ById")]
        public async Task<ActionResult<PostGetResponse>> GetPost(PostGetRequest request) {

            return null;
        }

        [HttpGet]
        [Route("AllById")]
        public async Task<ActionResult<PostGetAllResponse>> GetAllPostsByUserId(PostGetAllRequest request) {

            return null;
        }

        [HttpGet]
        public async Task<ActionResult<PostGetByCategoryResponse>> GetPostsByCategory(PostGetByCategoryRequest request) {
            return null;
        }

        [HttpGet]
        public async Task<ActionResult<PostGetByTypeResponse>> GetPostsByType(PostGetByTypeRequest request) {
            return null;
        }

        [HttpGet]
        public async Task<ActionResult<PostGetByTopicResponse>> GetPostsByTopic(PostGetByTopicRequest request) {
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
        public async Task<ActionResult<PostDeleteBatchResponse>> DeleteBatchPost(PostDeleteBatchRequest request) {
            return null;
        } 

        [HttpPut]
        public async Task<ActionResult<PostUpdateResponse>> UpdatePost(PostUpdateRequest request) {

            return null;
        }
    }
}
