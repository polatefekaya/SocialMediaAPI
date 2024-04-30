using RosanicSocial.Application.Interfaces.DbServices;
using RosanicSocial.Domain.DTO.Request.Reports.UserWarning;
using RosanicSocial.Domain.DTO.Response.Reports.UserWarning;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Services.DbServices {
    public class UserWarningDbService : IUserWarningDbService {
        public Task<UserWarningAddResponse> AddUserWarning(UserWarningAddRequest request) {
            throw new NotImplementedException();
        }

        public Task<UserWarningDeleteResponse[]> DeleteAllUserWarnings(UserWarningDeleteAllRequest request) {
            throw new NotImplementedException();
        }

        public Task<UserWarningDeleteResponse> DeleteUserWarning(UserWarningDeleteRequest request) {
            throw new NotImplementedException();
        }

        public Task<UserWarningGetResponse[]> GetAllUserWarningsByUserId(UserWarningGetAllByUserIdRequest request) {
            throw new NotImplementedException();
        }

        public Task<UserWarningGetResponse> GetUserWarning(UserWarningGetRequest request) {
            throw new NotImplementedException();
        }

        public Task<UserWarningUpdateResponse> UpdateUserWarning(UserWarningUpdateRequest request) {
            throw new NotImplementedException();
        }
    }
}
