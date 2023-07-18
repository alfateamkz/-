using Alfateam.CRM2_0.Models.Abstractions.Content.Education.Courses;
using Alfateam.CRM2_0.Models.Content.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Content.Education.Courses.LessonBlocks
{
    /// <summary>
    /// Составная единица урока, представляющая собой тест
    /// </summary>
    public class TestLessonBlock : CourseLessonBlock
    {
        public Test Test { get; set; }
    }
}
