using RosanicSocial.Domain.DTO.Request.Statistics.Comment;
using RosanicSocial.Domain.DTO.Response.Statistics.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosanicSocial.Application.Interfaces.DbServices {
    internal interface ICommentStatisticsDbService {
        Task<CommentStatisticsAddResponse> AddCommentStatistic(CommentStatisticsAddRequest request);
        Task<CommentStatisticsUpdateResponse> UpdateCommentStatistic(CommentStatisticsUpdateRequest request);
        Task<CommentStatisticsGetResponse> GetCommentStatistic(CommentStatisticsGetRequest request);
        Task<CommentStatisticsGetAllByUserIdResponse> GetAllCommentStatisticsByUserId(CommentStatisticsGetAllByUserIdRequest request);
        Task<CommentStatisticsDeleteResponse> DeleteCommentStatistic(CommentStatisticsDeleteRequest request);
        Task<CommentStatisticsDeleteAllRequest> DeleteAllCommentStatistics(CommentStatisticsDeleteAllRequest request);
    }
}
