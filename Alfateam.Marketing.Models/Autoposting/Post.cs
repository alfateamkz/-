using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Autoposting
{
    public class Post : AbsModel
    {
        public string Content { get; set; }
        public List<PostAttachment> Attachments { get; set; } = new List<PostAttachment>();


        public DateTime PublishAt { get; set; }
        public DateTime? PublishedAt { get; set; }


        

        public TimeSpan? DeleteIn { get; set; }
        public DateTime? DeletedPostAtSourceAt { get; set; }




        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int ContentPlanId { get; set; }

    }
}
