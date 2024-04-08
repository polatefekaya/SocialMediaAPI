using RosanicSocial.Domain.Models;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Response.Rose {
    public class RoseGetResponse {

    }

    public static partial class RoseExtensions {
        public static RoseGetResponse ToGetResponse (this RoseEntity response) {
            return new RoseGetResponse {

            };
        }
    }
}
