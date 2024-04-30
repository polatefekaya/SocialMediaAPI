using RosanicSocial.Domain.DTO.Request.Reports.UserReport;
using RosanicSocial.Domain.DTO.Response.Reports.UserReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosanicSocial.Application.Interfaces.DbServices {
    internal interface IUserReportDbService {
        Task<UserReportAddResponse> AddUserReport(UserReportAddRequest request);
        //ByReportId
        Task<UserReportGetResponse> GetUserReport(UserReportGetRequest request);
        Task<UserReportGetResponse[]> GetUserReportsByUserId(UserReportGetByUserIdRequest request);
        Task<UserReportUpdateResponse> UpdateUserReport(UserReportUpdateRequest request);
        Task<UserReportDeleteResponse> DeleteUserReport(UserReportDeleteRequest request);
        Task<UserReportDeleteResponse[]> DeleteAllUserReports(UserReportDeleteAllRequest request);
    }
}
