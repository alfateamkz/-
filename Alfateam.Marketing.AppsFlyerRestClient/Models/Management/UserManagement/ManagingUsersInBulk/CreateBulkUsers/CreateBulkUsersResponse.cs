using Alfateam.Marketing.AppsFlyerRestClient.Models.Management.UserManagement.ManagingUsersInBulk.GetUsers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Management.UserManagement.ManagingUsersInBulk.CreateBulkUsers
{
    public class CreateBulkUsersResponse
    {
        [JsonProperty("data")]
        public List<CreateBulkUsersResponseUser> Data { get; set; } = new List<CreateBulkUsersResponseUser>();
    }
}
