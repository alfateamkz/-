using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Filters;
using Alfateam.CRM2_0.Models.Abstractions.Roles.HR;
using Alfateam.CRM2_0.Models.ClientModels.Roles.HR.Manuals;
using Alfateam.CRM2_0.Models.ClientModels.Roles.HR.Questionnaires;
using Alfateam.CRM2_0.Models.CreateModels.Roles.HR.Manuals;
using Alfateam.CRM2_0.Models.CreateModels.Roles.HR.Questionnaires;
using Alfateam.CRM2_0.Models.EditModels.Roles.HR.Manuals;
using Alfateam.CRM2_0.Models.EditModels.Roles.HR.Questionnaires;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.CRM2_0.Models.Roles.HR.Manuals;
using Alfateam.CRM2_0.Models.Roles.HR.Questionnaires;
using Alfateam.CRM2_0.Models.Roles.HR.Questionnaires.Questions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Alfateam.CRM2_0.Controllers.Roles.HR
{
    [DepartmentFilter]
    [AccessActionFilter(roles: UserRole.HR)]
    public class HRQuestionariesController : AbsController
    {
        public HRQuestionariesController(ControllerParams @params) : base(@params)
        {
        }

        //TODO: добавить методы получения по цепочке вверх

        #region Опросники

        #region CRUD с опросниками

        [HttpGet, Route("GetHRQuestionnaires")]
        public async Task<RequestResult> GetHRQuestionnaires(int offset, int count = 20)
        {
            var queryable = DB.HRQuestionnaires.Include(o => o.Category)
                                               .Where(o => o.HRDepartmentId == this.DepartmentId);
            
            var questionaires = queryable.Where(o => !o.IsDeleted).Skip(offset).Take(count);

            foreach(var questionaire in questionaires)
            {
                IncludeHRQuestionnaireQuestionOptions(questionaire);
                ClearDeletedHRQuestionnaireEntities(questionaire);
            }

            var models = new HRQuestionnaireClientModel().CreateModels(questionaires);
            return RequestResult<IEnumerable<ClientModel<HRQuestionnaire>>>.AsSuccess(models);
        }

        [HttpGet, Route("GetHRQuestionnaire")]
        public async Task<RequestResult> GetHRQuestionnaire(int id)
        {
            var queryable = DB.HRQuestionnaires.Include(o => o.Category)
                                               .Include(o => o.QuestionGroups).ThenInclude(o => o.Questions)
                                               .Where(o => o.HRDepartmentId == this.DepartmentId);
            var questionaire = queryable.FirstOrDefault(o => o.Id == id);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseQuestionnaire(questionaire),
                () =>
                {
                    IncludeHRQuestionnaireQuestionOptions(questionaire);
                    ClearDeletedHRQuestionnaireEntities(questionaire);
                    return RequestResult<HRQuestionnaire>.AsSuccess(questionaire);
                }
            });
        }


        [HttpPost, Route("CreateHRQuestionnaire")]
        public async Task<RequestResult> CreateHRQuestionnaire(HRQuestionnaireCreateModel model)
        {
            return TryCreateModel(DB.HRQuestionnaires, model, (item) =>
            {
                item.HRDepartmentId = (int)this.DepartmentId;
                return RequestResult.AsSuccess();
            });
        }


        [HttpPut, Route("UpdateHRQuestionnaire")]
        public async Task<RequestResult> UpdateHRQuestionnaire(HRQuestionnaireEditModel model)
        {
            var questionaire = DB.HRQuestionnaires.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseQuestionnaire(questionaire),
                () => TryUpdateModel(DB.HRQuestionnaires, questionaire, model)
            });
        }


        [HttpDelete, Route("DeleteHRQuestionnaire")]
        public async Task<RequestResult> DeleteHRQuestionnaire(int id)
        {
            var questionaire = DB.HRQuestionnaires.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseQuestionnaire(questionaire),
                () => DeleteModel(DB.HRQuestionnaires, questionaire)
            });
        }

        #endregion

        #region CRUD с группами вопросов

        [HttpGet, Route("GetHRQuestionnaireQuestionGroup")]
        public async Task<RequestResult> GetHRQuestionnaireQuestionGroup(int questionnaireId, int questionGroupId)
        {
            var questionnaire = DB.HRQuestionnaires.FirstOrDefault(o => !o.IsDeleted && o.Id == questionnaireId);

            var questionGroup = DB.HRQuestionaireQuestionGroups.Include(o => o.Questions)
                                                               .FirstOrDefault(o => !o.IsDeleted && o.Id == questionGroupId);
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseQuestionnaireAndQuestionGroup(questionnaire,questionGroup),
                () =>
                {
                    IncludeHRQuestionnaireQuestionOptions(questionGroup);
                    return RequestResult<HRQuestionaireQuestionGroup>.AsSuccess(questionGroup);
                }
            });
        }

        [HttpPost, Route("CreateHRQuestionnaireQuestionGroup")]
        public async Task<RequestResult> CreateHRQuestionnaireQuestionGroup(int questionnaireId, HRQuestionnaireQuestionGroupCreateModel model)
        {
            var questionnaire = DB.HRQuestionnaires.FirstOrDefault(o => !o.IsDeleted && o.Id == questionnaireId);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseQuestionnaire(questionnaire),
                () => RequestResult.FromBoolean(model.IsValid(), 404, "Проверьте корректность заполнения полей"),
                () =>
                {
                    questionnaire.QuestionGroups.Add(model.Create());
                    return UpdateModel(DB.HRQuestionnaires,questionnaire);
                }
            });
        }

        [HttpPut, Route("UpdateHRQuestionnaireQuestionGroup")]
        public async Task<RequestResult> UpdateHRQuestionnaireQuestionGroup(int questionnaireId, HRQuestionnaireQuestionGroupEditModel model)
        {
            var questionnaire = DB.HRQuestionnaires.FirstOrDefault(o => !o.IsDeleted && o.Id == questionnaireId);
            var questionGroup = DB.HRQuestionaireQuestionGroups.FirstOrDefault(o => !o.IsDeleted && o.Id == model.Id);
           
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseQuestionnaireAndQuestionGroup(questionnaire, questionGroup),
                () => RequestResult.FromBoolean(model.IsValid(), 404, "Проверьте корректность заполнения полей"),
                () => UpdateModel(DB.HRQuestionaireQuestionGroups, questionGroup, model)
            });
        }

        [HttpDelete, Route("DeleteHRQuestionnaireQuestionGroup")]
        public async Task<RequestResult> DeleteHRQuestionnaireQuestionGroup(int questionnaireId, int questionGroupId)
        {
            var questionnaire = DB.HRQuestionnaires.FirstOrDefault(o => !o.IsDeleted && o.Id == questionnaireId);

            var questionGroup = DB.HRQuestionaireQuestionGroups.Include(o => o.Questions)
                                                               .FirstOrDefault(o => !o.IsDeleted && o.Id == questionGroupId);
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseQuestionnaireAndQuestionGroup(questionnaire,questionGroup),
                () => DeleteModel(DB.HRQuestionaireQuestionGroups, questionGroup)
            });
        }

        #endregion

        #region CRUD с вопросами

        [HttpGet, Route("GetHRQuestionnaireQuestion")]
        public async Task<RequestResult> GetHRQuestionnaire(int questionnaireId, int questionId)
        {
            var questionnaire = DB.HRQuestionnaires.FirstOrDefault(o => !o.IsDeleted && o.Id == questionnaireId);
            var question = DB.HRQuestionaireQuestions.FirstOrDefault(o => !o.IsDeleted && o.Id == questionId);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseQuestionnaireAndQuestion(questionnaire,question),
                () => RequestResult<HRQuestionaireQuestion>.AsSuccess(question)
            });
        }

        [HttpPost, Route("CreateHRQuestionnaireQuestion")]
        public async Task<RequestResult> CreateHRQuestionnaireQuestion(int questionnaireId, int questionGroupId, HRQuestionaireQuestion question)
        {
            var questionnaire = DB.HRQuestionnaires.FirstOrDefault(o => !o.IsDeleted && o.Id == questionnaireId);
            var questionGroup = DB.HRQuestionaireQuestionGroups.FirstOrDefault(o => !o.IsDeleted && o.Id == questionGroupId);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseQuestionnaireAndQuestionGroup(questionnaire, questionGroup),
                () => RequestResult.FromBoolean(question.IsValidToCreate(), 400, "Проверьте корректность заполнения полей"),
                () =>
                {
                    questionGroup.Questions.Add(question);
                    return UpdateModel(DB.HRQuestionaireQuestionGroups, questionGroup);
                }
            });
        }

        [HttpPut, Route("UpdateHRQuestionnaireQuestion")]
        public async Task<RequestResult> UpdateHRQuestionnaireQuestion(int questionnaireId, int questionGroupId, HRQuestionaireQuestion question)
        {
            var questionnaire = DB.HRQuestionnaires.FirstOrDefault(o => !o.IsDeleted && o.Id == questionnaireId);
            var questionGroup = DB.HRQuestionaireQuestionGroups.FirstOrDefault(o => !o.IsDeleted && o.Id == questionGroupId);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseQuestionnaireAndQuestionGroup(questionnaire, questionGroup),
                () => RequestResult.FromBoolean(question.IsValidToUpdate(), 400, "Проверьте корректность заполнения полей"),
                () =>
                {
                    if(question is HRQuestionaireOptionsQuestion optionsQuestion)
                    {
                       // var questionFromDB = DB.HRQuestionaireQuestions.FirstOrDefault(o => o.Id == question.Id);
                        var optionsFromDB = DB.HRQuestionaireQuestionOptions.Where(o => o.HRQuestionaireOptionsQuestionId == question.Id)
                                                                            .AsNoTracking()
                                                                            .ToList();


                         //Делаем такие мувы, чтобы четенько сохранить варианты ответов без костылей - часть 1
                        foreach(var option in optionsFromDB)
                        {
                            if(!optionsQuestion.Options.Any(o => o.Id == option.Id))
                            {
                                option.IsDeleted = true;
                            }
                        }

                        var newOptions = new  List<HRQuestionaireQuestionOption>();
                        foreach(var option in optionsQuestion.Options)
                        {
                            if(!optionsFromDB.Any(o => o.Id == option.Id))
                            {
                                option.HRQuestionaireOptionsQuestionId = question.Id;
                                newOptions.Add(option);
                            }
                        }

                        DB.HRQuestionaireQuestionOptions.UpdateRange(optionsFromDB);
                        DB.HRQuestionaireQuestionOptions.AddRange(newOptions);

                        //Делаем такие мувы, чтобы четенько сохранить варианты ответов без костылей - часть 2
                        optionsQuestion.Options = new List<HRQuestionaireQuestionOption>();
                        DB.HRQuestionaireQuestions.Update(optionsQuestion);
                        DB.SaveChanges();

                        return RequestResult<HRQuestionaireQuestion>.AsSuccess(question);
                    }
                    else
                    {
                        return UpdateModel(DB.HRQuestionaireQuestions, question);
                    }
                   
                }
            });
        }

        [HttpDelete, Route("DeleteHRQuestionnaireQuestion")]
        public async Task<RequestResult> DeleteHRQuestionnaireQuestion(int questionnaireId, int questionId)
        {
            var questionnaire = DB.HRQuestionnaires.FirstOrDefault(o => !o.IsDeleted && o.Id == questionnaireId);
            var question = DB.HRQuestionaireQuestions.FirstOrDefault(o => !o.IsDeleted && o.Id == questionId);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseQuestionnaireAndQuestion(questionnaire,question),
                () => DeleteModel(DB.HRQuestionaireQuestions, question)
            });
        }

        #endregion

        #endregion

        #region Категории опросников

        [HttpGet, Route("GetHRQuestionnaireCategories")]
        public async Task<RequestResult> GetHRQuestionnaireCategories(int offset, int count = 20)
        {
            var queryable = DB.HRQuestionnaireCategories.Where(o => o.HRDepartmentId == this.DepartmentId);
            return GetMany<HRQuestionnaireCategory, HRQuestionnaireCategoryClientModel>(queryable, offset, count);
        }


        [HttpGet, Route("GetHRQuestionnaireCategory")]
        public async Task<RequestResult> GetHRQuestionnaireCategory(int id)
        {
            var category = DB.HRQuestionnaireCategories.FirstOrDefault(o => o.Id  == id && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseQuestionnaireCategory(category),
                () => RequestResult<HRQuestionnaireCategory>.AsSuccess(category)
            });
        }




        [HttpPost, Route("CreateHRQuestionnaireCategory")]
        public async Task<RequestResult> CreateHRQuestionnaireCategory(HRQuestionnaireCategoryCreateModel model)
        {
            return TryCreateModel(DB.HRQuestionnaireCategories, model, (item) =>
            {
                item.HRDepartmentId = (int)this.DepartmentId;
                return RequestResult.AsSuccess();
            });
        }



        [HttpPut, Route("UpdateHRQuestionnaireCategory")]
        public async Task<RequestResult> UpdateHRQuestionnaireCategory(HRQuestionnaireCategoryEditModel model)
        {

            var category = DB.HRQuestionnaireCategories.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseQuestionnaireCategory(category),
                () => TryUpdateModel(DB.HRQuestionnaireCategories, category, model)
            });
        }


        [HttpDelete, Route("DeleteHRQuestionnaireCategory")]
        public async Task<RequestResult> DeleteHRQuestionnaireCategory(int id)
        {
            var category = DB.HRQuestionnaireCategories.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseQuestionnaireCategory(category),
                () => DeleteModel(DB.HRQuestionnaireCategories, category)
            });
        }

        #endregion







        #region Private check methods

        private RequestResult CheckBaseQuestionnaire(HRQuestionnaire questionnaire)
        {
            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(questionnaire != null,404,"Опросник с данным id не найден"),
                () => RequestResult.FromBoolean(questionnaire.HRDepartmentId == this.DepartmentId,403,"Нет доступа к данному опроснику"),
            });
        }
        private RequestResult CheckBaseQuestionnaireAndQuestionGroup(HRQuestionnaire questionnaire, HRQuestionaireQuestionGroup questionGroup)
        {
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseQuestionnaire(questionnaire),
                () => RequestResult.FromBoolean(questionGroup != null,404,"Группа вопросов с данным id не найдена"),
                () => RequestResult.FromBoolean(questionGroup.HRQuestionnaireId == questionnaire.Id,403,"Группа вопросов не принадлежит данному опроснику"),
            });
        }
        private RequestResult CheckBaseQuestionnaireAndQuestion(HRQuestionnaire questionnaire, HRQuestionaireQuestion question)
        {
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseQuestionnaire(questionnaire),
                () =>
                {
                    var questionGroup = DB.HRQuestionaireQuestionGroups.FirstOrDefault(o => o.Id == question.HRQuestionaireQuestionGroupId);
                    return RequestResult.FromBoolean(questionGroup.HRQuestionnaireId == questionnaire.Id, 403,"Группа вопросов не принадлежит данному опроснику");
                }
            });
        }


        private RequestResult CheckBaseQuestionnaireCategory(HRQuestionnaireCategory category)
        {
            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(category != null,404,"Категория с данным id не найден"),
                () => RequestResult.FromBoolean(category.HRDepartmentId == this.DepartmentId,403,"Нет доступа к данной категории"),
            });
        }

        #endregion

        #region Private other methods

        private void IncludeHRQuestionnaireQuestionOptions(HRQuestionnaire questionnaire)
        {
            foreach(var question in questionnaire.QuestionGroups.SelectMany(o => o.Questions))
            {
                if (question is HRQuestionaireOptionsQuestion optionsQuestion 
                    && optionsQuestion.Options.Count == 0)
                {
                    var options = DB.HRQuestionaireQuestionOptions.Where(o => !o.IsDeleted
                                                                     && o.HRQuestionaireOptionsQuestionId == question.Id);

                    optionsQuestion.Options = options.ToList();
                }
            }
        }
        private void IncludeHRQuestionnaireQuestionOptions(HRQuestionaireQuestionGroup questionGroup)
        {
            foreach (var question in questionGroup.Questions)
            {
                if (question is HRQuestionaireOptionsQuestion optionsQuestion
                    && optionsQuestion.Options.Count == 0)
                {
                    var options = DB.HRQuestionaireQuestionOptions.Where(o => !o.IsDeleted
                                                                     && o.HRQuestionaireOptionsQuestionId == question.Id);

                    optionsQuestion.Options = options.ToList();
                }
            }
        }



        private void ClearDeletedHRQuestionnaireEntities(HRQuestionnaire questionnaire)
        {
            for(int i= questionnaire.QuestionGroups.Count -1; i >= 0; i--)
            {
                var group = questionnaire.QuestionGroups[i];
                if (group.IsDeleted)
                {
                    questionnaire.QuestionGroups.Remove(group);
                }
            }
            
            foreach(var group in questionnaire.QuestionGroups)
            {
                for (int i = group.Questions.Count - 1; i >= 0; i--)
                {
                    var question = group.Questions[i];
                    if (question.IsDeleted)
                    {
                        group.Questions.Remove(question);
                    }
                }
            }

            foreach(var question in questionnaire.QuestionGroups.SelectMany(o => o.Questions))
            {
                if(question is HRQuestionaireOptionsQuestion optionsQuestion)
                {
                    for (int i = optionsQuestion.Options.Count - 1; i >= 0; i--)
                    {
                        var option = optionsQuestion.Options[i];
                        if (option.IsDeleted)
                        {
                            optionsQuestion.Options.Remove(option);
                        }
                    }
                }
            }
        }

        #endregion

    }
}
