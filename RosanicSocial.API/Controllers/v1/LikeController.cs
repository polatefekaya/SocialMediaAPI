using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RosanicSocial.Domain.DTO.Request.Likes.Comment;
using RosanicSocial.Domain.DTO.Request.Likes.Post;
using RosanicSocial.Domain.DTO.Response.Likes.Comment;
using RosanicSocial.Domain.DTO.Response.Likes.Post;
using RosanicSocial.WebAPI.Controllers;

namespace RosanicSocial.API.Controllers.v1 {
    [ApiVersion("1.0")]
    public class LikeController : CustomControllerBase {
        public LikeController() {

        }

        #region PostLike
        [HttpPost]
        public async Task<ActionResult<PostLikesAddResponse>> AddPostLike(PostLikesAddRequest request) {
            return null;
        }

        [HttpDelete]
        public async Task<ActionResult<PostLikesDeleteResponse>> DeletePostLike(PostLikesDeleteRequest request) {
            return null;
        }

        [HttpGet]
        public async Task<ActionResult<PostLikesGetResponse>> GetPostLikes(PostLikesGetRequest request) {
            return null;
        }
        #endregion

        #region CommentLike
        [HttpPost]
        public async Task<ActionResult<CommentLikesAddResponse>> AddCommentLike(CommentLikesAddRequest request) {
            return null;
        }


        [HttpDelete]
        public async Task<ActionResult<CommentLikesDeleteResponse>> DeleteCommentLike(CommentLikesDeleteRequest request) {
            return null;
        }

        [HttpGet]
        public async Task<ActionResult<CommentLikesGetResponse>> GetCommentLikes(CommentLikesGetRequest request) {
            return null;
        }
        #endregion

    }
}
