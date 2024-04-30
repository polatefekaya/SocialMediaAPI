using RosanicSocial.Domain.Data.Entities.Post;
using System;
using System.Collections;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Response.Comment {
    public class CommentGetAllByPostIdResponse {
        public CommentEntity[]? comments { get; set; }
    }
    public static partial class CommentEntityExtensions {
        public static CommentGetAllByPostIdResponse ToGetAllByPostIdResponse(this CommentEntity[] entityArray) {
            return new CommentGetAllByPostIdResponse {
                comments = entityArray;
            };
        }
    }
}
