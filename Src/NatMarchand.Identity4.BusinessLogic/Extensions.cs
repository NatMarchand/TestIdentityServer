using System;
using IdentityServer4.Models;
using NatMarchand.Identity4.DataAccess.Entities;

namespace NatMarchand.Identity4.BusinessLogic
{
    public static partial class Extensions
    {
        public static PersistedGrant Map(this Grant grant)
        {
            if (grant == null)
                return null;

            return new PersistedGrant
            {
                Key = grant.Key,
                ClientId = grant.ClientId,
                Type = grant.Type,
                SubjectId = grant.SubjectId.ToString(),
                CreationTime = grant.CreationTime.UtcDateTime,
                Data = grant.Data,
                Expiration = grant.Expiration?.UtcDateTime
            };
        }

        public static Grant Map(this PersistedGrant grant)
        {
            if (grant == null)
                return null;

            return new Grant
            {
                Key = grant.Key,
                ClientId = grant.ClientId,
                Type = grant.Type,
                SubjectId = Guid.Parse(grant.SubjectId),
                CreationTime = grant.CreationTime,
                Data = grant.Data,
                Expiration = grant.Expiration
            };
        }

        public static System.Security.Claims.Claim Map(Claim c)
        {
            return new System.Security.Claims.Claim(c.Type, c.Value);
        }
    }
}