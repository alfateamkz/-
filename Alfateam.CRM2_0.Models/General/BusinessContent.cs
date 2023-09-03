using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Content.Education.Courses;
using Alfateam.CRM2_0.Models.Content.Events;
using Alfateam.CRM2_0.Models.Content.Posts;
using Alfateam.CRM2_0.Models.Content.Tests;
using Alfateam.CRM2_0.Models.Content.Videos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.General
{
    /// <summary>
    /// Весь контент, который есть в каком-либо бизнесе
    /// </summary>
    public class BusinessContent : AbsModel
    {
        public List<Course> Courses { get; set; } = new List<Course>();


        public List<Event> Events { get; set; } = new List<Event>();
        public List<EventCategory> EventCategories { get; set; } = new List<EventCategory>();
        public List<EventFormat> EventFormats { get; set; } = new List<EventFormat>();



        public List<Post> Posts { get; set; } = new List<Post>();
        public List<PostCategory> PostCategories { get; set; } = new List<PostCategory>();


        public List<Test> Tests { get; set; } = new List<Test>();
        public List<TestCategory> TestCategories { get; set; } = new List<TestCategory>();


        public List<Video> Videos { get; set; } = new List<Video>();
        public List<VideoCategory> VideoCategories { get; set; } = new List<VideoCategory>();



        /// <summary>
        /// Автоматическое поле
        /// Указывает на сущность Business
        /// </summary>
        public int BusinessId { get; set; }
    }
}
