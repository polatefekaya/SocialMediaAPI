using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RosanicSocial.Application.Interfaces.DbServices;
using RosanicSocial.Application.Interfaces.Managers;
using RosanicSocial.Domain.DTO.Request.Comment;
using RosanicSocial.Domain.DTO.Response.Comment;
using RosanicSocial.WebAPI.Controllers;

namespace RosanicSocial.API.Controllers.v1 {
    [ApiVersion("1.0")]
    public class CommentController : CustomControllerBase {
        private readonly ICommentDbService _dbService;
        private readonly ISharingsDbManagerService _sharingsDbManager;
        private readonly ILogger<CommentController> _logger;

        public CommentController(ISharingsDbManagerService sharingsDbManager, ICommentDbService dbService, ILogger<CommentController> logger) {
            _dbService = dbService;
            _logger = logger;
            _sharingsDbManager = sharingsDbManager;
        }

        /// <summary>
        /// GET, gets the comment that specified with CommentGetRequest
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<CommentGetResponse>> GetComment([FromQuery] CommentGetRequest request) {
            _logger.LogInformation("GetComment Controller started");
            _logger.LogDebug($"Request Type: {nameof(CommentGetRequest)}");

            CommentGetResponse response = await _dbService.GetCommentAsync(request);

            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<CommentGetResponse[]>> GetAllCommentsByPostId([FromQuery]CommentGetAllByPostIdRequest request) {
            _logger.LogInformation("GetAllCommentsByPostId Controller started");
            _logger.LogDebug($"Request Type: {nameof(CommentGetAllByPostIdRequest)}");

            CommentGetResponse[] responses = await _dbService.GetAllCommentsByPostIdAsync(request);

            return Ok(responses);
        }

        [HttpGet]
        public async Task<ActionResult<CommentGetResponse[]>> GetAllCommentsByUserId([FromQuery]CommentGetAllByUserIdRequest request) {
            _logger.LogInformation("GetAllCommentsByUserId Controller started");
            _logger.LogDebug($"Request Type: {nameof(CommentGetAllByUserIdRequest)}");

            CommentGetResponse[] responses = await _dbService.GetAllCommentsByUserIdAsync(request);

            return Ok(responses); ;
        }

        [HttpPost]
        public async Task<ActionResult<CommentAddResponse>> AddComment(CommentAddRequest request) {
            _logger.LogInformation("AddComment Controller started");
            _logger.LogDebug($"Request Type: {nameof(CommentAddRequest)}");

            //CommentAddResponse response = await _dbService.AddCommentAsync(request);
            CommentAddResponse? response = await _sharingsDbManager.AddComment(request);
            if(response == null) {
                return BadRequest();
            }

            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<CommentUpdateResponse>> UpdateComment(CommentUpdateRequest request) {
            _logger.LogInformation("UpdateComment Controller started");
            _logger.LogDebug($"Request Type: {nameof(CommentUpdateRequest)}");

            CommentUpdateResponse response = await _dbService.UpdateCommentAsync(request);

            return Ok(response);
        }

        [HttpDelete]
        public async Task<ActionResult<CommentDeleteResponse>> DeleteComment(CommentDeleteRequest request) {
            _logger.LogInformation("DeleteComment Controller started");
            _logger.LogDebug($"Request Type: {nameof(CommentDeleteRequest)}");

            //CommentDeleteResponse response = await _dbService.DeleteCommentAsync(request);
            CommentDeleteResponse? response = await _sharingsDbManager.DeleteComment(request);
            if(response == null) {
                return BadRequest();
            }

            return Ok(response);
        }

        [HttpDelete]
        public async Task<ActionResult<CommentDeleteResponse[]>> DeleteAllCommentsByUserId(CommentDeleteAllByUserIdRequest request) {
            _logger.LogInformation("Delete All Comments By UserId Controller started");
            _logger.LogDebug($"Request Type: {nameof(CommentDeleteAllByUserIdRequest)}");

            CommentDeleteResponse[] responses = await _dbService.DeleteAllCommentsByUserIdAsync(request);

            return Ok(responses);
        }

        [HttpDelete]
        public async Task<ActionResult<CommentDeleteResponse[]>> DeleteAllCommentsByPostId(CommentDeleteRequest request) {
            throw new NotImplementedException();
        }
    }
}
