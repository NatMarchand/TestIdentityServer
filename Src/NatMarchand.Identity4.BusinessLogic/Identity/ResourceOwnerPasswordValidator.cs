using System;
using System.Threading.Tasks;
using IdentityServer4.Validation;

namespace NatMarchand.Identity4.BusinessLogic.Identity
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly ILocalIdentityStore _localIdentityStore;

        public ResourceOwnerPasswordValidator(ILocalIdentityStore localIdentityStore)
        {
            _localIdentityStore = localIdentityStore;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var user = await _localIdentityStore.GetUserAsync(context.UserName, context.Password);
            if (user != null)
            {
                context.Result = new GrantValidationResult(user.SubjectId.ToString(), "pwd");
                await _localIdentityStore.ResetFailedAttemptCounterAsync(context.UserName);
            }
            else
            {
                await _localIdentityStore.IncrementFailedAttemptCounterAsync(context.UserName);
            }
        }
    }
}