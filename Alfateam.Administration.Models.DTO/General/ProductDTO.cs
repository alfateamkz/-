using Alfateam.Administration.Models.Enums;
using Alfateam.Administration.Models.General;
using Alfateam.Core.Attributes.DTO;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Administration.Models.DTO.General
{
    public class ProductDTO : DTOModelAbs<Product>
    {
        public string Title { get; set; }
        public ProductType Type { get; set; }
        public string Identifier { get; set; }


        [ForClientOnly]
        public string? ImagePath { get; set; }
        public string Description { get; set; }
    }
}
