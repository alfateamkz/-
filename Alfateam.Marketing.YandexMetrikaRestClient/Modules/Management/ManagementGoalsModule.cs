using Alfateam.Marketing.YandexMetrikaRestClient.Abstractions;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.AccessFilters;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Goals;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Goals.GetGoal;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Goals.GetGoals;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Goals.GetMessengers;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Goals.GetSocialNetworks;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Modules.Management
{
    public class ManagementGoalsModule : AbsModule
    {
        public ManagementGoalsModule(YandexMetrikaClient client) : base(client)
        {
        }

        public async Task<WithGoalEResponse> GetGoal(int counterId, long goalId, GetGoalQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}/goal/{goalId}", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<WithGoalEResponse>(url, Method.Get);
        }

        public async Task<GetGoalsResponse> GetGoals(int counterId, GetGoalsQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}/goals", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<GetGoalsResponse>(url, Method.Get);
        }

        public async Task<WithGoalEResponse> EditGoal(int counterId, long goalId, WithGoalEBody body)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}/goal/{goalId}");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<WithGoalEResponse>(url, Method.Put, body);
        }

        public async Task<ManagementGeneralDeleteResponse> DeleteGoal(int counterId, long goalId)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}/goal/{goalId}");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<ManagementGeneralDeleteResponse>(url, Method.Delete);
        }

        public async Task<WithGoalEResponse> CreateGoal(int counterId, WithGoalEBody body)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}/goals");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<WithGoalEResponse>(url, Method.Post, body);
        }

        public async Task<GetMessengersResponse> GetMessengers()
        {
            string url = this.Client.CombineURL($"/management/v1/messengers");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<GetMessengersResponse>(url, Method.Get);
        }

        public async Task<GetSocialNetworksResponse> GetSocialNetworks()
        {
            string url = this.Client.CombineURL($"/management/v1/social_networks");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<GetSocialNetworksResponse>(url, Method.Get);
        }

    }
}
