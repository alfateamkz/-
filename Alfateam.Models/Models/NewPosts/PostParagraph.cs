using Alfateam.Database.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Database.Models.NewPosts
{
    public class PostParagraph : PostItem
    {
        public string Text { get; set; }

        [NotMapped]
        public override string Type => "Paragraph";
    }
}
