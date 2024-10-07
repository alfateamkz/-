using Alfateam.EDM.API.Models.DTO.Abstractions;
using Alfateam.EDM.API.Models.DTO.Documents;
using Alfateam.EDM.Models;
using Alfateam.EDM.Models.ApprovalRoutes;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.EDM.API.Models.DTO.ApprovalRoutes
{
    public class ApprovalRouteDocConditionDTO : DTOModelAbs<ApprovalRouteDocCondition>
    {
        /// <summary>
        /// Если пусто, то для всех типов документов применяется условие
        /// </summary>
        public List<DocumentTypeDTO> DocumentTypes { get; set; } = new List<DocumentTypeDTO>();

        /// <summary>
        /// Если пусто, то для всех контрагентов применяется условие
        /// </summary>
        public List<CounterpartyDTO> Counterparties { get; set; } = new List<CounterpartyDTO>();

        /// <summary>
        /// Если пусто, то для всех групп контрагентов применяется условие
        /// </summary>
        public List<CounterpartyGroupDTO> CounterpartyGroups { get; set; } = new List<CounterpartyGroupDTO>();
    }
}
