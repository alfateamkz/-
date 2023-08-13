using Alfateam.CRM2_0.Models.Abstractions.Communication.Omnichannel;
using Alfateam.CRM2_0.Models.Communication.Omnichannel.Accounts;
using Alfateam.CRM2_0.Models.Content.Education.Courses.LessonBlocks;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Abstractions.Content.Education.Courses
{

    [JsonConverter(typeof(JsonKnownTypesConverter<CourseLessonBlock>))]
    [JsonDiscriminator(Name = "Discriminator")]
    [JsonKnownType(typeof(AudioLessonBlock), "AudioLessonBlock")]
    [JsonKnownType(typeof(ImageLessonBlock), "ImageLessonBlock")]
    [JsonKnownType(typeof(ImagesLessonBlock), "ImagesLessonBlock")]
    [JsonKnownType(typeof(TestLessonBlock), "TestLessonBlock")]
    [JsonKnownType(typeof(TextLessonBlock), "TextLessonBlock")]
    [JsonKnownType(typeof(VideoLessonBlock), "VideoLessonBlock")]
    /// <summary>
    /// Базовая модель составной единицы урока
    /// </summary>
    public abstract class CourseLessonBlock : AbsModel
    {
    }
}
