using RosanicSocial.Domain.Models;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Response.Rose {
    public class RoseUpdateResponse {

    }

    public static partial class RoseExtensions {
        public static RoseUpdateResponse ToUpdateResponse (this RoseEntity respone) {
            return new RoseUpdateResponse() {

            };
        }
    }
}
