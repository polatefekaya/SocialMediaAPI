using Microsoft.EntityFrameworkCore;
using RosanicSocial.Application.Interfaces.Creators;
using RosanicSocial.Application.Interfaces.Factories;
using RosanicSocial.Application.Services.Creators;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Services.Factories {
    public class DbTableCreatorFactoryService : IDbTableCreatorFactoryService {
        public IDbTableCreatorService Build(string filePath, ref ModelBuilder modelBuilder) {
            return new DbTableCreatorService().Set(filePath, ref modelBuilder);
        }
    }
}
