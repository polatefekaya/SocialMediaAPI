using RosanicSocial.Domain.DTO.Response.Post;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Interfaces.Helpers.Managers {
    public interface IInteractionDbManagerHelperService {
        Task<PostUpdateResponse?> UpdatePost(int postId, int change);
    }
}
