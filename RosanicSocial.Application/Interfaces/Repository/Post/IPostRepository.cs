using RosanicSocial.Domain.Data.Entities.Post;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Interfaces.Repository
{
    public interface IPostRepository {
        Task<PostEntity?> GetRoseById(int id);
        Task<PostEntity[]> GetPostsByUserId(int id);
        Task<PostEntity> AddRose(PostEntity rose);
        Task<PostEntity> DeleteRose(PostEntity rose);
        Task<PostEntity?> UpdateRose(PostEntity rose);
    }
}
