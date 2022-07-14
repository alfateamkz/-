using Alfateam.Database.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Database.Models.General
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        public UserRole UserRole { get; set; } = UserRole.User;

        public string Name { get; set; }
        public string Surname { get; set; }


        public string Email { get; set; }
        public string Password { get; set; }
    }
}
