using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RosanicSocial.Application.Interfaces.DbServices;
using RosanicSocial.Domain.DTO.Request.Comment;
using RosanicSocial.Domain.DTO.Response.Comment;
using RosanicSocial.WebAPI.Controllers;

namespace RosanicSocial.API.Controllers.v1 {
    [ApiVersion("1.0")]
    public class CommentController : CustomControllerBase {
        private readonly ICommentDbService _dbService;

        public CommentController(ICommentDbService dbService) {
            _dbService = dbService;
        }

        /// <summary>
        /// GET, gets the comment that specified with CommentGetRequest
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<CommentGetResponse>> GetComment(CommentGetRequest request) {
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllComments(CommentGetAllByPostIdRequest request) {

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<CommentAddResponse>> AddComment(CommentAddRequest request) {
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult<CommentUpdateResponse>> UpdateComment(CommentUpdateRequest request) {
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult<CommentDeleteResponse>> DeleteComment(CommentDeleteRequest request) {
            return NoContent();
        }

    }
}
