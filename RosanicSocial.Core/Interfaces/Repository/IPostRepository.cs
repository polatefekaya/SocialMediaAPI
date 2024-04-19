using RosanicSocial.Domain.Data.Entities.Post;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Interfaces.Repository
{
    public interface IPostRepository {
        Task<RoseEntity> GetRoseById(Guid id);
        Task<RoseEntity> AddRose(RoseEntity rose);
        Task<RoseEntity> DeleteRose(RoseEntity rose);
        Task<RoseEntity> UpdateRose(RoseEntity rose);
    }
}
