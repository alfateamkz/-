using Alfateam.Core.Attributes.DTO;
using Alfateam.EDM.API.Models.DTO.General.Subjects;
using Alfateam.EDM.Models.Abstractions;
using Alfateam.EDM.Models.General.Subjects;
using Alfateam.Website.API.Abstractions;
using JsonKnownTypes;
using Newtonsoft.Json;

namespace Alfateam.EDM.API.Models.DTO.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<EDMSubjectDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(CompanyDTO), "Company")]
    [JsonKnownType(typeof(IndividualDTO), "Individual")]
    public class EDMSubjectDTO : DTOModelAbs<EDMSubject>
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }


        [DTOFieldFor(DTOFieldForType.CreationOnly)]
        public string CountryCode { get; set; }




        /// <summary>
        /// ИНН (в РФ), БИН\ИИН (в КЗ), в других странах может быть другое
        /// </summary>
        [DTOFieldFor(DTOFieldForType.CreationOnly)]
        public string BusinessNumber { get; set; }


        [ForClientOnly]
        public string? LogoPath { get; set; }
        public string? Description { get; set; }





        /// <summary>
        /// Подтверждена ли компания. Если нет, то она не сможет принимать участие в документообороте. 
        /// Чтобы смогла, нужно подтвердить владение компанией
        /// </summary>
        [ForClientOnly]
        public bool IsVerified { get; set; }
    }
}
