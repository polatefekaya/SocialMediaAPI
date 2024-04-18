using RosanicSocial.Domain.Data.Entites.Post;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Response.Rose
{
    public class RoseAddResponse {


    }

    public static partial class RoseExtensions {
        public static RoseAddResponse ToAddResponse(this RoseEntity response) {
            return new RoseAddResponse {

            };
        }
    }
}
