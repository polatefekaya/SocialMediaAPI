using RosanicSocial.Domain.DTO.Request.Comment;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Interfaces {
    public interface IShareService {
        //Post
        //Comment
        Task ShareComment();
    }
}
