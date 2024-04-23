using RosanicSocial.Application.Interfaces.Repository.Statistic;
using RosanicSocial.Domain.Data.Entities.Statistic;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Infrastructure.Repository {
    public class PostStatisticsRepository : IPostStatisticsRepository {
        public Task<PostStatisticsEntity> AddPostStatistic(PostStatisticsEntity entity) {
            throw new NotImplementedException();
        }

        public Task<IQueryable<PostStatisticsEntity>> DeleteAllPostStatisticsByUserId(int userId) {
            throw new NotImplementedException();
        }

        public Task<PostStatisticsEntity> DeletePostStatistic(int postId) {
            throw new NotImplementedException();
        }

        public Task<IQueryable<PostStatisticsEntity>> GetAllPostStatisticsByUserId(int userId) {
            throw new NotImplementedException();
        }

        public Task<PostStatisticsEntity> GetPostStatistic(int postId) {
            throw new NotImplementedException();
        }

        public Task<PostStatisticsEntity> UpdatePostStatistic(PostStatisticsEntity entity) {
            throw new NotImplementedException();
        }
    }
}
