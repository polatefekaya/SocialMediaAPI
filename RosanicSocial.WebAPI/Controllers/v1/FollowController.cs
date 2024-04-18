using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RosanicSocial.Domain.DTO.Request.Follows;
using RosanicSocial.WebAPI.Controllers;

namespace RosanicSocial.API.Controllers.v1 {
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

        [HttpGet]
        public async Task<ActionResult<FollowsGetFollowingsResponse>> GetFollowings(FollowsGetFollowingsRequest request) {
            return null;
        }

        [HttpGet]
        public async Task<ActionResult<FollowsGetFollowersResponse>> GetFollowers(FollowsGetFollowersRequest request) {
            return null;
        } 
    }
}
