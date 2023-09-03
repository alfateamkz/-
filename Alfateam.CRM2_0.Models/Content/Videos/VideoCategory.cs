using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Content.Videos
{
    /// <summary>
    /// Сущность категории видеозаписи
    /// </summary>
    public class VideoCategory : ContentModel
    {
        public string Title { get; set; }
    }
}
