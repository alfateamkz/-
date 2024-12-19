using Alfateam.Core.Exceptions;
using Alfateam.CRM2_0.Models.General.Services;
using Alfateam.Marketing.API.Abstractions;
using Alfateam.Marketing.API.Models;
using Alfateam.Marketing.Models.Abstractions.Integrations;
using Alfateam.Marketing.Models.Integrations.SEO;
using Google;
using Google.Apis.PagespeedInsights.v5;
using Google.Apis.PagespeedInsights.v5.Data;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Alfateam.Marketing.API.Controllers.Integrations.SEO
{
    public class GooglePageSpeedInsightsIntegrationController : AbsController
    {
        //Test API Key - AIzaSyBPXYw0ipxza6dDn0b-x_3j8Wp0iWGMJyU
        public GooglePageSpeedInsightsIntegrationController(ControllerParams @params) : base(@params)
        {   
        }


        [HttpGet, Route("CheckAPIKeyValidity")]
        public async Task<bool> CheckAPIKeyValidity(int integrationId)
        {
            var integration = TryGetIntegration(integrationId);

            try
            {
                var req = new PagespeedapiResource(new PagespeedInsightsService()).Runpagespeed("https://youmi-leon-pidor1488.ru");
                req.Key = integration.API_Key;
                req.Execute();
            }
            catch (GoogleApiException googleEx)
            {
                if (googleEx.Error.Message == "API key not valid. Please pass a valid API key.")
                {
                    return false;
                }   
            }

            return true;
        }


        [HttpGet, Route("Runpagespeed")]
        public async Task<PagespeedApiPagespeedResponseV5> Runpagespeed(int integrationId, string url)
        {
            var integration = TryGetIntegration(integrationId);

            try
            {
                var req = new PagespeedapiResource(new PagespeedInsightsService()).Runpagespeed(url);
                req.Key = integration.API_Key;
                return req.Execute();
            }
            catch (GoogleApiException googleEx)
            {
                if(googleEx.Error.Message == "API key not valid. Please pass a valid API key.")
                {
                    throw new Exception403("Ключ API Google Page Insights неверный");
                }
                throw new Exception400(googleEx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception400(ex.ToString());
            }
        }





        #region Private methods
        private IEnumerable<Integration> GetAvailableIntegrations()
        {
            return DB.Integrations.Where(o => !o.IsDeleted && o.BusinessCompanyId == this.CompanyId);
        }

        private GooglePageSpeedInsightsIntegration TryGetIntegration(int integrationId)
        {
            var integration = DBService.TryGetOne(GetAvailableIntegrations(), integrationId);
            if (integration is not GooglePageSpeedInsightsIntegration)
            {
                throw new Exception400("Id верный, но это не та интеграция");
            }
            return integration as GooglePageSpeedInsightsIntegration;
        }

        #endregion

    }
}
