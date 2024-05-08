using RosanicSocial.Domain.Data.Entities.Post;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Interfaces.Repository
{
    public interface IPostRepository {
        Task<PostEntity?> GetPostById(int id);
        Task<PostEntity[]> GetPostsByUserId(int id);
        Task<PostEntity> AddPost(PostEntity entity);
        Task<PostEntity> DeletePost(int id);
        Task<PostEntity[]> DeleteBatchPost(int[] ids);
        Task<PostEntity[]> DeleteAllPostsByUserId(int id);
        Task<PostEntity?> UpdatePost(PostEntity entity);
    }
}
