using System;
using System.Collections.Generic;
using RosanicSocial.Domain.Models;
using RosanicSocial.Domain.DTO.Request.Rose;
using RosanicSocial.Domain.DTO.Response.Rose;

namespace RosanicSocial.Application.Interfaces {
    public interface IRoseDbService {
        Task<RoseGetResponse> GetRose(RoseGetRequest request);
        Task<RoseDeleteResponse> DeleteRose(RoseDeleteRequest request);
        Task<RoseUpdateResponse> UpdateRose(RoseUpdateRequest request);
        Task<RoseAddResponse> AddRose(RoseAddRequest request);
    }
}
