using RosanicSocial.Domain.DTO.Request.Statistics.Comment;
using RosanicSocial.Domain.DTO.Response.Statistics.Comment;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Interfaces.DbServices {
    public interface ICommentStatisticsDbService {
        Task<CommentStatisticsAddResponse> AddCommentStatistic(CommentStatisticsAddRequest request);
        Task<CommentStatisticsUpdateResponse> UpdateCommentStatistic(CommentStatisticsUpdateRequest request);
        Task<CommentStatisticsGetResponse> GetCommentStatistic(CommentStatisticsGetRequest request);
        Task<CommentStatisticsGetResponse[]> GetAllCommentStatisticsByUserId(CommentStatisticsGetAllByUserIdRequest request);
        Task<CommentStatisticsDeleteResponse> DeleteCommentStatistic(CommentStatisticsDeleteRequest request);
        Task<CommentStatisticsDeleteResponse[]> DeleteAllCommentStatistics(CommentStatisticsDeleteAllRequest request);
    }
}
