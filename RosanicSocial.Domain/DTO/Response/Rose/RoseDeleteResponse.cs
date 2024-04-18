using System;
using System.Collections.Generic;
using RosanicSocial.Domain.Data.Entites.Post;

namespace RosanicSocial.Domain.DTO.Response.Rose
{
    public class RoseDeleteResponse {

    }

    public static partial class RoseExtensions {
        public static RoseDeleteResponse ToDeleteResponse(this RoseEntity response) {
            return new RoseDeleteResponse {

            };
        }
    }
}
