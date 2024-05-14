using RosanicSocial.Domain.DTO.Request.Likes.Comment;
using RosanicSocial.Domain.DTO.Request.Likes.Post;
using RosanicSocial.Domain.DTO.Response.Likes.Comment;
using RosanicSocial.Domain.DTO.Response.Likes.Post;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Interfaces.Managers {
    public interface IInteractionDbManagerService {
        Task<PostLikesAddResponse?> AddPostLike(PostLikesAddRequest request);
        Task<PostLikesDeleteResponse?> DeletePostLike(PostLikesDeleteRequest request);
        Task<CommentLikesAddResponse?> AddCommentLike(CommentLikesAddRequest request);
        Task<CommentLikesDeleteResponse?> DeleteCommentLike(CommentLikesDeleteRequest request);
    }
}
