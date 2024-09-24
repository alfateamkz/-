using Alfateam.ID.Models.Abstractions;
using Alfateam.ID.Models.Payments;

namespace Alfateam.ID.Models
{
    public class User : AbsModel
    {

        public string Surname { get; set; }
        public string Name { get; set; }
        public string? Patronymic { get; set; }



        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }


        public string CountryCode { get; set; }

        public List<Payment> Payments { get; set; } = new List<Payment>();
        public List<BindedPaymentWay> PaymentWays { get; set; } = new List<BindedPaymentWay>();
    }
}
