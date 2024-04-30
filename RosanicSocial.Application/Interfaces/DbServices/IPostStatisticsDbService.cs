using RosanicSocial.Domain.DTO.Request.Statistics.Post;
using RosanicSocial.Domain.DTO.Response.Statistics.Post;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Interfaces.DbServices {
    public interface IPostStatisticsDbService {
        Task<PostStatisticsAddResponse> AddPostStatistic(PostStatisticsAddRequest request);
        Task<PostStatisticsUpdateResponse> UpdatePostStatistic(PostStatisticsUpdateRequest request);
        Task<PostStatisticsDeleteResponse> DeletePostStatistic(PostStatisticsDeleteRequest request);
        Task<PostStatisticsDeleteResponse[]> DeleteAllPostStatisticsByUserId(PostStatisticsDeleteAllRequest request);
        Task<PostStatisticsGetResponse[]> GetAllPostStatisticsByUserId(PostStatisticsGetAllByUserIdRequest request);
        Task<PostStatisticsGetResponse> GetPostStatistic(PostStatisticsGetRequest request);
    }
}
