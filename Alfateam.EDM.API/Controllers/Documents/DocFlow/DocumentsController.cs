using Alfateam.Core;
using Alfateam.Core.Enums;
using Alfateam.Core.Exceptions;
using Alfateam.EDM.API.Abstractions;
using Alfateam.EDM.API.Enums;
using Alfateam.EDM.API.Helpers;
using Alfateam.EDM.API.Models;
using Alfateam.EDM.API.Models.DTO.Abstractions;
using Alfateam.EDM.API.Models.DTO.ApprovalRoutes;
using Alfateam.EDM.API.Models.DTO.Documents;
using Alfateam.EDM.API.Models.DTO.Documents.DocumentSigning.Results;
using Alfateam.EDM.API.Models.DTO.Documents.DocumentSigning.Sides;
using Alfateam.EDM.API.Models.DTO.Documents.DocumentSigning.Signatures;
using Alfateam.EDM.Models.Abstractions;
using Alfateam.EDM.Models.Documents;
using Alfateam.EDM.Models.Documents.DocumentSigning;
using Alfateam.EDM.Models.Documents.DocumentSigning.ApproveStrategies;
using Alfateam.EDM.Models.Documents.DocumentSigning.Results;
using Alfateam.EDM.Models.Documents.DocumentSigning.Sides;
using Alfateam.EDM.Models.Documents.DocumentSigning.Signatures;
using Alfateam.EDM.Models.Documents.Formats;
using Alfateam.EDM.Models.Documents.Types;
using Alfateam.EDM.Models.Enums;
using Alfateam.EDM.Models.Enums.DocumentStatuses;
using Alfateam.EDM.Models.General;
using Alfateam.Website.API.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections;
using System.Linq;


namespace Alfateam.EDM.API.Controllers.Documents.DocFlow
{
    public class DocumentsController : AbsAuthorizedController
    {
        public DocumentsController(ControllerParams @params) : base(@params)
        {
        }

        #region Редактирование черновика и отправка на подписание

        [HttpPut, Route("EditDraftDocument")]
        public async Task<DocumentDTO> EditDraftDocument(DocumentDTO model)
        {
            var document = TryGetDraftDocument(model.Id);
            if(document.Discriminator != model.Discriminator)
            {
                throw new Exception400("Получена структура документа другого типа");
            }

            return (DocumentDTO)DBService.TryUpdateEntity(DB.Documents, model, document, (entity) =>
            {
                DocService.ThrowIfDocumentTypeNotValid(entity);

                if (entity is PriceListDocument priceListDocument)
                {
                    priceListDocument.Items.Clear();
                }
                else if(entity is WithPositionItemsDocument withPositionItemsDocument)
                {
                    withPositionItemsDocument.Items.Clear();
                }
                else if(entity is DocumentsParcel documentsParcel)
                {
                    foreach(var parcelDoc in documentsParcel.Documents)
                    {
                        if (parcelDoc is PriceListDocument priceListParcelDocument)
                        {
                            priceListParcelDocument.Items.Clear();
                        }
                        else if (parcelDoc is WithPositionItemsDocument withPositionItemsParcelDocument)
                        {
                            withPositionItemsParcelDocument.Items.Clear();
                        }
                    }
                }
            });
        }


        [HttpPut, Route("SetDraftDocumentSigningSides")]
        public async Task SetDraftDocumentSigningSides(int draftDocumentId, IEnumerable<AlfateamEDMDocumentSigningSideDTO> signingSideModels)
        {
            var document = TryGetDraftDocument(draftDocumentId);
            int sidesCount = signingSideModels.Count() + 1; //Другие стороны подписания + наша
            ThrowIfIncorrectDocumentSidesCount(sidesCount, document.Type);

            document.SigningSides.Clear();
            document.SigningSides.Add(new AlfateamEDMDocumentSigningSide
            {
                SubjectId = (int)this.EDMSubjectId
            });

            foreach(var signingSideModel in signingSideModels)
            {
                document.SigningSides.Add(signingSideModel.CreateDBModelFromDTO() as AlfateamEDMDocumentSigningSide);
            }

            if(document is DocumentsParcel documentsParcel)
            {
                foreach(var parcelDoc in documentsParcel.Documents)
                {
                    parcelDoc.SigningSides = new List<AlfateamEDMDocumentSigningSide>(parcelDoc.SigningSides);
                }
            }

            ThrowIfHasDocumentSideDuplicate(document);
            DBService.UpdateEntity(DB.Documents, document);
        }

        [HttpPut, Route("PushFromDraftsToSigning")]
        public async Task PushFromDraftsToSigning(int draftDocumentId)
        {
            var document = TryGetDraftDocument(draftDocumentId);
            if (!document.SigningSides.Any())
            {
                throw new Exception400("В данном документе не указаны стороны подписания");
            }
            if (!document.SigningSides.Any(o => o.SubjectId == this.EDMSubject.Id))
            {
                throw new Exception400("В данном документе нет нашей стороны подписания");
            }
            ThrowIfIncorrectDocumentSidesCount(document.SigningSides.Count, document.Type);
            ThrowIfHasDocumentSideDuplicate(document);

            document.DraftInfo = null;
            DBService.UpdateEntity(DB.Documents, document);
        }

        #endregion

        [HttpPut, Route("ReplaceDocumentsToDepartment")]
        public async Task ReplaceDocumentsToDepartment(int toDepartmentId, [FromBody] List<int> documentIds)
        {
            var documents = DB.Documents.Include(o => o.DepartmentsReferences)
                                        .AsEnumerable()
                                        .Where(o => documentIds.Contains(o.Id));


            var subjects = DB.EDMSubjects.Include(o => o.Department)
                                         .Where(o => !o.IsDeleted && o.BusinessId == BusinessId);
            var subject = DBService.TryGetOne(subjects, (int)EDMSubjectId);
            var toDepartment = DBService.TryGetOne(DepartmentsHelper.GetThisAndAllSubDepartments(subject.Department, true), toDepartmentId);


            foreach (var document in documents)
            {
                DepartmentsHelper.ReplaceDocumentDepartment((int)EDMSubjectId, document, toDepartment);
            }

            DBService.UpdateEntities(DB.Documents, documents);
        }








        #region Private methods

        private Document TryGetDraftDocument(int draftDocumentId)
        {
            var document = DBService.TryGetOne(DocService.GetAvailableDocuments(this.EDMSubject, this.AuthorizedUser, null), draftDocumentId);
            if (document.DraftInfoId == null)
            {
                throw new Exception400("Данный документ не является черновиком");
            }
            return document;
        }

        private void ThrowIfHasDocumentSideDuplicate(Document document)
        {
            SortedSet<int> uniqueIds = new SortedSet<int>();
            foreach(var side in document.SigningSides)
            {
                if (!uniqueIds.Add(side.SubjectId))
                {
                    throw new Exception400($"Все стороны подписания должны быть разными. Id={side.SubjectId} дублируется");
                }
            }
        }
        private void ThrowIfIncorrectDocumentSidesCount(int sidesCount, DocumentType type)
        {
            if (sidesCount < type.MinRequiredDocumentSides)
            {
                throw new Exception400($"В данном типе документа должно быть как минимум {type.MinRequiredDocumentSides} сторона(ы) подписания");
            }
            else if (sidesCount > type.MaxRequiredDocumentSides)
            {
                throw new Exception400($"В данном типе документа не может быть более {type.MaxRequiredDocumentSides} сторон подписания");
            }
        }

        #endregion
    }
}
