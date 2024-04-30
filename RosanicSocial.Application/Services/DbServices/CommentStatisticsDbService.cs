using RosanicSocial.Application.Interfaces.DbServices;
using RosanicSocial.Domain.DTO.Request.Statistics.Comment;
using RosanicSocial.Domain.DTO.Response.Statistics.Comment;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Services.DbServices {
    public class CommentStatisticsDbService : ICommentStatisticsDbService {
        public Task<CommentStatisticsAddResponse> AddCommentStatistic(CommentStatisticsAddRequest request) {
            throw new NotImplementedException();
        }

        public Task<CommentStatisticsDeleteResponse[]> DeleteAllCommentStatistics(CommentStatisticsDeleteAllRequest request) {
            throw new NotImplementedException();
        }

        public Task<CommentStatisticsDeleteResponse> DeleteCommentStatistic(CommentStatisticsDeleteRequest request) {
            throw new NotImplementedException();
        }

        public Task<CommentStatisticsGetResponse[]> GetAllCommentStatisticsByUserId(CommentStatisticsGetAllByUserIdRequest request) {
            throw new NotImplementedException();
        }

        public Task<CommentStatisticsGetResponse> GetCommentStatistic(CommentStatisticsGetRequest request) {
            throw new NotImplementedException();
        }

        public Task<CommentStatisticsUpdateResponse> UpdateCommentStatistic(CommentStatisticsUpdateRequest request) {
            throw new NotImplementedException();
        }
    }
}
