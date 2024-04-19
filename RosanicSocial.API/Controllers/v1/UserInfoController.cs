using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RosanicSocial.Domain.DTO.Request.Info.Base;
using RosanicSocial.Domain.DTO.Request.Info.Detailed;
using RosanicSocial.Domain.DTO.Response.Info.Base;
using RosanicSocial.Domain.DTO.Response.Info.Detailed;
using RosanicSocial.WebAPI.Controllers;

namespace RosanicSocial.API.Controllers.v1 {
    public class UserInfoController : CustomControllerBase {
        public UserInfoController() {

        }

        #region Base

        //AddBaseInfo Post
        [HttpPost]
        public async Task<ActionResult<BaseInfoAddResponse>> AddBaseInfo(BaseInfoAddRequest request) {
            return null;
        }

        //GetBaseInfo Get
        [HttpGet]
        public async Task<ActionResult<BaseInfoGetResponse>> GetBaseInfo(BaseInfoGetRequest request) {
            return null;
        }
        //UpdateBaseInfo Put
        [HttpPut]
        public async Task<ActionResult<BaseInfoUpdateResponse>> UpdateBaseInfo(BaseInfoUpdateRequest request) {
            return null;
        }

        //DeleteBaseInfo Delete
        [HttpDelete]
        public async Task<ActionResult<BaseInfoDeleteResponse>> DeleteBaseInfo(BaseInfoDeleteRequest request) {
            return null;
        }


        #endregion

        #region Detailed

        [HttpPost]
        public async Task<ActionResult<DetailedInfoAddResponse>> AddDetailedInfo(DetailedInfoAddRequest request) {
            return null;
        }

        [HttpGet]
        public async Task<ActionResult<DetailedInfoGetResponse>> GetDetailedInfo(DetailedInfoGetRequest request) {
            return null;
        }
        
        [HttpPut]
        public async Task<ActionResult<DetailedInfoUpdateResponse>> UpdateDetailedInfo(DetailedInfoUpdateRequest request) {
            return null;
        }

        [HttpDelete]
        public async Task<ActionResult<DetailedInfoDeleteResponse>> DeleteDetailedInfo(DetailedInfoDeleteRequest request) {
            return null;
        }
        #endregion

    }
}
