using Alfateam.Core.Helpers;
using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.Localization.Items;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.ServicePages
{
    public class ServicePage : AvailabilityModel
    {
        [NotMapped]
        public string Slug => $"{SlugHelper.GetLatynSlug(MainBlockHeader)}-{Id}";



        public string MainBlockHeader { get; set; }
        public string MainBlockShortText { get; set; }
        public string MainBlockImgPath { get; set; }

        public List<ServicePageServiceRibbonItem> ServiceRibbonItems { get; set; } = new List<ServicePageServiceRibbonItem>();


        public string Block2Col1HTMLContent { get; set; }
        public string Block2Col2HTMLContent { get; set; }


        public List<ServicePageStackIcon> StackIcons { get; set; } = new List<ServicePageStackIcon>();
        public List<ServicePageFakeReview> Reviews { get; set; } = new List<ServicePageFakeReview>();



        public List<ServicePageLocalization> Localizations { get; set; } = new List<ServicePageLocalization>();

    }
}
