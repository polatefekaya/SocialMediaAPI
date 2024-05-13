using RosanicSocial.Domain.Data.Entities;
using RosanicSocial.Domain.DTO.Request.Follows;
using RosanicSocial.Domain.DTO.Response.Follows;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Interfaces.DbServices {
    /// <summary>
    /// CRUD operations for Follow Entity.
    /// <list type="bullet">
    /// <item>Add</item>
    /// <item>GetFollowers</item>
    /// <item>GetFollowings</item>
    /// <item>Delete</item>
    /// <item>DeleteAll</item>
    /// </list>
    /// This DbService calls Repository interfaces for it's db processes
    /// </summary>
    public interface IFollowDbService {
        /// <summary>
        /// Adds the Follow Entity to database and returns it.     
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<FollowsAddResponse> AddFollow(FollowsAddRequest request);
        /// <summary>
        /// Gets the Followers for given User from database. With user's <paramref name="id"/>.
        /// <paramref name="id"/> is must given with <paramref name="request"/>
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<FollowsGetResponse> GetFollow(FollowsGetIsFollowingRequest request);
        /// <summary>
        /// Gets the Followers for given User from database. With user's <paramref name="id"/>.
        /// <paramref name="id"/> is must given with <paramref name="request"/>
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<FollowsGetResponse[]> GetFollowers(FollowsGetFollowersRequest request);
        /// <summary>
        /// Gets the Followings for given User from database. With user's <paramref name="id"/>.
        /// <paramref name="id"/> is must given with <paramref name="request"/>
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<FollowsGetResponse[]> GetFollowings(FollowsGetFollowingsRequest request);
        /// <summary>
        /// Deletes the Follow Entity from database by it's <paramref name="id"/>.
        /// <paramref name="id"/> is must given with <paramref name="request"/>
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<FollowsDeleteResponse> DeleteFollow(FollowsDeleteRequest request);
        /// <summary>
        /// Deletes all the Follow Entities from database by user's <paramref name="id"/>.
        /// <paramref name="id"/> is must given with <paramref name="request"/>
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<FollowsDeleteResponse[]> DeleteAllFollows(FollowsDeleteAllRequest request);
    }
}
