using Alfateam.CRM2_0.Models.Abstractions.Content.Education.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Content.Education.Courses.LessonBlocks
{
    /// <summary>
    /// Составная единица урока, представляющая собой текстовое содержимое
    /// </summary>
    public class TextLessonBlock : CourseLessonBlock
    {
        public string Content { get; set; }
    }
}
