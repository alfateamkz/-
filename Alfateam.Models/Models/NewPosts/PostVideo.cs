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
    public class PostVideo : PostItem
    {
        public string ImgPath { get; set; }

        [NotMapped]
        public override string Type => "Video";


        [NotMapped] /// Для фронта, передать чтобы кол-во файлов в инпуте и потом из загрузить на бэке
        public int FilesCount { get; set; }
    }

}
