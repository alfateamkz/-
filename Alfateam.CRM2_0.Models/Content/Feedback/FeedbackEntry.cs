using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Content.Feedback
{
    /// <summary>
    /// Сущность обратной связи по показателю (лайки, дизлайки и т.д.)
    /// </summary>
    public class FeedbackEntry : AbsModel
    {
        public User User { get; set; }

        /// <summary>
        /// При создании сущности(например, когда пользователь ставит лайк),
        /// значение IsActive = true. Если пользователь убирает лайк, то IsActive становится false
        /// И так по кругу. Можно по идее сам FeedbackEntry из БД удалять, но мы хотим видеть, кто что лайкает
        /// даже если вдруг кто-то убрал отметку
        /// </summary>
        public bool IsActive { get; set; } = true;

        public DateTime FirstFeedbackEntryDate { get; set; } = DateTime.UtcNow;
        public DateTime LastFeedbackEntryDate { get; set; } = DateTime.UtcNow;


        public DateTime? FirstFeedbackCanceledDate { get; set; }
        public DateTime? LastFeedbackCanceledDate { get; set; } 

    }
}
