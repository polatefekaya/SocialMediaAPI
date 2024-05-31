using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RosanicSocial.Application.Interfaces.DbServices;
using RosanicSocial.Domain.DTO.Request.Reports.Block;
using RosanicSocial.Domain.DTO.Response.Reports.Block;
using RosanicSocial.WebAPI.Controllers;

namespace RosanicSocial.API.Controllers.v1 {
    [ApiVersion("1.0")]
    public class UserBlockController : CustomControllerBase {
        private readonly IUserBlockDbService _userBlockDbService;
        private readonly ILogger<UserBlockController> _logger;

        public UserBlockController(IUserBlockDbService userBlockDbService, ILogger<UserBlockController> logger) {
            _userBlockDbService = userBlockDbService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<BlockGetResponse>> GetBlock([FromQuery] BlockGetRequest request) {
            _logger.LogInformation($"{nameof(GetBlock)} request is started in {nameof(UserBlockController)}.");

            _logger.LogInformation($"{nameof(_userBlockDbService.GetBlock)} in {nameof(IUserBlockDbService)} is starting.");
            BlockGetResponse? response = await _userBlockDbService.GetBlock(request);
            if (response is null) {
                _logger.LogError($"No response returned from {nameof(_userBlockDbService.GetBlock)} in {nameof(IUserBlockDbService)}.");
                return NotFound("The Block Entity that you are looking for is not found.");
            }

            _logger.LogInformation($"{nameof(GetBlock)} request is finished.");
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<BlockGetResponse[]>> GetAllBlocks([FromQuery] BlockGetAllRequest request) {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<ActionResult<BlockAddResponse>> AddBlock(BlockAddRequest request) {
            _logger.LogInformation($"{nameof(AddBlock)} request is started in {nameof(UserBlockController)}.");

            _logger.LogInformation($"{nameof(_userBlockDbService.AddBlock)} in {nameof(IUserBlockDbService)} is starting.");
            BlockAddResponse? response = await _userBlockDbService.AddBlock(request);
            if (response is null) {
                _logger.LogError($"No response returned from {nameof(_userBlockDbService.AddBlock)} in {nameof(IUserBlockDbService)}.");
                return NotFound("Can't be able to add this Block Entity.");
            }

            _logger.LogInformation($"{nameof(AddBlock)} request is finished.");
            return Ok(response);
        }

        [HttpDelete]
        public async Task<ActionResult<BlockDeleteResponse>> DeleteBlock(BlockDeleteRequest request) {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public async Task<ActionResult<BlockDeleteResponse[]>> DeleteAllBlocks(BlockDeleteAllRequest request) {
            throw new NotImplementedException();
        }
    }
}
