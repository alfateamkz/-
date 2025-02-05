using Alfateam.SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Administration.Models.Abstractions
{
    public class BlogPostBlockWithFile : BlogPostBlock
    {
        public UploadedFile File { get; set; }
        public string FileId { get; set; }
    }
}
