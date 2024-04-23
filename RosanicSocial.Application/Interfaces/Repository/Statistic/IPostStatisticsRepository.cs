using RosanicSocial.Domain.Data.Entities.Statistic;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Interfaces.Repository.Statistic {
    public interface IPostStatisticsRepository {
        Task<PostStatisticsEntity> AddPostStatistic(PostStatisticsEntity entity);
        Task<PostStatisticsEntity> UpdatePostStatistic(PostStatisticsEntity entity);
        Task<PostStatisticsEntity> DeletePostStatistic(int postId);
        Task<PostStatisticsEntity> GetPostStatistic(int postId);
        Task<IQueryable<PostStatisticsEntity>> GetAllPostStatisticsByUserId(int userId);
        Task<IQueryable<PostStatisticsEntity>> DeleteAllPostStatisticsByUserId(int userId);
    }
}
