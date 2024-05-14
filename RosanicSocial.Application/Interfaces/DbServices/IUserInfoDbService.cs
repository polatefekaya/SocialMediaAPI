using RosanicSocial.Domain.Data.Entities;
using RosanicSocial.Domain.DTO.Request.Info.Base;
using RosanicSocial.Domain.DTO.Request.Info.Detailed;
using RosanicSocial.Domain.DTO.Response.Info.Base;
using RosanicSocial.Domain.DTO.Response.Info.Detailed;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Interfaces.DbServices {
    /// <summary>
    /// CRUD operations for Like Entity.
    /// <para>
    ///    BaseInfo Functionality:
    /// </para>
    /// <list type="bullet">
    /// <item>Add</item>
    /// <item>Get</item>
    /// <item>Update</item>
    /// <item>Delete</item>
    /// </list>
    /// 
    /// <para>
    ///    DetailedInfo Functionality:
    /// </para>
    /// <list type="bullet">
    /// <item>Add</item>
    /// <item>Get</item>
    /// <item>Update</item>
    /// <item>Delete</item>
    /// </list>
    /// This DbService calls Repository interfaces for it's db processes
    /// </summary>
    public interface IUserInfoDbService {
        #region BaseInfo
        Task<BaseInfoAddResponse> AddBaseInfo(BaseInfoAddRequest request);
        Task<BaseInfoGetResponse?> GetBaseInfo(BaseInfoGetRequest request);
        Task<BaseInfoUpdateResponse?> UpdateBaseInfo(BaseInfoUpdateRequest request);
        Task<BaseInfoDeleteResponse?> DeleteBaseInfo(BaseInfoDeleteRequest request);
        Task<BaseInfoUpdateResponse?> UpdateBaseInfoPostCount(BaseInfoUpdatePostCountRequest request);
        #endregion

        #region DetailedInfo
        Task<DetailedInfoAddResponse> AddDetailedInfo(DetailedInfoAddRequest request);
        Task<DetailedInfoGetResponse?> GetDetailedInfo(DetailedInfoGetRequest request);
        Task<DetailedInfoUpdateResponse?> UpdateDetailedInfo(DetailedInfoUpdateRequest request);
        Task<DetailedInfoDeleteResponse?> DeleteDetailedInfo(DetailedInfoDeleteRequest request);
        #endregion
    }
}
