using Alfateam.Core.Helpers;
using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.ServicePages;
using Alfateam2._0.Models.Team;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Items
{
    public class ServicePageLocalization : LocalizableModel
    {
        public string MainBlockHeader { get; set; }
        public string MainBlockShortText { get; set; }

        public List<ServicePageServiceRibbonItem> ServiceRibbonItems { get; set; } = new List<ServicePageServiceRibbonItem>();


        public string Block2Col1HTMLContent { get; set; }
        public string Block2Col2HTMLContent { get; set; }


        public List<ServicePageFakeReview> Reviews { get; set; } = new List<ServicePageFakeReview>();



        [NotMapped]
        public string Slug => $"{SlugHelper.GetLatynSlug(MainBlockHeader)}-{ServicePageId}";


        public int ServicePageId { get; set; }
    }
}
