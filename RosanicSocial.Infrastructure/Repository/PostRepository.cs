using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Internal;
using RosanicSocial.Application.Interfaces.Repository;
using RosanicSocial.Domain.Data.Entities.Post;
using RosanicSocial.Infrastructure.DatabaseContext;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Infrastructure.Repository
{
    public class PostRepository : IPostRepository {
        private readonly SharingsDbContext _db;
        public PostRepository(SharingsDbContext db) {
            _db = db;
        }

        public async Task<PostEntity> AddRose(PostEntity post) {
            await _db.Posts.AddAsync(post);
            await _db.SaveChangesAsync();
            return post;
        }

        public async Task<PostEntity> DeleteRose(PostEntity post) {
            _db.Posts.Remove(post);
            await _db.SaveChangesAsync();

            return post;
        }

        public async Task<PostEntity[]> GetPostsByUserId(int id) {
            return await _db.Posts.Where(p => p.UserId == id).ToArrayAsync();
        }

        public async Task<PostEntity?> GetRoseById(int id) {
            PostEntity? tempPost = await _db.Posts.SingleOrDefaultAsync(p => p.Id == id);
            return tempPost;
        }

        public async Task<PostEntity?> UpdateRose(PostEntity post) {
            _db.Posts.Update(post);
            await _db.SaveChangesAsync();
            throw new NotImplementedException();
        }
    }
}
