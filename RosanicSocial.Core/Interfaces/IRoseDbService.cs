using System;
using System.Collections.Generic;
using RosanicSocial.Domain.Models;

namespace RosanicSocial.Application.Interfaces {
    public interface IRoseDbService {
        Task<Rose> GetRose(string id);
        Task DeleteRose(string id);
        void PutRose(Rose rose);
        void AddRose(Rose rose);
    }
}
