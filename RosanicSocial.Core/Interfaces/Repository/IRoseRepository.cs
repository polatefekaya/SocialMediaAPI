using RosanicSocial.Domain.Models;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Interfaces.Repository {
    public interface IRoseRepository {
        Task<RoseEntity> GetRoseById(Guid id);
        Task<RoseEntity> AddRose(RoseEntity rose);
        Task<RoseEntity> DeleteRose(RoseEntity rose);
        Task<RoseEntity> UpdateRose(RoseEntity rose);
    }
}
