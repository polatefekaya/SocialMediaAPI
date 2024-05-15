using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RosanicSocial.Application.Interfaces.DbServices;
using RosanicSocial.Application.Interfaces.Managers;
using RosanicSocial.Domain.DTO.Request.Follows;
using RosanicSocial.Domain.DTO.Response.Follows;
using RosanicSocial.WebAPI.Controllers;

namespace RosanicSocial.API.Controllers.v1 {
    [ApiVersion("1.0")]
    public class FollowController : CustomControllerBase {
        private readonly IFollowDbService _dbService;
        private readonly IInteractionDbManagerService _interactionDbManager;
        public FollowController(IFollowDbService dbService, IInteractionDbManagerService interactionDbManager) {
            _dbService = dbService;
            _interactionDbManager = interactionDbManager;
        }

        //Follow
        //Unfollow
        //Get followings
        //Get followers

        [HttpPost]
        public async Task<ActionResult<FollowsAddResponse?>> AddFollow(FollowsAddRequest request) {
            FollowsAddResponse? response = await _interactionDbManager.AddFollow(request);
            if (response != null) { 
                return Ok(response);
            }
            return Problem("Error occured while following");
        }

        [HttpDelete]
        public async Task<ActionResult<FollowsDeleteResponse?>> DeleteFollow(FollowsDeleteRequest request) {
            FollowsDeleteResponse? response = await _interactionDbManager.DeleteFollow(request);
            if (response != null) {
                return Ok(response);
            }
            return Problem("Error occured while unfollowing");
        }

        [HttpDelete]
        public async Task<ActionResult<FollowsDeleteResponse[]>> DeleteAllFollows(FollowsDeleteAllRequest request) {
            FollowsDeleteResponse[] responses = await _dbService.DeleteAllFollows(request);
            return Ok(responses);
        }


        #region Get
        [HttpGet]
        public async Task<ActionResult<FollowsGetResponse?>> GetIsFollow([FromQuery] FollowsGetIsFollowingRequest request) {
            FollowsGetResponse? response = await _dbService.GetFollow(request);
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<FollowsGetResponse[]>> GetFollowings([FromQuery] FollowsGetFollowingsRequest request) {
            FollowsGetResponse[] responses = await _dbService.GetFollowings(request);
            return Ok(responses);
        }

        [HttpGet]
        public async Task<ActionResult<FollowsGetResponse[]>> GetFollowers([FromQuery] FollowsGetFollowersRequest request) {
            FollowsGetResponse[] responses = await _dbService.GetFollowers(request);
            return Ok(responses);
        } 

        #endregion
    }
}
