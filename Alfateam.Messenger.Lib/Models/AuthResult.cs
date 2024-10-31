using Alfateam.Messenger.Lib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Lib.Models
{
    public class AuthResult
    {
        public AuthResultType Type { get; set; }
        public string? Message { get; set; }


        public static AuthResult Create(AuthResultType type)
        {
            return new AuthResult
            {
                Type = type,
            };
        }
        public static AuthResult Create(AuthResultType type, string message)
        {
            return new AuthResult
            {
                Type = type,
                Message = message
            };
        }
    }
}
