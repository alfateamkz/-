using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Content.Feedback;

namespace Alfateam.CRM2_0.Models.EditModels.Content.Feedback
{
    public class CommentEditModel : EditModel<Comment>
    {
        public string Text { get; set; }
    }
}
