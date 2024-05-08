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
        private readonly ILogger<CommentController> _logger;

        public CommentController(ICommentDbService dbService, ILogger<CommentController> logger) {
            _dbService = dbService;
            _logger = logger;
        }

        /// <summary>
        /// GET, gets the comment that specified with CommentGetRequest
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<CommentGetResponse>> GetComment(CommentGetRequest request) {
            _logger.LogInformation("GetComment Controller started");
            _logger.LogDebug($"Request Type: {nameof(CommentGetRequest)}");

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<CommentGetResponse[]>> GetAllComments(CommentGetAllByPostIdRequest request) {
            _logger.LogInformation("GetAllComments Controller started");
            _logger.LogDebug($"Request Type: {nameof(CommentGetAllByPostIdRequest)}");

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<CommentAddResponse>> AddComment(CommentAddRequest request) {
            _logger.LogInformation("AddComment Controller started");
            _logger.LogDebug($"Request Type: {nameof(CommentAddRequest)}");

            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult<CommentUpdateResponse>> UpdateComment(CommentUpdateRequest request) {
            _logger.LogInformation("UpdateComment Controller started");
            _logger.LogDebug($"Request Type: {nameof(CommentUpdateRequest)}");

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult<CommentDeleteResponse>> DeleteComment(CommentDeleteRequest request) {
            _logger.LogInformation("DeleteComment Controller started");
            _logger.LogDebug($"Request Type: {nameof(CommentDeleteRequest)}");

            return NoContent();
        }

    }
}
