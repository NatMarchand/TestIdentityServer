using System;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using NatMarchand.Identity4.DataAccess;

namespace NatMarchand.Identity4.BusinessLogic.Identity
{
    public class ProfileService : IProfileService
    {
        private readonly IUsersDal _usersDal;
        private readonly IClaimsDal _claimsDal;

        public ProfileService(IUsersDal usersDal, IClaimsDal claimsDal)
        {
            _usersDal = usersDal;
            _claimsDal = claimsDal;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var claims = await _claimsDal.GetClaimsForUserAsync(Guid.Parse(context.Subject.GetSubjectId()));
            context.IssuedClaims.AddRange(context.FilterClaims(claims.Select(Extensions.Map)));
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            return _usersDal.GetIsUserActiveAsync(Guid.Parse(context.Subject.GetSubjectId()));
        }
    }
}