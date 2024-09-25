using Alfateam.Core;
using Alfateam.ID.Models.Abstractions;
using Alfateam.ID.Models.Enums;
using Alfateam.ID.Models.Payments;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alfateam.ID.Models
{
    public class User : AbsModel
    {

        public string Guid { get; set; } = System.Guid.NewGuid().ToString();

        public string Surname { get; set; }
        public string Name { get; set; }
        public string? Patronymic { get; set; }



        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }


        public bool IsEmailVerified { get; set; }
        public bool IsPhoneVerified { get; set; }

        [NotMapped]
        public bool IsVerified => IsEmailVerified && IsPhoneVerified;


        public string CountryCode { get; set; }
        public string LanguageCode { get; set; }

        public List<Payment> Payments { get; set; } = new List<Payment>();
        public List<BindedPaymentWay> PaymentWays { get; set; } = new List<BindedPaymentWay>();



        public string GetContact(VerificationType type)
        {
            if (type == VerificationType.Email)
            {
                return Email;
            }
            else if (type == VerificationType.Phone)
            {
                return Phone;
            }

            throw new NotImplementedException();
        }
    }
}
