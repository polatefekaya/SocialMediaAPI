using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RosanicSocial.Domain.Data.Identity;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Infrastructure.DatabaseContext {
    public class UserIdentityDbContext : IdentityDbContext<ApplicationUser,ApplicationRole, int> {
        public UserIdentityDbContext(DbContextOptions<UserIdentityDbContext> options) : base(options) {

        }
        public UserIdentityDbContext() {

        }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("Identity");
        }
    }
}
