using Alfateam2._0.Models.General;

namespace Alfateam.Website.API.Models.UserModels
{
    public class AuthResponseModel
    {
        public User User { get; set; }
        public string Sessid { get; set; }
    }
}
