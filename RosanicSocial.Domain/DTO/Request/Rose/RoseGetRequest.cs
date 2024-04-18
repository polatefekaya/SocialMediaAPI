using RosanicSocial.Domain.Data.Entites.Post;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RosanicSocial.Domain.DTO.Request.Rose
{
    public class RoseGetRequest {
        [Required]
        public Guid Id { get; set; } = Guid.Empty;
        public RoseEntity ToEntity() {
            return new RoseEntity() {

            };
        }
    }
}
