using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RosanicSocial.Domain.DTO.Response.Post;
using RosanicSocial.WebAPI.Controllers;

namespace RosanicSocial.API.Controllers.v1 {
    public class PostController : CustomControllerBase {

        public PostController() {

        }

        [HttpGet]
        public async Task<ActionResult<PostGetResponse>> GetPost() {

            return null;
        }

        [HttpPost]
        public async Task<ActionResult<PostAddResponse>> AddPost() {

            return null;
        }

        [HttpDelete]
        public async Task<ActionResult<PostDeleteResponse>> DeletePost() {

            return null;
        }

        [HttpPut]
        public async Task<ActionResult<PostUpdateResponse>> UpdatePost() {

            return null;
        }
    }
}
