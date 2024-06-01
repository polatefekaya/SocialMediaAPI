using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RosanicSocial.Application.Interfaces.Repository;
using RosanicSocial.Domain.Data.Entities.Post;
using RosanicSocial.Infrastructure.DatabaseContext;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Infrastructure.Repository {
    public class LikeRepository : ILikeRepository {
        private readonly InteractionDbContext _db;
        private readonly ILogger<LikeRepository> _logger;
        public LikeRepository(InteractionDbContext db, ILogger<LikeRepository> logger) {
            _db = db;
            _logger = logger;
        }
        public async Task<CommentLikesEntity?> AddCommentLike(CommentLikesEntity entity) {
            _logger.LogDebug($"{nameof(AddCommentLike)} in {nameof(LikeRepository)} is started.");

            _logger.LogInformation($"Controlling the {nameof(_db.CommentLikes)} db for preventing duplicate records.");
            CommentLikesEntity? entityFromDb = await GetCommentLike(entity.CommentId, entity.UserId);

            if (entityFromDb is not null) {
                _logger.LogError($"Duplicate record found in {nameof(_db.CommentLikes)}, returning null.");
                return null;
            }

            await _db.CommentLikes.AddAsync(entity);
            await _db.SaveChangesAsync();

            _logger.LogInformation($"{nameof(AddCommentLike)} in {nameof(LikeRepository)} is finished.");
            return entity;
        }

        public async Task<PostLikesEntity?> AddPostLike(PostLikesEntity entity) {
            _logger.LogDebug($"{nameof(AddPostLike)} in {nameof(LikeRepository)} is started.");

            _logger.LogInformation($"Controlling the {nameof(_db.PostLikes)} db for preventing duplicate records.");
            PostLikesEntity? entityFromDb = await GetPostLike(entity.PostId, entity.UserId);

            if (entityFromDb is not null) {
                _logger.LogError($"Duplicate record found in {nameof(_db.PostLikes)}, returning null.");
                return null;
            }

            await _db.PostLikes.AddAsync(entity);
            await _db.SaveChangesAsync();

            _logger.LogInformation($"{nameof(AddPostLike)} in {nameof(LikeRepository)} is finished.");
            return entity;
        }

        public async Task<CommentLikesEntity[]> DeleteAllCommentLikesByCommentId(int id) {
            CommentLikesEntity[] entities = await _db.CommentLikes.Where(cl => cl.CommentId == id).ToArrayAsync();
            _db.CommentLikes.RemoveRange(entities);
            await _db.SaveChangesAsync();
            return entities;
        }

        public async Task<CommentLikesEntity[]> DeleteAllCommentLikesByUserId(int id) {
            CommentLikesEntity[] entities = await _db.CommentLikes.Where(cl => cl.UserId == id).ToArrayAsync();
            _db.CommentLikes.RemoveRange(entities);
            await _db.SaveChangesAsync();
            return entities;
        }

        public async Task<PostLikesEntity[]> DeleteAllPostLikesByPostId(int id) {
            PostLikesEntity[] entities = await _db.PostLikes.Where(pl => pl.PostId == id).ToArrayAsync();
            _db.PostLikes.RemoveRange(entities);
            await _db.SaveChangesAsync();
            return entities;
        }

        public async Task<PostLikesEntity[]> DeleteAllPostLikesByUserId(int id) {
            PostLikesEntity[] entities = await _db.PostLikes.Where(pl => pl.UserId == id).ToArrayAsync();
            _db.PostLikes.RemoveRange(entities);
            await _db.SaveChangesAsync();
            return entities;
        }

        public async Task<CommentLikesEntity?> DeleteCommentLike(int commentId, int userId) {
            CommentLikesEntity? entity = await _db.CommentLikes.SingleOrDefaultAsync(cl => cl.CommentId == commentId && cl.UserId == userId);
            if (entity == null) return null;
            _db.CommentLikes.Remove(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<PostLikesEntity?> DeletePostLike(int postId, int userId) {
            PostLikesEntity? entity = await _db.PostLikes.SingleOrDefaultAsync(pl => pl.PostId ==  postId && pl.UserId == userId);
            if (entity == null) return null;
            _db.PostLikes.Remove(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<CommentLikesEntity[]> GetAllCommentLikesByCommentId(int id) {
            CommentLikesEntity[] entities = await _db.CommentLikes.Where(cl => cl.CommentId == id).ToArrayAsync();
            return entities;
        }

        public async Task<CommentLikesEntity[]> GetAllCommentLikesByUserId(int id) {
            CommentLikesEntity[] entities = await _db.CommentLikes.Where(cl => cl.UserId == id).ToArrayAsync();
            return entities;
        }


        public async Task<PostLikesEntity[]> GetAllPostLikesByPostId(int id) {
            PostLikesEntity[] entities = await _db.PostLikes.Where(pl =>  pl.PostId == id).ToArrayAsync();
            return entities;
        }

        public async Task<PostLikesEntity[]> GetAllPostLikesByUserId(int id) {
            PostLikesEntity[] entities = await _db.PostLikes.Where(pl => pl.UserId == id).ToArrayAsync();
            return entities;
        }

        public async Task<CommentLikesEntity?> GetCommentLike(int commentId, int userId) {
            CommentLikesEntity? entity = await _db.CommentLikes.SingleOrDefaultAsync(cl => cl.UserId == userId && cl.CommentId == commentId);
            return entity;
        }


        public async Task<PostLikesEntity?> GetPostLike(int postId, int userId) {
            PostLikesEntity? entity = await _db.PostLikes.SingleOrDefaultAsync(pl => pl.PostId ==  postId && pl.UserId == userId);
            return entity;
        }
    }
}
