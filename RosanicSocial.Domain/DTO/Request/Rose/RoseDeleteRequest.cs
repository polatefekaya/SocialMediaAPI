using RosanicSocial.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RosanicSocial.Domain.DTO.Request.Rose {
    public class RoseDeleteRequest {
        [Required]
        public Guid Id { get; set; } = Guid.Empty;
        public RoseEntity ToEntity() {
            return new RoseEntity() {

            };
        }
    }
}
