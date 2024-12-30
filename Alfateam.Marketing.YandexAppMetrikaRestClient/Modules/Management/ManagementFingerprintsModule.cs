using Alfateam.Marketing.YandexAppMetrikaRestClient.Abstractions;
using Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Management.Access.ListPartners;
using Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Management.Fingerprints;
using Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Management.Fingerprints.FingerprintsAndroidDelete;
using Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Management.Fingerprints.FingerprintsAndroidGet;
using Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Management.Fingerprints.FingerprintsAndroidPost;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Modules.Management
{
    public class ManagementFingerprintsModule : AbsModule
    {
        public ManagementFingerprintsModule(YandexAppMetrikaClient client) : base(client)
        {
        }

        public async Task<FingerprintsAndroidGetResponse> FingerprintsAndroidGet(int applicationId)
        {
            string url = this.Client.CombineURL($"/management/v1/application/{applicationId}/events_certs_fingerprints/android");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<FingerprintsAndroidGetResponse>(url, Method.Get);
        }

        public async Task<FingerprintModel> FingerprintsAndroidPost(int applicationId, FingerprintsAndroidPostBody body)
        {
            string url = this.Client.CombineURL($"/management/v1/application/{applicationId}/events_certs_fingerprints/android/add");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<FingerprintModel>(url, Method.Post, body);
        }

        public async Task<FingerprintsAndroidDeleteResponse> FingerprintsAndroidDelete(int applicationId, int fingerprintId)
        {
            string url = this.Client.CombineURL($"/management/v1/application/{applicationId}/events_certs_fingerprints/android/{fingerprintId}");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<FingerprintsAndroidDeleteResponse>(url, Method.Delete);
        }

    }
}
