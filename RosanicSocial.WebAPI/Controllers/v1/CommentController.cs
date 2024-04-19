using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RosanicSocial.Domain.DTO.Request.Comment;
using RosanicSocial.Domain.DTO.Response.Comment;
using RosanicSocial.WebAPI.Controllers;

namespace RosanicSocial.API.Controllers.v1 {
    public class CommentController : CustomControllerBase {
        public CommentController() {

        }

        [HttpGet]
        public async Task<ActionResult<CommentGetResponse>> GetComment(CommentGetRequest request) {
            return null;
        }

        [HttpGet]
        public async Task<ActionResult<CommentGetAllResponse>> GetAllComments(CommentGetAllRequest request) {

            return null;
        }

        [HttpPost]
        public async Task<ActionResult<CommentAddResponse>> AddComment(CommentAddRequest request) {
            return null;
        }

        [HttpPut]
        public async Task<ActionResult<CommentUpdateResponse>> UpdateComment(CommentUpdateRequest request) {
            return null;
        }

        [HttpDelete]
        public async Task<ActionResult<CommentDeleteResponse>> DeleteComment(CommentDeleteRequest request) {
            return null;
        }

    }
}
