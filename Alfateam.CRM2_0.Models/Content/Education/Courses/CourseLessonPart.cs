using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Abstractions.Content.Education.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Content.Education.Courses
{
    /// <summary>
    /// Сущность части урока курса
    /// </summary>
    public class CourseLessonPart : AbsModel
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public List<CourseLessonBlock> Blocks { get; set; } = new List<CourseLessonBlock>();
    }
}
