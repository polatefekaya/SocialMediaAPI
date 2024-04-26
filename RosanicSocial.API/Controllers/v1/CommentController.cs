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

        [HttpGet]
        public async Task<ActionResult<CommentGetResponse>> GetComment(CommentGetRequest request) {
            return null;
        }

        [HttpGet]
        public async Task<ActionResult<CommentGetAllByPostIdResponse>> GetAllComments(CommentGetAllByPostIdRequest request) {

            return null;
        }

        [HttpPost]
        public async Task<ActionResult<CommentAddResponse>> AddComment(CommentAddRequest request) {
            return await _dbService.AddCommentAsync(request);
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
