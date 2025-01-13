using Alfateam.Core.Exceptions;
using Alfateam.Marketing.API.Abstractions;
using Alfateam.Marketing.API.Models;
using Alfateam.Marketing.Models.Abstractions;
using Alfateam.Marketing.Models.Abstractions.Integrations;
using Alfateam.Marketing.Models.Ads.Accounts;
using Alfateam.Marketing.Models.Integrations.SEO;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using VkNet.Enums;
using VkNet.Enums.Filters;
using VkNet.Enums.StringEnums;
using VkNet.Model;

namespace Alfateam.Marketing.API.Controllers.AdServices
{
    [SwaggerTag("Для работы с API Vkontakte нужно в хедере AccountId передавать Id добавленного рекламного аккаунта")]
    public class VKAdsController : AbsController
    {

        private const string CLIENT_SECRET = "";
        private const long APP_ID = 0;

        private VkNet.VkApi VK_API;
        public VKAdsController(ControllerParams @params) : base(@params)
        {
            VK_API = new VkNet.VkApi();

            var account = this.Account;
            if (!string.IsNullOrEmpty(account.AccessToken))
            {
                VK_API.Authorize(new ApiAuthParams
                {
                    ApplicationId = APP_ID,
                    AccessToken = account.AccessToken,
                    Settings = Settings.Ads,
                    ClientSecret = CLIENT_SECRET
                });
            }

        }


        public VKAdsServiceAccount Account
        {
            get
            {
                var id = this.ParseIntValueFromHeader("AccountId");
                if(id == null)
                {
                    throw new Exception400("Не указан AccoundId или указан не в виде целочисленного идентификатора");
                }
                return TryGetAccount((int)id);
            }
        }



        [HttpGet, Route("Auth")]
        public async Task Auth()
        {
            var account = this.Account;

            if (!string.IsNullOrEmpty(account.AccessToken))
            {
                await VK_API.AuthorizeAsync(new ApiAuthParams
                {
                    ApplicationId = APP_ID,
                    AccessToken = account.AccessToken,
                    Settings = Settings.Ads,
                    ClientSecret = CLIENT_SECRET
                });
            }
            else
            {
                await VK_API.AuthorizeAsync(new ApiAuthParams
                {
                    ApplicationId = APP_ID,
                    Login = account.Login,
                    Password = account.Password,
                    Settings = Settings.Ads,
                    ClientSecret = CLIENT_SECRET,
                    TwoFactorSupported = false
                });

                account.AccessToken = VK_API.Token;
                DBService.UpdateEntity(DB.AdsServiceAccounts, account);
            }
        }




        [HttpPost, Route("AddOfficeUsers")]
        public async Task<IEnumerable<bool>> AddOfficeUsers(AdsDataSpecificationParams<UserSpecification> adsDataSpecification)
        {
            return await VK_API.Ads.AddOfficeUsersAsync(adsDataSpecification);
        }

        [HttpGet, Route("CheckLink")]
        public async Task<LinkStatus> CheckLink(CheckLinkParams checkLinkParams)
        {
            return await VK_API.Ads.CheckLinkAsync(checkLinkParams);
        }

        [HttpPost, Route("CreateAds")]
        public async Task<IEnumerable<CreateAdsResult>> CreateAds(AdsDataSpecificationParams<AdSpecification> adsDataSpecification)
        {
            return await VK_API.Ads.CreateAdsAsync(adsDataSpecification);
        }

        [HttpPost, Route("CreateCampaigns")]
        public async Task<IEnumerable<CreateCampaignResult>> CreateCampaigns(AdsDataSpecificationParams<CampaignSpecification> campaignsDataSpecification)
        {
            return await VK_API.Ads.CreateCampaignsAsync(campaignsDataSpecification);
        }

        [HttpPost, Route("CreateClients")]
        public async Task<IEnumerable<CreateClientResult>> CreateClients(AdsDataSpecificationParams<ClientSpecification> clientDataSpecification)
        {
            return await VK_API.Ads.CreateClientsAsync(clientDataSpecification);
        }

        [HttpPost, Route("CreateLookalikeRequest")]
        public async Task<CreateLookALikeRequestResult> CreateLookalikeRequest(CreateLookALikeRequestParams createLookALikeRequestParams)
        {
            return await VK_API.Ads.CreateLookalikeRequestAsync(createLookALikeRequestParams);
        }

        [HttpPost, Route("CreateTargetGroup")]
        public async Task<CreateTargetGroupResult> CreateTargetGroup(CreateTargetGroupParams createTargetGroupParams)
        {
            return await VK_API.Ads.CreateTargetGroupAsync(createTargetGroupParams);
        }

        [HttpPost, Route("CreateTargetPixel")]
        public async Task<CreateTargetPixelResult> CreateTargetPixel(CreateTargetPixelParams createTargetPixelParams)
        {
            return await VK_API.Ads.CreateTargetPixelAsync(createTargetPixelParams);
        }

        [HttpDelete, Route("DeleteAds")]
        public async Task<IEnumerable<bool>> DeleteAds(DeleteAdsParams deleteAdsParams)
        {
            return await VK_API.Ads.DeleteAdsAsync(deleteAdsParams);
        }

        [HttpDelete, Route("DeleteCampaigns")]
        public async Task<IEnumerable<bool>> DeleteCampaigns(DeleteCampaignsParams deleteCampaignsParams)
        {
            return await VK_API.Ads.DeleteCampaignsAsync(deleteCampaignsParams);
        }

        [HttpDelete, Route("DeleteClients")]
        public async Task<IEnumerable<bool>> DeleteClients(DeleteClientsParams deleteClientsParams)
        {
            return await VK_API.Ads.DeleteClientsAsync(deleteClientsParams);
        }

        [HttpDelete, Route("DeleteTargetGroup")]
        public async Task<bool> DeleteTargetGroup(DeleteTargetGroupParams deleteTargetGroupParams)
        {
            return await VK_API.Ads.DeleteTargetGroupAsync(deleteTargetGroupParams);
        }

        [HttpDelete, Route("DeleteTargetPixel")]
        public async Task<bool> DeleteTargetPixel(DeleteTargetPixelParams deleteTargetPixelParams)
        {
            return await VK_API.Ads.DeleteTargetPixelAsync(deleteTargetPixelParams);
        }

        [HttpGet, Route("GetAccounts")]
        public async Task<IEnumerable<AdsAccount>> GetAccounts()
        {
            return await VK_API.Ads.GetAccountsAsync();
        }

        [HttpGet, Route("GetAds")]
        public async Task<IEnumerable<Ad>> GetAds(GetAdsParams getAdsParams)
        {
            return await VK_API.Ads.GetAdsAsync(getAdsParams);
        }

        [HttpGet, Route("GetAdsLayout")]
        public async Task<IEnumerable<Layout>> GetAdsLayout(GetAdsLayoutParams getAdsLayoutParams)
        {
            return await VK_API.Ads.GetAdsLayoutAsync(getAdsLayoutParams);
        }

        [HttpGet, Route("GetAdsTargeting")]
        public async Task<IEnumerable<AdsTargetingResult>> GetAdsTargeting(GetAdsTargetingParams getAdsTargetingParams)
        {
            return await VK_API.Ads.GetAdsTargetingAsync(getAdsTargetingParams);
        }

        [HttpGet, Route("GetBudget")]
        public async Task<double> GetBudget(long accountId)
        {
            return await VK_API.Ads.GetBudgetAsync(accountId);
        }

        [HttpGet, Route("GetCampaigns")]
        public async Task<IEnumerable<AdsCampaign>> GetCampaigns(AdsGetCampaignsParams adsGetCampaignsParams)
        {
            return await VK_API.Ads.GetCampaignsAsync(adsGetCampaignsParams);
        }

        [HttpGet, Route("GetCategories")]
        public async Task<GetCategoriesResult> GetCategories(Language lang)
        {
            return await VK_API.Ads.GetCategoriesAsync(lang);
        }

        [HttpGet, Route("GetClients")]
        public async Task<IEnumerable<GetClientsResult>> GetClients(long accountId)
        {
            return await VK_API.Ads.GetClientsAsync(accountId);
        }

        [HttpGet, Route("GetDemographics")]
        public async Task<IEnumerable<GetDemographicsResult>> GetDemographics(GetDemographicsParams getDemographicsParams)
        {
            return await VK_API.Ads.GetDemographicsAsync(getDemographicsParams);
        }

        [HttpGet, Route("GetFloodStats")]
        public async Task<GetFloodStatsResult> GetFloodStats(long accountId)
        {
            return await VK_API.Ads.GetFloodStatsAsync(accountId);
        }

        [HttpGet, Route("GetLookalikeRequests")]
        public async Task<GetLookalikeRequestsResult> GetLookalikeRequests(GetLookalikeRequestsParams getLookalikeRequestsParams)
        {
            return await VK_API.Ads.GetLookalikeRequestsAsync(getLookalikeRequestsParams);
        }

        [HttpGet, Route("GetMusicians")]
        public async Task<IEnumerable<GetMusiciansResult>> GetMusicians(string artistName)
        {
            return await VK_API.Ads.GetMusiciansAsync(artistName);
        }

        [HttpGet, Route("GetMusiciansByIds")]
        public async Task<IEnumerable<GetMusiciansByIdsResult>> GetMusiciansByIds(string ids)
        {
            return await VK_API.Ads.GetMusiciansByIdsAsync(ids);
        }

        [HttpGet, Route("GetOfficeUsers")]
        public async Task<IEnumerable<GetOfficeUsersResult>> GetOfficeUsers(long accountId)
        {
            return await VK_API.Ads.GetOfficeUsersAsync(accountId);
        }

        [HttpGet, Route("GetPostsReach")]
        public async Task<IEnumerable<GetPostsReachResult>> GetPostsReach(long accountId, IdsType idsType, string ids)
        {
            return await VK_API.Ads.GetPostsReachAsync(accountId, idsType, ids);
        }

        [HttpGet, Route("GetRejectionReason")]
        public async Task<GetRejectionReasonResult> GetRejectionReason(long accountId, long adId)
        {
            return await VK_API.Ads.GetRejectionReasonAsync(accountId, adId);
        }

        [HttpGet, Route("GetStatistics")]
        public async Task<IEnumerable<GetStatisticsResult>> GetStatistics(GetStatisticsParams getStatisticsParams)
        {
            return await VK_API.Ads.GetStatisticsAsync(getStatisticsParams);
        }

        [HttpGet, Route("GetSuggestions")]
        public async Task<IEnumerable<GetSuggestionsResult>> GetSuggestions(GetSuggestionsParams getSuggestionsParams)
        {
            return await VK_API.Ads.GetSuggestionsAsync(getSuggestionsParams);
        }

        [HttpGet, Route("GetTargetGroups")]
        public async Task<IEnumerable<GetTargetGroupsResult>> GetTargetGroups(long accountId, long? clientId = null, bool? extended = null)
        {
            return await VK_API.Ads.GetTargetGroupsAsync(accountId, clientId, extended);
        }

        [HttpGet, Route("GetTargetPixels")]
        public async Task<IEnumerable<GetTargetPixelsResult>> GetTargetPixels(long accountId, long? clientId = null)
        {
            return await VK_API.Ads.GetTargetPixelsAsync(accountId, clientId);
        }

        [HttpGet, Route("GetTargetingStats")]
        public async Task<GetTargetingStatsResult> GetTargetingStats(GetTargetingStatsParams getTargetingStatsParams)
        {
            return await VK_API.Ads.GetTargetingStatsAsync(getTargetingStatsParams);
        }

        [HttpGet, Route("GetUploadURL")]
        public async Task<Uri> GetUploadURL(GetUploadUrlParams getUploadUrlParams)
        {
            return await VK_API.Ads.GetUploadUrlAsync(getUploadUrlParams);
        }

        [HttpGet, Route("GetVideoUploadURL")]
        public async Task<Uri> GetVideoUploadURL()
        {
            return await VK_API.Ads.GetVideoUploadUrlAsync();
        }

        [HttpPost, Route("ImportTargetContacts")]
        public async Task<long> ImportTargetContacts(ImportTargetContactsParams importTargetContactsParams)
        {
            return await VK_API.Ads.ImportTargetContactsAsync(importTargetContactsParams);
        }

        [HttpDelete, Route("RemoveOfficeUsers")]
        public async Task<IEnumerable<bool>> RemoveOfficeUsers(RemoveOfficeUsersParams removeOfficeUsersParams)
        {
            return await VK_API.Ads.RemoveOfficeUsersAsync(removeOfficeUsersParams);
        }

        [HttpDelete, Route("RemoveTargetContacts")]
        public async Task<RemoveTargetContactsResult> RemoveTargetContacts(RemoveTargetContactsParams removeTargetContactsParams)
        {
            return await VK_API.Ads.RemoveTargetContactsAsync(removeTargetContactsParams);
        }

        [HttpPost, Route("SaveLookalikeRequestResult")]
        public async Task<SaveLookALikeRequestResultResult> SaveLookalikeRequestResult(SaveLookalikeRequestResultParams saveLookalikeRequestResultParams)
        {
            return await VK_API.Ads.SaveLookalikeRequestResultAsync(saveLookalikeRequestResultParams);
        }

        [HttpPost, Route("ShareTargetGroup")]
        public async Task<ShareTargetGroupResult> ShareTargetGroup(ShareTargetGroupParams shareTargetGroupParams)
        {
            return await VK_API.Ads.ShareTargetGroupAsync(shareTargetGroupParams);
        }

        [HttpPut, Route("UpdateAds")]
        public async Task<IEnumerable<UpdateAdsResult>> UpdateAds(AdsDataSpecificationParams<AdEditSpecification> adEditDataSpecification)
        {
            return await VK_API.Ads.UpdateAdsAsync(adEditDataSpecification);
        }

        [HttpPut, Route("UpdateCampaigns")]
        public async Task<IEnumerable<UpdateCampaignsResult>> UpdateCampaigns(AdsDataSpecificationParams<CampaignModSpecification> campaignModDataSpecification)
        {
            return await VK_API.Ads.UpdateCampaignsAsync(campaignModDataSpecification);
        }

        [HttpPut, Route("UpdateClients")]
        public async Task<IEnumerable<UpdateClientsResult>> UpdateClients(AdsDataSpecificationParams<ClientModSpecification> clientModDataSpecification)
        {
            return await VK_API.Ads.UpdateClientsAsync(clientModDataSpecification);
        }

        [HttpPut, Route("UpdateOfficeUsers")]
        public async Task<IEnumerable<UpdateOfficeUsersResult>> UpdateOfficeUsers(AdsDataSpecificationParams<OfficeUsersSpecification> officeUsersSpecification)
        {
            return await VK_API.Ads.UpdateOfficeUsersAsync(officeUsersSpecification);
        }

        [HttpPut, Route("UpdateTargetGroup")]
        public async Task<bool> UpdateTargetGroup(UpdateTargetGroupParams updateTargetGroupParams)
        {
            return await VK_API.Ads.UpdateTargetGroupAsync(updateTargetGroupParams);
        }

        [HttpPut, Route("UpdateTargetPixel")]
        public async Task<bool> UpdateTargetPixel(UpdateTargetPixelParams updateTargetPixelParams)
        {
            return await VK_API.Ads.UpdateTargetPixelAsync(updateTargetPixelParams);
        }









        #region Private methods
        private IEnumerable<AdsServiceAccount> GetAvailableAccounts()
        {
            return DB.AdsServiceAccounts.Where(o => !o.IsDeleted && o.BusinessCompanyId == this.CompanyId);
        }

        private VKAdsServiceAccount TryGetAccount(int accountId)
        {
            var integration = DBService.TryGetOne(GetAvailableAccounts(), accountId);
            if (integration is not VKAdsServiceAccount)
            {
                throw new Exception400("Id верный, но это не та интеграция");
            }
            return integration as VKAdsServiceAccount;
        }

        #endregion
    }
}
