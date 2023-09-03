using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Filters;
using Alfateam.CRM2_0.Models.ClientModels.Content.Videos;
using Alfateam.CRM2_0.Models.Content.Education.Courses;
using Alfateam.CRM2_0.Models.Content.Videos;
using Alfateam.CRM2_0.Models.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Alfateam.CRM2_0.Controllers.Content.Education
{
    [AccessActionFilter(roles: UserRole.ContentMaker)]
    public class CoursesController : AbsController
    {
        public CoursesController(ControllerParams @params) : base(@params)
        {
        }

        //[HttpGet,Route("GetCourses")]
        //public async Task<RequestResult> GetCourses(int offset, int count = 20)
        //{
        //    return GetAvailableMany<Course, CourseClientModel>(DB.Courses, offset, count);
        //}

    }
}
