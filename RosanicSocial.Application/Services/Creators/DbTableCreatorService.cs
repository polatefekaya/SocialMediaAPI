using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using RosanicSocial.Application.Interfaces.Creators;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace RosanicSocial.Application.Services.Creators {
    public class DbTableCreatorService : IDbTableCreatorService {
        private  string _filePath;
        private ModelBuilder _modelBuilder;
        private DbTableOptions _options;

        public DbTableCreatorService Set(string filePath, ref ModelBuilder modelBuilder) {
            _filePath = filePath;
            _modelBuilder = modelBuilder;
            return this;
        } 
        public EntityTypeBuilder<T> AddTable<T>(string? name = null) where T : class {
            if (name is not null) return _modelBuilder.Entity<T>().ToTable(name);
            return _modelBuilder.Entity<T>();
        }

        public void AddTableWithSeed<T>(string seedFileName) where T : class {
            //json operations
            string readJson = File.ReadAllText(Path.Combine(_filePath, (seedFileName.ToLower() + ".json")));

            T? deserializedJson = JsonConvert.DeserializeObject<T>(readJson);
            if(deserializedJson is null) throw new NullReferenceException();

            _modelBuilder.Entity<T>().ToTable(seedFileName).HasData(deserializedJson);
        }
        public virtual DbTableCreatorService TableWithOptions(DbTableOptions options) {
            _options = options;
            return this;
        }
    }
    public class DbTableOptions {
        public string? HasMany {  get; set; }
        public string? HasOne { get; set; }
        public string? WithOne { get; set; }
        public string? WithMany { get; set; }

        public DbTableOptions(string? hasMany, string? hasOne, string? withOne, string? withMany) {
            HasMany = hasMany;
            HasOne = hasOne;
            WithOne = withOne;
            WithMany = withMany;
        }
    }
}
