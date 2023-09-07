using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.General.Verification
{
    /// <summary>
    /// Модель верификационного кода
    /// </summary>
    public class VerificationCode : AbsModel
    {
        public VerificationType Type { get; set; } 
        public string Contact { get; set; }

        public string Code { get; set; } = GenerateNumberCode(6);
        public string Message { get; set; }


        public bool IsVerified { get; set; }
        public DateTime? VerifiedAt { get; set; }


        public DateTime ExpiresAt { get; set; } = DateTime.UtcNow.AddMinutes(10);

        [NotMapped]
        public bool IsExpired => ExpiresAt < DateTime.UtcNow;

        public static string GenerateNumberCode(int length)
        {
            string code = "";

            char[] chars = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            var random = new Random();
           

            for(int i = 0; i < length; i++)
            {
                code += chars[random.Next(0, chars.Length - 1)];
            }

            return code;
        }
    }
}
