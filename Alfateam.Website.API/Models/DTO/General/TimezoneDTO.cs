using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.General;

namespace Alfateam.Website.API.Models.DTO.General
{
    public class TimezoneDTO : DTOModel<Alfateam2._0.Models.General.TimeZone>
    {
        public string Title { get; set; }
        public TimeSpan Offset { get; set; }


        public int MainLanguageId { get; set; }
    }
}
