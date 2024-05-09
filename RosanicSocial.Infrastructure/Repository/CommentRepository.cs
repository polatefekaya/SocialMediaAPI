using Microsoft.EntityFrameworkCore;
using RosanicSocial.Application.Interfaces.Repository.Post;
using RosanicSocial.Domain.Data.Entities.Post;
using RosanicSocial.Infrastructure.DatabaseContext;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Infrastructure.Repository
{
    public class CommentRepository : ICommentRepository {
        private readonly SharingsDbContext _db;
        public CommentRepository(SharingsDbContext db) {
            _db = db;
        }
        public async Task<CommentEntity> AddComment(CommentEntity comment) {
            await _db.Comments.AddAsync(comment);
            await _db.SaveChangesAsync();
            return comment;
        }

        public async Task<CommentEntity[]> DeleteAllComments(int id) {
            CommentEntity[] entities = await _db.Comments.Where(e => e.UserId == id).ToArrayAsync();
            _db.Comments.RemoveRange(entities);
            await _db.SaveChangesAsync();
            return entities;
        }

        public async Task<CommentEntity?> DeleteComment(int id) {
            CommentEntity? entity = await _db.Comments.SingleOrDefaultAsync(e => e.Id == id);
            if (entity == null) {
                return null;
            }
            _db.Comments.Remove(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<CommentEntity[]> GetAllCommentsByPostId(int postId) {
            CommentEntity[] entities = await _db.Comments.Where(e => e.PostId == postId).ToArrayAsync();
            return entities;
        }

        public async Task<CommentEntity[]> GetAllCommentsByUserId(int userId) {
            CommentEntity[] entities = await _db.Comments.Where(e => e.UserId == userId).ToArrayAsync();
            return entities;
        }

        public async Task<CommentEntity?> GetComment(int id) {
            CommentEntity? entity = await _db.Comments.SingleOrDefaultAsync(e => e.Id == id);
            return entity;
        }

        public async Task<CommentEntity> UpdateComment(CommentEntity comment) {
            _db.Comments.Update(comment);
            await _db.SaveChangesAsync();
            return comment;
        }
    }
}
