using RosanicSocial.Application.Interfaces.DbServices;
using RosanicSocial.Domain.DTO.Request.Statistics.Post;
using RosanicSocial.Domain.DTO.Response.Statistics.Post;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Services.DbServices {
    public class PostStatisticsDbService : IPostStatisticsDbService {
        public Task<PostStatisticsAddResponse> AddPostStatistic(PostStatisticsAddRequest request) {
            throw new NotImplementedException();
        }

        public Task<PostStatisticsDeleteResponse[]> DeleteAllPostStatisticsByUserId(PostStatisticsDeleteAllRequest request) {
            throw new NotImplementedException();
        }

        public Task<PostStatisticsDeleteResponse> DeletePostStatistic(PostStatisticsDeleteRequest request) {
            throw new NotImplementedException();
        }

        public Task<PostStatisticsGetResponse[]> GetAllPostStatisticsByUserId(PostStatisticsGetAllByUserIdRequest request) {
            throw new NotImplementedException();
        }

        public Task<PostStatisticsGetResponse> GetPostStatistic(PostStatisticsGetRequest request) {
            throw new NotImplementedException();
        }

        public Task<PostStatisticsUpdateResponse> UpdatePostStatistic(PostStatisticsUpdateRequest request) {
            throw new NotImplementedException();
        }
    }
}
