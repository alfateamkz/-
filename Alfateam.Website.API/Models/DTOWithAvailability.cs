using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Models.DTO.General;
using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.General;

namespace Alfateam.Website.API.Models
{
    public class DTOWithAvailability<T> where T : AbsModel, new()
    {
        public DTOModel<T> Model { get; set; }
        public AvailabilityDTO Availability { get; set; }


        public Availability GetAvailability()
        {
            return Availability.CreateDBModelFromDTO();
        }
    }
}
