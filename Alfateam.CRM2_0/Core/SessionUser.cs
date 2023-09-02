using Alfateam.CRM2_0.Models.General;
using Alfateam.CRM2_0.Models.Security;

namespace Alfateam.CRM2_0.Core
{
    public class SessionUser
    {
        public Session Session { get; set; }
        public User User { get; set; }
    }
}
