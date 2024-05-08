using RosanicSocial.Application.Interfaces;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Services {
    public class EntityConvertService : IEntityConvertService {
        public async Task<TResponse[]> ToResponseAsync<TResponse, TEntity>(TEntity[] entities, Func<TEntity, TResponse> process) {
            TResponse[] responses = new TResponse[entities.Length];

            await Task.Run(() => {
                for (int i = 0; i < entities.Length; i++) {
                    responses[i] = process(entities[i]);
                }
            });

            return responses;
        }

        public async Task<TResponse> ToResponseAsync<TResponse, TEntity>(TEntity entity, Func<TEntity, TResponse> process) {
            TResponse response = process(entity);
            return response;
        }
    }
}
