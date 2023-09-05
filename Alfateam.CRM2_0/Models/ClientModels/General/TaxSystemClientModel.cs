using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.General;

namespace Alfateam.CRM2_0.Models.ClientModels.General
{
    //TODO: доработать модель с наследниками
    public class TaxSystemClientModel : ClientModel<TaxSystem>
    {
        public string Title { get; set; }
        public string? Description { get; set; }



        /// <summary>
        /// Может ли режим применяться для всех правовых форм
        /// </summary>
        public bool IsAllowedForAllLegalForms { get; set; } = true;

        /// <summary>
        /// Правовые формы, для которых может применяться режим. 
        /// Режим может применяться для всех, если список - пустой или IsAllowedForAllLegalForms = true
        /// </summary>
        public List<LegalFormClientModel> AllowedLegalForms { get; set; } = new List<LegalFormClientModel>();

    }
}
