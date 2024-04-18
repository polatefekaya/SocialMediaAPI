using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RosanicSocial.Domain.DTO.Request.Likes.Comment;
using RosanicSocial.Domain.DTO.Request.Likes.Post;
using RosanicSocial.WebAPI.Controllers;

namespace RosanicSocial.API.Controllers.v1 {
    public class LikeController : CustomControllerBase {
        public LikeController() {

        }

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

    }
}
