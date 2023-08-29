using Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Interface.ILoginRepository
{
    public interface ILoginRepository
    {

        Task <User> GetUserForLogin(string username);

    }
}
