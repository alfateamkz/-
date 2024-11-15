using Alfateam.Core.Exceptions;
using Alfateam.Sales.API.Abstractions;
using Alfateam.Sales.API.Models;
using Alfateam.Sales.API.Models.DTO.Abstractions.ExtInterations;
using Alfateam.Sales.API.Models.DTO.ExternalInteractions.SentForms;
using Alfateam.Sales.API.Models.DTO.ExternalInteractions.SentForms.CommunitationButtons;
using Alfateam.Sales.Models.Abstractions.ExtInterations;
using Alfateam.Sales.Models.ExternalInteractions;
using Alfateam.Sales.Models.ExternalInteractions.Inputs;
using Alfateam.Sales.Models.ExternalInteractions.SentForms.CommunitationButtons;
using Alfateam.Sales.Models.ExternalInteractions.SentForms.Values;
using Microsoft.AspNetCore.Mvc;

namespace Alfateam.Sales.API.Controllers.ExternalInteractions
{
    public class ClientExternalInteractionsController : AbsController
    {
        public ClientExternalInteractionsController(ControllerParams @params) : base(@params)
        {
        }


        [HttpPut, Route("SendCommunicationButtonAction")]
        public async Task SendCommunicationButtonAction(string uniqueIntegrationURL, string userAgent, string ip, CommunitationButtonsActionDTO model)
        {
            var interaction = TryGetInteraction<CommunitationButtonsExtInteration>(uniqueIntegrationURL);
            var actionsSession = DB.CommunitationButtonsActionsSessions.FirstOrDefault(o => o.IP == ip && o.UserAgent == userAgent 
                                                                       && o.CommunitationButtonsExtInterationId == interaction.Id);
            if(actionsSession == null)
            {
                actionsSession = new CommunitationButtonsActionsSession()
                {
                    CommunitationButtonsExtInterationId = interaction.Id,
                    UserAgent = userAgent,
                    IP = ip,
                };
                DB.CommunitationButtonsActionsSessions.Add(actionsSession);
                DB.SaveChanges();
            }

            DBService.TryCreateEntity(DB.CommunitationButtonsActions, model, (entity) =>
            {
                entity.CommunitationButtonsActionsSessionId = actionsSession.Id;
            });
        }
   
        [HttpPut, Route("SendWebsiteForm")]
        public async Task SendWebsiteForm(string uniqueIntegrationURL, SentWebsiteFormDTO model)
        {
            var interaction = TryGetInteraction<WebsiteFormExtInteration>(uniqueIntegrationURL) as WebsiteFormExtInteration;

            DBService.TryCreateEntity(DB.SentWebsiteForms, model, (entity) =>
            {

                foreach (var field in interaction.Inputs)
                {
                    var sentFormField = entity.Fields.FirstOrDefault(o => o.FieldName == field.FieldName);
                    if (sentFormField == null && field is not FileWebsiteFormInput)
                    {
                        throw new Exception400($"Не передано поле {field.FieldName}");
                    }
                    else if (field is FileWebsiteFormInput fileField && field.IsRequired 
                        && !Request.Form.Files.Any(o => o.Name.StartsWith(sentFormField.FieldName)))
                    {
                        throw new Exception400($"Не загружен как минимум один файл поля с именем {field.FieldName}");
                    }
                    else if (field is FileWebsiteFormInput fileField2 
                            && Request.Form.Files.Count(o => o.Name.StartsWith(sentFormField.FieldName)) > fileField2.MaxFilesCount)
                    {
                        throw new Exception400($"Можно загрузить максимум {fileField2.MaxFilesCount} файлов");
                    }


                    //if (field.IsRequired)
                    //{
                    //    var simpleSentFormField = sentFormField as SimpleSentFormField;
                    //}

                    //TODO: валидация формы
                }


               

                entity.WebsiteFormExtInterationId = interaction.Id;
            });
        }




        #region Private methods

        private IEnumerable<ExternalInteraction> GetAvailableInteractions()
        {
            var interactions = DB.ExternalInteractions.Where(o => !o.IsDeleted && o.BusinessCompanyId == this.CompanyId);
            foreach (var interaction in interactions)
            {
                if (interaction is WebsiteFormExtInteration websiteForm)
                {
                    websiteForm.Inputs = DB.WebsiteFormInputs.Where(o => !o.IsDeleted && o.WebsiteFormExtInterationId == websiteForm.Id).ToList();
                }
                else if (interaction is CommunitationButtonsExtInteration communitationButtons)
                {
                    communitationButtons.Contacts = DB.ContactInfos.Where(o => !o.IsDeleted && o.CommunitationButtonsExtInterationId == communitationButtons.Id).ToList();
                }
            }
            return interactions;
        }

        private ExternalInteraction TryGetInteraction<T>(string uniqueIntegrationURL) where T : ExternalInteraction 
        {
            var interaction = GetAvailableInteractions().FirstOrDefault(o => o.UniqueIntegrationURL == uniqueIntegrationURL && !o.IsDeleted);
            if (interaction == null)
            {
                throw new Exception404("По данному URL не найдено взаимодействие");
            }
            else if(interaction is not T)
            {
                throw new Exception400($"Найденный тип не соответстует требуемому типу {typeof(T)}");
            }
            return interaction;
        }

        #endregion
    }
}
