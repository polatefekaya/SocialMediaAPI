using RosanicSocial.Application.Interfaces.Repository.Statistic;
using RosanicSocial.Domain.Data.Entities.Statistic;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Infrastructure.Repository {
    public class CommentStatisticsRepository : ICommentStatisticsRepository {
        public Task<CommentStatisticsEntity> AddCommentStatistic(CommentStatisticsEntity entity) {
            throw new NotImplementedException();
        }

        public Task<IQueryable<CommentStatisticsEntity>> DeleteAllCommentStatistics(int userId) {
            throw new NotImplementedException();
        }

        public Task<CommentStatisticsEntity> DeleteCommentStatistic(int commentId) {
            throw new NotImplementedException();
        }

        public Task<IQueryable<CommentStatisticsEntity>> GetAllCommentStatisticsByUserId(int userId) {
            throw new NotImplementedException();
        }

        public Task<CommentStatisticsEntity> GetCommentStatistic(int commentId) {
            throw new NotImplementedException();
        }

        public Task<CommentStatisticsEntity> UpdateCommentStatistic(CommentStatisticsEntity entity) {
            throw new NotImplementedException();
        }
    }
}
