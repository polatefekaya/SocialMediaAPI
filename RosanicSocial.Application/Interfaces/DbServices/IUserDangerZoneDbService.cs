using RosanicSocial.Domain.DTO.Request.Reports.DangerZone;
using RosanicSocial.Domain.DTO.Response.Reports.DangerZone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosanicSocial.Application.Interfaces.DbServices {
    internal interface IUserDangerZoneDbService {
        Task<DangerzoneAddResponse> AddDangerzone(DangerzoneAddRequest request);
        Task<DangerzoneGetResponse> GetDangerzone(DangerzoneGetRequest request);
        Task<DangerzoneDeleteResponse> DeleteDangerzone(DangerzoneDeleteRequest request);
        Task<DangerzoneUpdateResponse> UpdateDangerzone(DangerzoneUpdateRequest request);
    }
}
