using EntityFramework.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Services
{
    public interface IUserService
    {

        Task<AuthenticateResponse> Authenticate(AuthenticateRequest request);

    }
}
