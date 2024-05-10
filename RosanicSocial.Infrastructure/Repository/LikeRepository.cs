using Microsoft.EntityFrameworkCore;
using RosanicSocial.Application.Interfaces.Repository;
using RosanicSocial.Domain.Data.Entities.Post;
using RosanicSocial.Infrastructure.DatabaseContext;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Infrastructure.Repository {
    public class LikeRepository : ILikeRepository {
        private readonly InteractionDbContext _db;
        public LikeRepository(InteractionDbContext db) {
            _db = db;
        }
        public async Task<CommentLikesEntity> AddCommentLike(CommentLikesEntity entity) {
            await _db.CommentLikes.AddAsync(entity);
            return entity;
        }

        public async Task<PostLikesEntity> AddPostLike(PostLikesEntity entity) {
            await _db.PostLikes.AddAsync(entity);
            return entity;
        }

        public async Task<CommentLikesEntity[]> DeleteAllCommentLikes(int id) {
            CommentLikesEntity[] entities = await _db.CommentLikes.Where(cl => cl.CommentId == id).ToArrayAsync();
            _db.CommentLikes.RemoveRange(entities);
            await _db.SaveChangesAsync();
            return entities;
        }

        public async Task<PostLikesEntity[]> DeleteAllPostLikes(int id) {
            PostLikesEntity[] entities = await _db.PostLikes.Where(pl => pl.PostId == id).ToArrayAsync();
            _db.PostLikes.RemoveRange(entities);
            await _db.SaveChangesAsync();
            return entities;
        }

        public Task<CommentLikesEntity> DeleteCommentLike(int id) {
            //_db.CommentLikes.Remove(id);
        }

        public Task<PostLikesEntity> DeletePostLike(int id) {
            throw new NotImplementedException();
        }

        public Task<CommentLikesEntity[]> GetAllCommentLikes(int id) {
            throw new NotImplementedException();
        }

        public Task<PostLikesEntity[]> GetAllPostLikes(int id) {
            throw new NotImplementedException();
        }

        public Task<CommentLikesEntity> GetCommentLike(int id) {
            throw new NotImplementedException();
        }

        public Task<PostLikesEntity> GetPostLike(int id) {
            throw new NotImplementedException();
        }
    }
}
