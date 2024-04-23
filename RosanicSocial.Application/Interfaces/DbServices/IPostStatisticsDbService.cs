using RosanicSocial.Domain.DTO.Request.Statistics.Post;
using RosanicSocial.Domain.DTO.Response.Statistics.Post;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Interfaces.DbServices {
    public interface IPostStatisticsDbService {
        Task<PostStatisticsAddResponse> AddPostStatistic(PostStatisticsAddRequest request);
        Task<PostStatisticsUpdateResponse> UpdatePostStatistic(PostStatisticsUpdateRequest request);
        Task<PostStatisticsDeleteResponse> DeletePostStatistic(PostStatisticsDeleteRequest request);
        Task<PostStatisticsDeleteAllResponse> DeleteAllPostStatisticsByUserId(PostStatisticsDeleteAllRequest request);
        Task<PostStatisticsGetAllByUserIdResponse> GetAllPostStatisticsByUserId(PostStatisticsGetAllByUserIdRequest request);
    }
}
