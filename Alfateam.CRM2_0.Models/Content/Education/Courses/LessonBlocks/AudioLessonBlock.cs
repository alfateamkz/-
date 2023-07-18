using Alfateam.CRM2_0.Models.Abstractions.Content.Education.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Content.Education.Courses.LessonBlocks
{
    /// <summary>
    /// Составная единица урока, представляющая собой аудиозапист
    /// </summary>
    public class AudioLessonBlock : CourseLessonBlock
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public string AudioPath { get; set; }
    }
}
