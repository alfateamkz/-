using Alfateam.Core.Attributes.DTO;
using Alfateam.Marketing.Models.Referral.Main;
using Alfateam.Website.API.Abstractions;
using System.ComponentModel;

namespace Alfateam.Marketing.API.Models.DTO.Referral.Main
{
    public class ReferralUserDTO : DTOModelAbs<ReferralUser>
    {

        //TODO: подстановка имени и т.д., как в обычном юзере


        [ForClientOnly]
        [Description("Рефералы реферала")]
        public List<ReferralUserDTO> Referrals { get; set; } = new List<ReferralUserDTO>();

        [ForClientOnly]
        [Description("Счета реферала")]
        public List<ReferralAccountDTO> Accounts { get; set; } = new List<ReferralAccountDTO>();


        [ForClientOnly]
        [Description("Информация о бане реферала, если он забанен")]
        public ReferralBanInfoDTO? BanInfo { get; set; }
    }
}
