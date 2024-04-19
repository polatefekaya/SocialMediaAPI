using RosanicSocial.Domain.Data.Entities;
using RosanicSocial.Domain.DTO.Request.Info.Base;
using RosanicSocial.Domain.DTO.Request.Info.Detailed;
using RosanicSocial.Domain.DTO.Response.Info.Base;
using RosanicSocial.Domain.DTO.Response.Info.Detailed;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Interfaces.DbServices {
    public interface IUserInfoDbService {
        #region BaseInfo
        Task<BaseInfoAddResponse> AddBaseInfo(BaseInfoAddRequest request);
        Task<BaseInfoGetResponse> GetBaseInfo(BaseInfoGetRequest request);
        Task<BaseInfoUpdateResponse> UpdateBaseInfo(BaseInfoUpdateRequest request);
        Task<BaseInfoDeleteResponse> DeleteBaseInfo(BaseInfoDeleteRequest request);
        #endregion

        #region DetailedInfo
        Task<DetailedInfoAddResponse> AddDetailedInfo(DetailedInfoAddRequest request);
        Task<DetailedInfoGetResponse> GetDetailedInfo(DetailedInfoGetRequest request);
        Task<DetailedInfoUpdateResponse> UpdateDetailedInfo(DetailedInfoUpdateRequest request);
        Task<DetailedInfoDeleteResponse> DeleteDetailedInfo(DetailedInfoDeleteRequest request);
        #endregion
    }
}
