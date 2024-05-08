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

        public async Task<PostEntity> AddPost(PostEntity post) {
            await _db.Posts.AddAsync(post);
            await _db.SaveChangesAsync();
            return post;
        }

        public async Task<PostEntity> DeletePost(int id) {
            PostEntity? entity = await _db.Posts.FindAsync(id);
            if (entity is null) {
                return null;
            }

            _db.Posts.Remove(entity);
            await _db.SaveChangesAsync();

            return entity;
        }

        public async Task<PostEntity[]> GetPostsByUserId(int id) {
            return await _db.Posts.Where(p => p.UserId == id).ToArrayAsync();
        }

        public async Task<PostEntity?> GetPostById(int id) {
            PostEntity? tempPost = await _db.Posts.SingleOrDefaultAsync(p => p.Id == id);
            return tempPost;
        }

        public async Task<PostEntity?> UpdatePost(PostEntity post) {
            _db.Posts.Update(post);
            await _db.SaveChangesAsync();
            throw new NotImplementedException();
        }

        public async Task<PostEntity[]> DeleteBatchPost(int[] ids) {
            PostEntity[] postEntities = await _db.Posts.Where(p => ids.Contains(p.Id)).ToArrayAsync();

            _db.Posts.RemoveRange(postEntities);
            await _db.SaveChangesAsync();

            return postEntities;
        }

        public async Task<PostEntity[]> DeleteAllPostsByUserId(int id) {
            PostEntity[] entities = await _db.Posts.Where(p => p.UserId == id).ToArrayAsync();
            _db.Posts.RemoveRange(entities);
            await _db.SaveChangesAsync();
            return entities;
        }
    }
}
