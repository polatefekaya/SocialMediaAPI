using RosanicSocial.Application.Interfaces.Repository;
using RosanicSocial.Domain.Data.Entities;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Infrastructure.Repository {
    public class UserInfoRepository : IUserInfoRepository {
        public Task<BaseInfoEntity> AddBaseInfo(BaseInfoEntity entity) {
            throw new NotImplementedException();
        }

        public Task<DetailedInfoEntity> AddDetailedInfo(DetailedInfoEntity entity) {
            throw new NotImplementedException();
        }

        public Task<BaseInfoEntity> DeleteBaseInfo(int id) {
            throw new NotImplementedException();
        }

        public Task<DetailedInfoEntity> DeleteDetailedInfo(int id) {
            throw new NotImplementedException();
        }

        public Task<BaseInfoEntity> GetBaseInfo(int id) {
            throw new NotImplementedException();
        }

        public Task<DetailedInfoEntity> GetDetailedInfo(int id) {
            throw new NotImplementedException();
        }

        public Task<BaseInfoEntity> UpdateBaseInfo(BaseInfoEntity entity) {
            throw new NotImplementedException();
        }

        public Task<DetailedInfoEntity> UpdateDetailedInfo(DetailedInfoEntity entity) {
            throw new NotImplementedException();
        }
    }
}
