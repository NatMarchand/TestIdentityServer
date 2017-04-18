using System;
using System.Threading.Tasks;
using NatMarchand.Identity4.BusinessLogic;

namespace NatMarchand.Identity4.DataAccess
{
    public interface IAuthenticationLogDal
    {
        Task LogAsync(TokenIssuedLog tokenIssuedLog);
        Task LogAsync(UserLoginLog tokenIssuedLog);
    }
}