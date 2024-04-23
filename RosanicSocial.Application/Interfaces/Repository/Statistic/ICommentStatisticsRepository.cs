using RosanicSocial.Domain.Data.Entities.Statistic;
using RosanicSocial.Domain.DTO.Request.Statistics.Comment;
using RosanicSocial.Domain.DTO.Response.Statistics.Comment;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Interfaces.Repository.Statistic {
    public interface ICommentStatisticsRepository {
        Task<CommentStatisticsEntity> AddCommentStatistic(CommentStatisticsEntity entity);
        Task<CommentStatisticsEntity> UpdateCommentStatistic(CommentStatisticsEntity entity);
        Task<CommentStatisticsEntity> GetCommentStatistic(int commentId);
        Task<IQueryable<CommentStatisticsEntity>> GetAllCommentStatisticsByUserId(int userId);
        Task<CommentStatisticsEntity> DeleteCommentStatistic(int commentId);
        Task<IQueryable<CommentStatisticsEntity>> DeleteAllCommentStatistics(int userId);
    }
}
