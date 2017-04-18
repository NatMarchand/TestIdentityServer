using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NatMarchand.Identity4.DataAccess.Entities;

namespace NatMarchand.Identity4.DataAccess
{
    public interface IGrantsDal
    {
        Task UpsertAsync(Grant grant);
        Task<Grant> GetAsync(string key);
        Task<IReadOnlyList<Grant>> GetAllAsync(Guid subjectId);
        Task RemoveAsync(string key);
        Task RemoveAllAsync(Guid subjectId, string clientId, string type = null);
    }
}