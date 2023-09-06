using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Content.Feedback;

namespace Alfateam.CRM2_0.Models.CreateModels.Content.Feedback
{
    public class CommentCreateModel : CreateModel<Comment>
    {
        public string Text { get; set; }
    }
}
