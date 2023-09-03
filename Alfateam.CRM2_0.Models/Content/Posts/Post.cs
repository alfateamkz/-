using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Content.Posts
{
    /// <summary>
    /// Модель новостной записи
    /// </summary>
    public class Post : ContentModel
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string ImagePath { get; set; }

        public string Content { get; set; }


        public int Watches { get; set; }
        
        public PostCategory Category { get; set; }

    }
}
