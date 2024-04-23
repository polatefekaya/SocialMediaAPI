using RosanicSocial.Domain.Data.Entities.Statistic;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Interfaces.Repository.Statistic {
    public interface IProfileSeenRepository {
        Task<ProfileSeenEntity> AddProfileSeen(ProfileSeenEntity entity);
        Task<IQueryable<ProfileSeenEntity>> GetAllProfileSeensByUserId(int userId);
        Task<IQueryable<ProfileSeenEntity>> DeleteAllProfileSeensByUserId(int userId);
    }
}
