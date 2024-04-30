using RosanicSocial.Domain.DTO.Request.Reports.UserWarning;
using RosanicSocial.Domain.DTO.Response.Reports.UserWarning;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Interfaces.DbServices {
    public interface IUserWarningDbService {
        Task<UserWarningAddResponse> AddUserWarning(UserWarningAddRequest request);
        Task<UserWarningGetResponse> GetUserWarning(UserWarningGetRequest request);
        Task<UserWarningGetResponse[]> GetAllUserWarningsByUserId(UserWarningGetAllByUserIdRequest request);
        Task<UserWarningUpdateResponse> UpdateUserWarning(UserWarningUpdateRequest request);
        Task<UserWarningDeleteResponse[]> DeleteAllUserWarnings(UserWarningDeleteAllRequest request);
        Task<UserWarningDeleteResponse> DeleteUserWarning(UserWarningDeleteRequest request);
    }
}
