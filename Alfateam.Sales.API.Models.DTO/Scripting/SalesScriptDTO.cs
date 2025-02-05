using Alfateam.Core.Attributes.DTO;
using Alfateam.Sales.Models.Scripting;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Sales.API.Models.DTO.Scripting
{
    public class SalesScriptDTO : DTOModelAbs<SalesScript>
    {
        public string Title { get; set; }
        public string? Description { get; set; }


        /// <summary>
        /// Начало скрипта
        /// </summary>
        [ForClientOnly]
        public SalesScriptBlockDTO StartBlock { get; set; }
    }
}
