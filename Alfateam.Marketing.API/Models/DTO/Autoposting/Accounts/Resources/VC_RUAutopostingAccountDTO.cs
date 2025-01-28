using Alfateam.Marketing.API.Models.DTO.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.Autoposting.Accounts.Resources
{
    public class VC_RUAutopostingAccountDTO : AutopostingAccountDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
