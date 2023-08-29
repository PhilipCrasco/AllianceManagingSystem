using EntityFramework.Interface.IUserRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Services
{
    public interface IUnitofwork
    {
        IUserRepository Users { get; }



        Task CompleteAsync();


    }
}
