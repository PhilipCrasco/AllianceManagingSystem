using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Users
{
    public class User : BaseEntity
    {

        public string Fullname { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        [Column(TypeName = "Date")]
        public DateTime DateAdded { get; set; } = DateTime.Now;

        public bool IsActive { get; set; }

        public Role Role { get; set; }


    }
}
