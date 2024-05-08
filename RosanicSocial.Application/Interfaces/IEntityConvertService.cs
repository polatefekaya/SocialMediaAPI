using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Interfaces {
    public interface IEntityConvertService {
        Task<TResponse[]> ToResponseAsync<TResponse, TEntity>(TEntity[] entities, Func<TEntity,TResponse> process);
        Task<TResponse> ToResponseAsync<TResponse, TEntity>(TEntity entity, Func<TEntity,TResponse> process);
    }
}
