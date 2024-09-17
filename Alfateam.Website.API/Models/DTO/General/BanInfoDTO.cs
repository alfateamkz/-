using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models.General;

namespace Alfateam.Website.API.Models.DTO.General
{
    public class BanInfoDTO : DTOModel<BanInfo>
    {
        public BanType Type { get; set; }
        public string Reason { get; set; }
        public DateTime BanBefore { get; set; }
    }
}
