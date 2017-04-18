using System;
using System.Threading.Tasks;
using IdentityServer4.Events;
using IdentityServer4.Services;
using NatMarchand.Identity4.DataAccess;

namespace NatMarchand.Identity4.BusinessLogic
{
    public class EventSink : IEventSink
    {
        private readonly IAuthenticationLogDal _authenticationLogDal;

        public EventSink(IAuthenticationLogDal authenticationLogDal)
        {
            _authenticationLogDal = authenticationLogDal;
        }

        public async Task PersistAsync(Event evt)
        {
            switch (evt)
            {
                case TokenIssuedSuccessEvent tokenIssuedSuccessEvent:
                    await _authenticationLogDal.LogAsync(tokenIssuedSuccessEvent.Map());
                    break;
                case UserLoginSuccessEvent userLoginSuccessEvent:
                    await _authenticationLogDal.LogAsync(userLoginSuccessEvent.Map());
                    break;
            }
        }
    }

    public static partial class Extensions
    {
        public static TokenIssuedLog Map(this TokenIssuedSuccessEvent @event)
        {
            return new TokenIssuedLog
            {
                SubjectId = Guid.Parse(@event.SubjectId),
                ClientId = @event.ClientId,
                Timestamp = @event.TimeStamp,
                Scopes = @event.Scopes,
                IpAddress = @event.RemoteIpAddress
            };
        }

        public static UserLoginLog Map(this UserLoginSuccessEvent @event)
        {
            return new UserLoginLog
            {
                SubjectId = Guid.Parse(@event.SubjectId),
                Provider = @event.Provider,
                Timestamp = @event.TimeStamp,
                IpAddress = @event.RemoteIpAddress,
            };
        }
    }
}
