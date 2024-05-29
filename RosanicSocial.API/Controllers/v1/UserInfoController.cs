using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RosanicSocial.Application.Filters;
using RosanicSocial.Application.Interfaces.DbServices;
using RosanicSocial.Domain.DTO.Request.Info.Base;
using RosanicSocial.Domain.DTO.Request.Info.Detailed;
using RosanicSocial.Domain.DTO.Response.Info.Base;
using RosanicSocial.Domain.DTO.Response.Info.Detailed;
using RosanicSocial.WebAPI.Controllers;

namespace RosanicSocial.API.Controllers.v1 {
    [ApiVersion("1.0")]
    public class UserInfoController : CustomControllerBase {
        private readonly IUserInfoDbService _dbService;
        public UserInfoController(IUserInfoDbService dbService) {
            _dbService = dbService;
        }

        #region Base

        //AddBaseInfo Post
        [HttpPost]
        public async Task<ActionResult<BaseInfoAddResponse>> AddBaseInfo(BaseInfoAddRequest request) {
            BaseInfoAddResponse response = await _dbService.AddBaseInfo(request);
            return Ok(response);
        }

        //GetBaseInfo Get
        [HttpGet]        
        public async Task<ActionResult<BaseInfoGetResponse>> GetBaseInfo([FromQuery] BaseInfoGetRequest request) {
            BaseInfoGetResponse response = await _dbService.GetBaseInfo(request);
            return Ok(response);
        }
        //UpdateBaseInfo Put
        [HttpPut]
        public async Task<ActionResult<BaseInfoUpdateResponse>> UpdateBaseInfo(BaseInfoUpdateRequest request) {
            BaseInfoUpdateResponse response = await _dbService.UpdateBaseInfo(request);
            return Ok(response);
        }

        //DeleteBaseInfo Delete
        [HttpDelete]
        public async Task<ActionResult<BaseInfoDeleteResponse>> DeleteBaseInfo(BaseInfoDeleteRequest request) {
            BaseInfoDeleteResponse response = await _dbService.DeleteBaseInfo(request);
            return Ok(response);
        }


        #endregion

        #region Detailed

        [HttpPost]
        [TypeFilter(typeof(AccountUserRelationsActionFilter))]
        public async Task<ActionResult<DetailedInfoAddResponse>> AddDetailedInfo(DetailedInfoAddRequest request) {
            DetailedInfoAddResponse response = await _dbService.AddDetailedInfo(request);
            return Ok(response);
        }

        [HttpGet]
        [TypeFilter(typeof(AccountUserRelationsActionFilter))]
        public async Task<ActionResult<DetailedInfoGetResponse>> GetDetailedInfo([FromQuery] DetailedInfoGetRequest request) {
            DetailedInfoGetResponse response = await _dbService.GetDetailedInfo(request);
            return Ok(response);
        }
        
        [HttpPut]
        [TypeFilter(typeof(AccountUserRelationsActionFilter))]
        public async Task<ActionResult<DetailedInfoUpdateResponse>> UpdateDetailedInfo(DetailedInfoUpdateRequest request) {
            DetailedInfoUpdateResponse response = await _dbService.UpdateDetailedInfo(request);
            return Ok(response);
        }

        [HttpDelete]
        [TypeFilter(typeof(AccountUserRelationsActionFilter))]
        public async Task<ActionResult<DetailedInfoDeleteResponse>> DeleteDetailedInfo(DetailedInfoDeleteRequest request) {
            DetailedInfoDeleteResponse response = await _dbService.DeleteDetailedInfo(request);
            return Ok(response);
        }
        #endregion

    }
}
