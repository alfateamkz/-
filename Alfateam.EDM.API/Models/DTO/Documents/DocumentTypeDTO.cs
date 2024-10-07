using Alfateam.Core.Attributes.DTO;
using Alfateam.EDM.Models.Documents;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.EDM.API.Models.DTO.Documents
{
    public class DocumentTypeDTO : DTOModelAbs<DocumentType>
    {
        public string Title { get; set; }
        public string? Description { get; set; }




        /// <summary>
        /// Является ли документ для внутреннего пользования. Если да, то нельзя отсылать документ контрагентам
        /// </summary>
        public bool IsInternalDocument { get; set; }



        /// <summary>
        /// Вшит ли тип документа в систему. Если false, то тип кастомный, создан пользователем
        /// </summary>
        [ForClientOnly]
        public bool IsDefaultType { get; set; }
        public List<DocumentTypeSideDTO> Sides { get; set; } = new List<DocumentTypeSideDTO>();
    }
}
