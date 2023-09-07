using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Filters;
using Alfateam.CRM2_0.Models.Abstractions.Roles.HR;
using Alfateam.CRM2_0.Models.Abstractions.Roles.SecurityService;
using Alfateam.CRM2_0.Models.ClientModels.Roles.HR.Questionnaires;
using Alfateam.CRM2_0.Models.ClientModels.Roles.SecurityService.Scoring;
using Alfateam.CRM2_0.Models.CreateModels.Roles.HR.Questionnaires;
using Alfateam.CRM2_0.Models.CreateModels.Roles.SecurityService.Scoring;
using Alfateam.CRM2_0.Models.EditModels.Roles.HR.Questionnaires;
using Alfateam.CRM2_0.Models.EditModels.Roles.SecurityService.Scoring;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.CRM2_0.Models.Roles.HR.Questionnaires;
using Alfateam.CRM2_0.Models.Roles.HR.Questionnaires.Questions;
using Alfateam.CRM2_0.Models.Roles.SecurityService.Scoring;
using Alfateam.CRM2_0.Models.Roles.SecurityService.Scoring.Questions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.CRM2_0.Controllers.Roles.SecurityService
{

    [DepartmentFilter]
    [AccessActionFilter(roles: UserRole.SecurityService)]
    public class SSScoringController : AbsController
    {
        public SSScoringController(ControllerParams @params) : base(@params)
        {
        }

        //TODO: добавить методы получения по цепочке вверх

        #region Скоринг модели

        #region CRUD со скоринг моделями

        [HttpGet, Route("GetScoringModels")]
        public async Task<RequestResult> GetScoringModels(int offset, int count = 20)
        {
            var queryable = DB.ScoringModels.Include(o => o.Category)
                                            .Where(o => o.SecurityServiceDepartmentId == this.DepartmentId);
            return GetMany<ScoringModel, ScoringModelClientModel>(queryable, offset, count);
        }

        [HttpGet, Route("GetScoringModel")]
        public async Task<RequestResult> GetScoringModel(int id)
        {
            var model = DB.ScoringModels.Include(o => o.Category)
                                        .Include(o => o.QuestionGroups)
                                        .FirstOrDefault(o => o.Id == id && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseScoringModel(model),
                () => RequestResult<ScoringModel>.AsSuccess(model)
            });
        }


        [HttpPost, Route("CreateScoringModel")]
        public async Task<RequestResult> CreateScoringModel(ScoringModelCreateModel model)
        {
            return TryCreateModel(DB.ScoringModels, model, (item) =>
            {
                item.SecurityServiceDepartmentId = (int)this.DepartmentId;
                return RequestResult.AsSuccess();
            });
        }


        [HttpPut, Route("UpdateScoringModel")]
        public async Task<RequestResult> UpdateScoringModel(ScoringModelEditModel model)
        {
            var item = DB.ScoringModels.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseScoringModel(item),
                () => TryUpdateModel(DB.ScoringModels, item, model)
            });
        }


        [HttpDelete, Route("DeleteScoringModel")]
        public async Task<RequestResult> DeleteScoringModel(int id)
        {
            var item = DB.ScoringModels.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseScoringModel(item),
                () => DeleteModel(DB.ScoringModels, item)
            });
        }

        #endregion

        #region CRUD с группами вопросов

        [HttpGet, Route("GetScoringModelQuestionGroup")]
        public async Task<RequestResult> GetScoringModelQuestionGroup(int modelId, int questionGroupId)
        {
            var model = DB.ScoringModels.FirstOrDefault(o => !o.IsDeleted && o.Id == modelId);

            var questionGroup = DB.ScoringQuestionGroups.Include(o => o.Questions)
                                                        .FirstOrDefault(o => !o.IsDeleted && o.Id == questionGroupId);
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseScoringModelAndQuestionGroup(model,questionGroup),
                () =>
                {
                    IncludeScoringModelQuestionOptions(questionGroup);
                    return RequestResult<ScoringQuestionGroup>.AsSuccess(questionGroup);
                }
            });
        }


        [HttpPost, Route("CreateScoringModelQuestionGroup")]
        public async Task<RequestResult> CreateScoringModelQuestionGroup(int modelId, ScoringQuestionGroupCreateModel model)
        {
            var item = DB.ScoringModels.FirstOrDefault(o => !o.IsDeleted && o.Id == modelId);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseScoringModel(item),
                () => RequestResult.FromBoolean(model.IsValid(), 404, "Проверьте корректность заполнения полей"),
                () =>
                {
                    item.QuestionGroups.Add(model.Create());
                    return UpdateModel(DB.ScoringModels,item);
                }
            });
        }

        [HttpPut, Route("UpdateScoringModelQuestionGroup")]
        public async Task<RequestResult> UpdateScoringModelQuestionGroup(int modelId, ScoringQuestionGroupEditModel model)
        {
            var item = DB.ScoringModels.FirstOrDefault(o => !o.IsDeleted && o.Id == modelId);
            var questionGroup = DB.ScoringQuestionGroups.FirstOrDefault(o => !o.IsDeleted && o.Id == model.Id);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseScoringModelAndQuestionGroup(item, questionGroup),
                () => RequestResult.FromBoolean(model.IsValid(), 404, "Проверьте корректность заполнения полей"),
                () => UpdateModel(DB.ScoringQuestionGroups, questionGroup, model)
            });
        }

        [HttpDelete, Route("DeleteScoringModelQuestionGroup")]
        public async Task<RequestResult> DeleteScoringModelQuestionGroup(int modelId, int questionGroupId)
        {
            var item = DB.ScoringModels.FirstOrDefault(o => !o.IsDeleted && o.Id == modelId);

            var questionGroup = DB.ScoringQuestionGroups.Include(o => o.Questions)
                                                        .FirstOrDefault(o => !o.IsDeleted && o.Id == questionGroupId);
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseScoringModelAndQuestionGroup(item,questionGroup),
                () => DeleteModel(DB.ScoringQuestionGroups, questionGroup)
            });
        }

        #endregion

        #region CRUD с вопросами

        [HttpGet, Route("GetScoringModelQuestion")]
        public async Task<RequestResult> GetScoringModelQuestion(int modelId, int questionId)
        {
            var item = DB.ScoringModels.FirstOrDefault(o => !o.IsDeleted && o.Id == modelId);
            var question = DB.ScoringQuestions.FirstOrDefault(o => !o.IsDeleted && o.Id == questionId);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseScoringModelAndQuestion(item,question),
                () => RequestResult<ScoringQuestion>.AsSuccess(question)
            });
        }

        [HttpPost, Route("CreateScoringModelQuestion")]
        public async Task<RequestResult> CreateScoringModelQuestion(int modelId, int questionGroupId, ScoringQuestion question)
        {
            var item = DB.ScoringModels.FirstOrDefault(o => !o.IsDeleted && o.Id == modelId);
            var questionGroup = DB.ScoringQuestionGroups.FirstOrDefault(o => !o.IsDeleted && o.Id == questionGroupId);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseScoringModelAndQuestionGroup(item, questionGroup),
                () => RequestResult.FromBoolean(question.IsValidToCreate(), 400, "Проверьте корректность заполнения полей"),
                () =>
                {
                    questionGroup.Questions.Add(question);
                    return UpdateModel(DB.ScoringQuestionGroups, questionGroup);
                }
            });
        }


        [HttpPut, Route("UpdateScoringModelQuestion")]
        public async Task<RequestResult> UpdateScoringModelQuestion(int modelId, int questionGroupId, ScoringQuestion question)
        {
            var item = DB.ScoringModels.FirstOrDefault(o => !o.IsDeleted && o.Id == modelId);
            var questionGroup = DB.ScoringQuestionGroups.FirstOrDefault(o => !o.IsDeleted && o.Id == questionGroupId);


            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseQuestionnaireAndQuestionGroup(questionnaire, questionGroup),
                () => RequestResult.FromBoolean(question.IsValidToUpdate(), 400, "Проверьте корректность заполнения полей"),
                () =>
                {
                    if(question is ScoringOptionsQuestion optionsQuestion)
                    {
                        var optionsFromDB = DB.ScoringQuestionOptions.Where(o => o.ScoringOptionsQuestionId == question.Id)
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

                        var newOptions = new  List<ScoringQuestionOption>();
                        foreach(var option in optionsQuestion.Options)
                        {
                            if(!optionsFromDB.Any(o => o.Id == option.Id))
                            {
                                option.ScoringOptionsQuestionId = question.Id;
                                newOptions.Add(option);
                            }
                        }

                        DB.ScoringQuestionOptions.UpdateRange(optionsFromDB);
                        DB.ScoringQuestionOptions.AddRange(newOptions);

                        //Делаем такие мувы, чтобы четенько сохранить варианты ответов без костылей - часть 2
                        optionsQuestion.Options = new List<ScoringQuestionOption>();
                        DB.ScoringQuestions.Update(optionsQuestion);
                        DB.SaveChanges();

                        return RequestResult<ScoringQuestionOption>.AsSuccess(question);
                    }
                    else
                    {
                        return UpdateModel(DB.ScoringQuestions, question);
                    }

                }
            });


        }



        [HttpDelete, Route("DeleteScoringModelQuestion")]
        public async Task<RequestResult> DeleteHRQuestionnaireQuestion(int modelId, int questionId)
        {
            var item = DB.ScoringModels.FirstOrDefault(o => !o.IsDeleted && o.Id == modelId);
            var question = DB.ScoringQuestions.FirstOrDefault(o => !o.IsDeleted && o.Id == questionId);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseScoringModelAndQuestion(item,question),
                () => DeleteModel(DB.ScoringQuestions, question)
            });
        }

        #endregion

        #endregion

        #region Категории скоринг моделей

        [HttpGet, Route("GetScoringModelCategories")]
        public async Task<RequestResult> GetScoringModelCategories(int offset, int count = 20)
        {
            var queryable = DB.ScoringModelCategories.Where(o => o.SecurityServiceDepartmentId == this.DepartmentId);
            return GetMany<ScoringModelCategory, ScoringModelCategoryClientModel>(queryable, offset, count);
        }


        [HttpGet, Route("GetScoringModelCategory")]
        public async Task<RequestResult> GetScoringModelCategory(int id)
        {
            var category = DB.ScoringModelCategories.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseScoringModelCategory(category),
                () => RequestResult<ScoringModelCategory>.AsSuccess(category)
            });
        }




        [HttpPost, Route("CreateScoringModelCategory")]
        public async Task<RequestResult> CreateScoringModelCategory(ScoringModelCategoryCreateModel model)
        {
            return TryCreateModel(DB.ScoringModelCategories, model, (item) =>
            {
                item.SecurityServiceDepartmentId = (int)this.DepartmentId;
                return RequestResult.AsSuccess();
            });
        }



        [HttpPut, Route("UpdateScoringModelCategory")]
        public async Task<RequestResult> UpdateScoringModelCategory(ScoringModelCategoryEditModel model)
        {

            var category = DB.ScoringModelCategories.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseScoringModelCategory(category),
                () => TryUpdateModel(DB.ScoringModelCategories, category, model)
            });
        }


        [HttpDelete, Route("DeleteScoringModelCategory")]
        public async Task<RequestResult> DeleteScoringModelCategory(int id)
        {
            var category = DB.ScoringModelCategories.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseScoringModelCategory(category),
                () => DeleteModel(DB.ScoringModelCategories, category)
            });
        }

        #endregion






        #region Private check methods

        private RequestResult CheckBaseScoringModel(ScoringModel model)
        {
            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(model != null,404,"Скоринг модель с данным id не найдена"),
                () => RequestResult.FromBoolean(model.SecurityServiceDepartmentId == this.DepartmentId,403,"Нет доступа к данной скоринг модели"),
            });
        }
        private RequestResult CheckBaseScoringModelAndQuestionGroup(ScoringModel model, ScoringQuestionGroup questionGroup)
        {
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseScoringModel(model),
                () => RequestResult.FromBoolean(questionGroup != null,404,"Группа вопросов с данным id не найдена"),
                () => RequestResult.FromBoolean(questionGroup.ScoringModelId == model.Id,403,"Группа вопросов не принадлежит данной скоринг модели"),
            });
        }
        private RequestResult CheckBaseScoringModelAndQuestion(ScoringModel model, ScoringQuestion question)
        {
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseScoringModel(model),
                () =>
                {
                    var questionGroup = DB.ScoringQuestionGroups.FirstOrDefault(o => o.Id == question.ScoringQuestionGroupId);
                    return RequestResult.FromBoolean(questionGroup.ScoringModelId == model.Id, 403,"Группа вопросов не принадлежит данному опроснику");
                }
            });
        }


        private RequestResult CheckBaseScoringModelCategory(ScoringModelCategory category)
        {
            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(category != null,404,"Категория с данным id не найден"),
                () => RequestResult.FromBoolean(category.SecurityServiceDepartmentId == this.DepartmentId,403,"Нет доступа к данной категории"),
            });
        }

        #endregion

        #region Private other methods

        private void IncludeScoringModelQuestionOptions(ScoringModel model)
        {
            foreach (var question in model.QuestionGroups.SelectMany(o => o.Questions))
            {
                if (question is ScoringOptionsQuestion optionsQuestion
                    && optionsQuestion.Options.Count == 0)
                {
                    var options = DB.ScoringQuestionOptions.Where(o => !o.IsDeleted
                                                                    && o.ScoringOptionsQuestionId == question.Id);

                    optionsQuestion.Options = options.ToList();
                }
            }
        }
        private void IncludeScoringModelQuestionOptions(ScoringQuestionGroup questionGroup)
        {
            foreach (var question in questionGroup.Questions)
            {
                if (question is ScoringOptionsQuestion optionsQuestion
                    && optionsQuestion.Options.Count == 0)
                {
                    var options = DB.ScoringQuestionOptions.Where(o => !o.IsDeleted
                                                            && o.ScoringOptionsQuestionId == question.Id);

                    optionsQuestion.Options = options.ToList();
                }
            }
        }


        private void ClearDeletedScoringModelEntities(ScoringModel model)
        {
            for (int i = model.QuestionGroups.Count - 1; i >= 0; i--)
            {
                var group = model.QuestionGroups[i];
                if (group.IsDeleted)
                {
                    model.QuestionGroups.Remove(group);
                }
            }

            foreach (var group in model.QuestionGroups)
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

            foreach (var question in model.QuestionGroups.SelectMany(o => o.Questions))
            {
                if (question is ScoringOptionsQuestion optionsQuestion)
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
