using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RosanicSocial.Application.Filters;
using RosanicSocial.Application.Interfaces.DbServices;
using RosanicSocial.Application.Interfaces.Managers;
using RosanicSocial.Domain.DTO.Request.Likes.Comment;
using RosanicSocial.Domain.DTO.Request.Likes.Post;
using RosanicSocial.Domain.DTO.Response.Likes.Comment;
using RosanicSocial.Domain.DTO.Response.Likes.Post;
using RosanicSocial.Domain.DTO.Response.Post;
using RosanicSocial.WebAPI.Controllers;

namespace RosanicSocial.API.Controllers.v1 {
    [ApiVersion("1.0")]
    [TypeFilter(typeof(NotAutherizedUserActionFilter))]
    public class LikeController : CustomControllerBase {
        private readonly ILikeDbService _dbService;
        private readonly IInteractionDbManagerService _interactionDbManager;
        private readonly ILogger<LikeController> _logger;   
        public LikeController(IInteractionDbManagerService interactionDbManager, ILogger<LikeController> logger, ILikeDbService dbService) {
            _logger = logger;
            _dbService = dbService;
            _interactionDbManager = interactionDbManager;
        }

        #region PostLike
        [HttpPost]
        public async Task<ActionResult<PostLikesAddResponse>> AddPostLike(PostLikesAddRequest request) {
            _logger.LogInformation($"{nameof(AddPostLike)} controller started in {nameof(LikeController)}");

            //PostLikesAddResponse response = await _dbService.AddPostLike(request);
            PostLikesAddResponse? response = await _interactionDbManager.AddPostLike(request);
            if (response == null) { return BadRequest(); }

            return response;
        }

        [HttpDelete]
        public async Task<ActionResult<PostLikesDeleteResponse>> DeletePostLike(PostLikesDeleteRequest request) {
            _logger.LogInformation($"{nameof(DeletePostLike)} controller started in {nameof(LikeController)}");

            //PostLikesDeleteResponse? response = await _dbService.DeletePostLike(request);
            PostLikesDeleteResponse? response = await _interactionDbManager.DeletePostLike(request);
            if (response == null) {
                return BadRequest("There is no object like specified.");
            }
            return response;
        }

        [HttpDelete]
        public async Task<ActionResult<PostLikesDeleteResponse[]>> DeleteAllPostLikesByUserId(PostLikesDeleteAllByUserIdRequest request) {
            _logger.LogInformation($"{nameof(DeleteAllPostLikesByUserId)} controller started in {nameof(LikeController)}");

            PostLikesDeleteResponse[] responses = await _dbService.DeleteAllPostLikesByUserId(request);
            return responses;
        }

        [HttpDelete]
        public async Task<ActionResult<PostLikesDeleteResponse[]>> DeleteAllPostLikesByPostId(PostLikesDeleteAllByPostIdRequest request) {
            _logger.LogInformation($"{nameof(DeleteAllPostLikesByPostId)} controller started in {nameof(LikeController)}");

            PostLikesDeleteResponse[] responses = await _dbService.DeleteAllPostLikesByPostId(request);
            return responses;
        }

        [HttpGet]
        public async Task<ActionResult<PostLikesGetResponse?>> GetPostLike([FromQuery] PostLikesGetRequest request) {
            _logger.LogInformation($"{nameof(GetPostLike)} controller started in {nameof(LikeController)}");

            PostLikesGetResponse? response = await _dbService.GetPostLike(request);
            if (response == null) {
                return BadRequest("There is no object like specified.");
            }
            return response;
        }

        [HttpGet]
        public async Task<ActionResult<PostLikesGetResponse[]>> GetAllPostLikesByUserId([FromQuery] PostLikesGetAllByUserIdRequest request) {
            _logger.LogInformation($"{nameof(GetAllPostLikesByUserId)} controller started in {nameof(LikeController)}");

            PostLikesGetResponse[] responses = await _dbService.GetAllPostLikesByUserId(request);
            return responses;
        }
        
        [HttpGet]
        public async Task<ActionResult<PostLikesGetResponse[]>> GetAllPostLikesByPostId([FromQuery] PostLikesGetAllByPostIdRequest request) {
            _logger.LogInformation($"{nameof(GetAllPostLikesByPostId)} controller started in {nameof(LikeController)}");

            PostLikesGetResponse[] responses = await _dbService.GetAllPostLikesByPostId(request);
            return responses;
        }
        #endregion

        #region CommentLike
        [HttpPost]
        public async Task<ActionResult<CommentLikesAddResponse>> AddCommentLike(CommentLikesAddRequest request) {
            _logger.LogInformation($"{nameof(AddCommentLike)} controller started in {nameof(LikeController)}");

            //CommentLikesAddResponse response = await _dbService.AddCommentLike(request);
            CommentLikesAddResponse? response = await _interactionDbManager.AddCommentLike(request);
            if (response == null) { return BadRequest(); }

            return response;
        }

        [HttpDelete]
        public async Task<ActionResult<CommentLikesDeleteResponse>> DeleteCommentLike(CommentLikesDeleteRequest request) {
            _logger.LogInformation($"{nameof(DeleteCommentLike)} controller started in {nameof(LikeController)}");

            //CommentLikesDeleteResponse? response = await _dbService.DeleteCommentLike(request);
            CommentLikesDeleteResponse? response = await _interactionDbManager.DeleteCommentLike(request);
            if (response == null) {
                return BadRequest("There is no object like specified.");
            }
            return response;
        }

        [HttpDelete]
        public async Task<ActionResult<CommentLikesDeleteResponse[]>> DeleteAllCommentLikesByUserId(CommentLikesDeleteAllByUserIdRequest request) {
            _logger.LogInformation($"{nameof(DeleteAllCommentLikesByUserId)} controller started in {nameof(LikeController)}");

            CommentLikesDeleteResponse[] responses = await _dbService.DeleteAllCommentLikesByUserId(request);
            return responses;
        }

        [HttpDelete]
        public async Task<ActionResult<CommentLikesDeleteResponse[]>> DeleteAllCommentLikesByCommentId(CommentLikesDeleteAllByCommentIdRequest request) {
            _logger.LogInformation($"{nameof(DeleteAllCommentLikesByCommentId)} controller started in {nameof(LikeController)}");

            CommentLikesDeleteResponse[] responses = await _dbService.DeleteAllCommentLikesCommentId(request);
            return responses;
        }

        [HttpGet]
        public async Task<ActionResult<CommentLikesGetResponse>> GetCommentLike([FromQuery] CommentLikesGetRequest request) {
            _logger.LogInformation($"{nameof(GetCommentLike)} controller started in {nameof(LikeController)}");

            CommentLikesGetResponse? response = await _dbService.GetCommentLike(request);
            if (response == null) {
                return BadRequest("There is no object like specified.");
            }
            return response;
        }

        [HttpGet]
        public async Task<ActionResult<CommentLikesGetResponse[]>> GetAllCommentLikesByUserId([FromQuery] CommentLikesGetAllByUserIdRequest request) {
            _logger.LogInformation($"{nameof(GetAllCommentLikesByUserId)} controller started in {nameof(LikeController)}");

            CommentLikesGetResponse[] responses = await _dbService.GetAllCommentLikesByUserId(request);
            return responses;
        }

        [HttpGet]
        public async Task<ActionResult<CommentLikesGetResponse[]>> GetAllCommentLikesByCommentId([FromQuery] CommentLikesGetAllByCommentIdRequest request) {
            _logger.LogInformation($"{nameof(GetAllCommentLikesByCommentId)} controller started in {nameof(LikeController)}");

            CommentLikesGetResponse[] responses = await _dbService.GetAllCommentLikesByCommentId(request);
            return responses;
        }
        #endregion

    }
}
