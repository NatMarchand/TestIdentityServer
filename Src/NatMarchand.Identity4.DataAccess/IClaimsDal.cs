using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NatMarchand.Identity4.DataAccess.Entities;

namespace NatMarchand.Identity4.DataAccess
{
    public interface IClaimsDal
    {
        Task<IReadOnlyList<Claim>> GetClaimsForUserAsync(Guid subjectId);
        Task<Claim> GetClaimForUserAsync(Guid subjectId, string type);
    }
}