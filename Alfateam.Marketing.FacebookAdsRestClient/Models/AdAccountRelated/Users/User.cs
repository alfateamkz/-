using Alfateam.Marketing.FacebookAdsRestClient.Abstractions.Models;
using Alfateam.Marketing.FacebookAdsRestClient.Models.General;
using Alfateam.Marketing.FacebookAdsRestClient.Models.General.Pages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.Users
{
    public class User : Profile
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("about")]
        public string About { get; set; }

        [JsonProperty("age_range")]
        public AgeRange AgeRange { get; set; }

        [JsonProperty("avatar_2d_profile_picture")]
        public AvatarProfilePicture Avatar2DProfilePicture { get; set; }

        [JsonProperty("birthday")]
        public string Birthday { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("favorite_athletes")]
        public List<Experience> FavoriteAthletes { get; set; } = new List<Experience>();

        [JsonProperty("favorite_teams")]
        public List<Experience> FavoriteTeams { get; set; } = new List<Experience>();

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("hometown")]
        public Page Hometown { get; set; }

        [JsonProperty("id_for_avatars")]
        public long IdForAvatars { get; set; }

        [JsonProperty("inspirational_people")]
        public List<Experience> InspirationalPeople { get; set; } = new List<Experience>();

        [JsonProperty("install_type")]
        public string InstallType { get; set; }

        [JsonProperty("installed")]
        public bool Installed { get; set; }

        [JsonProperty("is_guest_user")]
        public bool IsGuestUser { get; set; }

        [JsonProperty("languages")]
        public List<Experience> Languages { get; set; } = new List<Experience>();

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("location")]
        public Page Location { get; set; }

        [JsonProperty("meeting_for")]
        public List<string> MeetingFor { get; set; } = new List<string>();

        [JsonProperty("middle_name")]
        public string MiddleName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("name_format")]
        public string NameFormat { get; set; }

        [JsonProperty("payment_pricepoints")]
        public PaymentPricepoints PaymentPricepoints { get; set; }

        [JsonProperty("political")]
        public string Political { get; set; }

        [JsonProperty("profile_pic")]
        public string ProfilePic { get; set; }

        [JsonProperty("quotes")]
        public string Quotes { get; set; }

        [JsonProperty("relationship_status")]
        public string RelationshipStatus { get; set; }

        [JsonProperty("religion")]
        public string Religion { get; set; }

        [JsonProperty("shared_login_upgrade_required_by")]
        public long SharedLoginUpgradeRequiredBy { get; set; }

        [JsonProperty("short_name")]
        public string ShortName { get; set; }

        [JsonProperty("significant_other")]
        public User SignificantOther { get; set; }

        [JsonProperty("sports")]
        public List<Experience> Sports { get; set; } = new List<Experience>();

        [JsonProperty("supports_donate_button_in_live_video")]
        public bool SupportsDonateButtonInLiveVideo { get; set; }

        [JsonProperty("token_for_business")]
        public string TokenForBusiness { get; set; }

        [JsonProperty("video_upload_limits")]
        public VideoUploadLimits VideoUploadLimits { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }
    }
}
