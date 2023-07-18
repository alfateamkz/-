using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Abstractions.Content.Education.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Content.Education.Courses.LessonBlocks
{
    /// <summary>
    /// Составная единица урока, представляющая собой видео
    /// </summary>
    public class VideoLessonBlock : CourseLessonBlock
    {
        public string Title { get; set; }
        public string? Description { get; set; }


        public string VideoPath { get; set; }
    }
}
