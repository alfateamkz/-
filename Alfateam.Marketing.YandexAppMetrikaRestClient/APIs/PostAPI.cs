using Alfateam.Marketing.YandexAppMetrikaRestClient.Abstractions;
using Alfateam.Marketing.YandexAppMetrikaRestClient.Models.DataStream.Status;
using Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Post.PostAdRevenue;
using Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Post.PostECommerce;
using Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Post.PostImportEvents;
using Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Post.PostProfileAttributes;
using Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Post.PostRevenue;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.APIs
{
    public class PostAPI : AbsAPI
    {
        public PostAPI(YandexAppMetrikaClient client) : base(client)
        {
        }

        public async Task PostImportEvents(PostImportEventsQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/logs/v1/import/events", queryParams);
            await this.Client.MakeRequestAndThrowIfNotSuccess(url, Method.Post, expectedStatusCode: 200);
        }

        public async Task PostRevenue(PostRevenueQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/logs/v1/import/revenue", queryParams);
            await this.Client.MakeRequestAndThrowIfNotSuccess(url, Method.Post, expectedStatusCode: 200);
        }

        public async Task PostAdRevenue(PostAdRevenueQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/logs/v1/import/adrevenue", queryParams);
            await this.Client.MakeRequestAndThrowIfNotSuccess(url, Method.Post, expectedStatusCode: 200);
        }

        public async Task PostECommerce(PostECommerceQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/logs/v1/import/ecommerce", queryParams);
            await this.Client.MakeRequestAndThrowIfNotSuccess(url, Method.Post, expectedStatusCode: 200);
        }

        public async Task PostProfileAttributes(PostProfileAttributesQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/logs/v1/import/profiles", queryParams);
            await this.Client.MakeRequestAndThrowIfNotSuccess(url, Method.Post, expectedStatusCode: 200);
        }
    }
}
