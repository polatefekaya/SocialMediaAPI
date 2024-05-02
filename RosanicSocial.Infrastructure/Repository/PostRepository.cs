using Microsoft.EntityFrameworkCore.ChangeTracking;
using RosanicSocial.Application.Interfaces.Repository;
using RosanicSocial.Domain.Data.Entities.Post;
using RosanicSocial.Infrastructure.DatabaseContext;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Infrastructure.Repository
{
    public class PostRepository : IPostRepository {
        private readonly InfoDbContext _dbContext;
        public PostRepository(InfoDbContext dbContext) {
            _dbContext = dbContext;
        }

        public async Task<PostEntity> AddRose(PostEntity rose) {
            throw new NotImplementedException();
        }

        public async Task<PostEntity> DeleteRose(PostEntity rose) {
            throw new NotImplementedException();
        }

        public async Task<PostEntity> GetRoseById(Guid id) {
            throw new NotImplementedException();    
        }

        public async Task<PostEntity> UpdateRose(PostEntity rose) {
            throw new NotImplementedException();
        }
    }
}
