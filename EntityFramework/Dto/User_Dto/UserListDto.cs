using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Dto.User_Dto
{
    public class UserListDto
    {

        public int Id { get; set; }
        public string FullName { get; set; }

        public string UserName { get; set; }

        public string Role { get; set; }

        public string DateAdded { get; set; }



    }
}
