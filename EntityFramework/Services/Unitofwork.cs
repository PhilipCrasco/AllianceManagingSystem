
using EntityFramework.Interface.IUserRepository;
using EntityFramework.Repositories.User_Repositories;
using EntityFramework.StoreContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Services
{
    public class Unitofwork : IUnitofwork
    {
        private readonly Datacontext _context;


        public IUserRepository Users { get;  set; }


        public Unitofwork(Datacontext context)
        {
            _context = context;


            Users = new UserRepository(_context);
            
        }



        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
