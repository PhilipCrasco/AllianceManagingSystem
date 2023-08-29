using Domain.Models.Users;
using EntityFramework.Interface.ILoginRepository;
using EntityFramework.StoreContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Repositories.Login_Repositories
{
    public class LoginRepository : ILoginRepository
    {

        private readonly Datacontext _context;

        public LoginRepository(Datacontext context)
        {
            _context = context;
        }

        public async Task<User> GetUserForLogin(string username)
        {
            return await  _context.Users.FirstOrDefaultAsync(x => x.Username == username );
        }
    }
}
