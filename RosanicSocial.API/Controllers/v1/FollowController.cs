using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RosanicSocial.Domain.DTO.Request.Follows;
using RosanicSocial.Domain.DTO.Response.Follows;
using RosanicSocial.WebAPI.Controllers;

namespace RosanicSocial.API.Controllers.v1 {
    [ApiVersion("1.0")]
    public class FollowController : CustomControllerBase {
        public FollowController() {

        }

        //Follow
        //Unfollow
        //Get followings
        //Get followers

        [HttpPost]
        public async Task<ActionResult<FollowsAddResponse>> AddFollow(FollowsAddRequest request) {
            return null;
        }

        [HttpDelete]
        public async Task<ActionResult<FollowsDeleteResponse>> DeleteFollow(FollowsDeleteRequest request) {
            return null;
        }

        #region Get

        [HttpGet]
        public async Task<ActionResult<FollowsGetResponse[]>> GetFollowings(FollowsGetFollowersRequest request) {
            return null;
        }

        [HttpGet]
        public async Task<ActionResult<FollowsGetResponse[]>> GetFollowers(FollowsGetFollowersRequest request) {
            return null;
        } 

        #endregion
    }
}
