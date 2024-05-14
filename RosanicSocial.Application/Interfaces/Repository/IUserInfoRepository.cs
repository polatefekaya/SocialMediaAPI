using System;
using System.Collections.Generic;
using RosanicSocial.Domain.Data.Entities;

namespace RosanicSocial.Application.Interfaces.Repository {
    public interface IUserInfoRepository {
        #region BaseInfo

        Task<BaseInfoEntity?> AddBaseInfo(BaseInfoEntity entity);
        Task<BaseInfoEntity?> GetBaseInfo(int id);
        Task<BaseInfoEntity> UpdateBaseInfo(BaseInfoEntity entity);
        Task<BaseInfoEntity?> DeleteBaseInfo(int id);

        #endregion

        #region DetailedInfo

        Task<DetailedInfoEntity?> AddDetailedInfo(DetailedInfoEntity entity);
        Task<DetailedInfoEntity?> GetDetailedInfo(int id);
        Task<DetailedInfoEntity> UpdateDetailedInfo(DetailedInfoEntity entity);
        Task<DetailedInfoEntity?> DeleteDetailedInfo(int id);

        #endregion
    }
}
