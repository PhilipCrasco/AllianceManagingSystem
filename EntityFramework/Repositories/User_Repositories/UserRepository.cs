using Domain.Models.Users;
using EntityFramework.Interface.IUserRepository;
using EntityFramework.StoreContext;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Repositories.User_Repositories
{
    public class UserRepository : IUserRepository
    {
         private readonly Datacontext _context;

        public UserRepository(Datacontext context)
        {
          
                _context = context;
          
        }


        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();

        }




        //public async Task<IReadOnlyList<UserListDto>> UserList()
        //{

        //    var user = _context.Users
        //                              .Select(x => new UserListDto
        //                              {

        //                                  Id = x.Id,
        //                                  FullName = x.Fullname,
        //                                  UserName = x.Username,
        //                                  Role = x.Role.RoleName,
        //                                  DateAdded = x.DateAdded.ToString("MM,dd,yyyy")

        //                              }).ToListAsync();



        //    return await user;

        //}


    }
}
