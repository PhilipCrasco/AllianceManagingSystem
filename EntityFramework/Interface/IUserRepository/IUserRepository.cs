using Domain.Models.Users;
using EntityFramework.Dto.User_Dto;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Interface.IUserRepository
{
    public interface IUserRepository
    {

        Task<List<User>> GetAllUsersAsync();



    }
}
