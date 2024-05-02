using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RosanicSocial.Application.Services.Creators;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Interfaces.Creators {
    public interface IDbTableCreatorService {
        /// <summary>
        /// Adds table with specified seed data
        /// </summary>
        /// <param name="seedFileName">Name of the Json file that has the seed data</param>
        public void AddTableWithSeed<T>(string seedFileName) where T : class;
        public EntityTypeBuilder<T> AddTable<T>(string? name = null) where T : class;
        public DbTableCreatorService TableWithOptions(DbTableOptions options);
    }
}
