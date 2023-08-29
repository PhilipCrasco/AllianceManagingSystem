using EntityFramework.Dto.User_Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllianceManagementSystem.Wpf.IPresenter.User_Interface
{
    public interface IUserListPresenter
    {
        void DisplayUsers(IReadOnlyList<UserListDto> users);
    }

  


}
