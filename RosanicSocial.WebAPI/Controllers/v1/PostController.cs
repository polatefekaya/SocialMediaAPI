using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RosanicSocial.Domain.DTO.Request.Post;
using RosanicSocial.Domain.DTO.Response.Post;
using RosanicSocial.WebAPI.Controllers;

namespace RosanicSocial.API.Controllers.v1 {
    public class PostController : CustomControllerBase {

        public PostController() {

        }

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



        [HttpPost]
        public async Task<ActionResult<PostAddResponse>> AddPost(PostAddRequest request) {
            
            return null;
        }

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
