using Microsoft.EntityFrameworkCore;
using RosanicSocial.Application.Interfaces.Creators;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Interfaces.Factories {
    public interface IDbTableCreatorFactoryService {
        public IDbTableCreatorService Build(string filePath, ref ModelBuilder modelBuilder);
    }
}
