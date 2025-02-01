using Alfateam.Core.Enums;
using Alfateam.Core.Exceptions;
using Alfateam.Core.Services;
using Alfateam.DB;
using Alfateam.DB.Services;
using Alfateam.EDM.API.Helpers;
using Alfateam.EDM.API.Models.DTO.Abstractions;
using Alfateam.EDM.API.Models.DTO.Documents.DocumentSigning.Results;
using Alfateam.EDM.API.Models.DTO.Documents.DocumentSigning.Signatures;
using Alfateam.EDM.Models.Abstractions;
using Alfateam.EDM.Models.Counterparties;
using Alfateam.EDM.Models.Documents.DocumentSigning.Results;
using Alfateam.EDM.Models.Documents.DocumentSigning.Signatures;
using Alfateam.EDM.Models.Documents.Formats;
using Alfateam.EDM.Models.Documents.Types;
using Alfateam.EDM.Models.Enums;
using Alfateam.EDM.Models.Enums.DocumentStatuses;
using Alfateam.EDM.Models.General;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.EDM.API.Services
{
    public class DocumentsService
    {
        private EDMDbContext DB;
        private AbsDBService DBService;
        private AbsFilesService FilesService;
        private CertCenterVerificationService CertCenterVerificationService;
        public DocumentsService(EDMDbContext db, 
                               AbsDBService dbService, 
                               AbsFilesService filesService,
                               CertCenterVerificationService certCenterVerificationService)
        {
            DB = db;
            DBService = dbService;
            FilesService = filesService;
            CertCenterVerificationService = certCenterVerificationService;
        }


        public IEnumerable<Document> GetAvailableDocuments(EDMSubject ourEDMSubject, User authorizedUser, bool? drafts = false)
        {
            List<Department> departments = new List<Department>();

            var dbDocuments = DB.Documents.Include(o => o.DepartmentsReferences)
                                          .Include(o => o.Approval)
                                          .Include(o => o.CancellationApproval)
                                          .Include(o => o.Signing)
                                          .Include(o => o.Cancellation)
                                          .Include(o => o.ReadEntries)
                                          .Include(o => o.SigningSides)
                                          .Include(o => o.DraftInfo).ThenInclude(o => o.Department)
                                          .Where(o => !o.IsDeleted);

            switch (authorizedUser.DocumentsAccess.Type)
            {
                case DocumentsAccessType.AllDepartments:

                    departments = DB.Departments.Where(o => !o.IsDeleted && o.EDMSubjectId == ourEDMSubject.Id).ToList();
                    break;
                case DocumentsAccessType.OnlyUserDepartment:

                    var department = DB.Departments.FirstOrDefault(o => o.Id == authorizedUser.DepartmentId);
                    departments = new List<Department> { department };
                    break;
                case DocumentsAccessType.OnlyUserDepartmentAndSubsidiary:

                    var rootDepartment = DB.Departments.FirstOrDefault(o => o.Id == authorizedUser.DepartmentId);

                    departments = DepartmentsHelper.GetThisAndAllSubDepartments(rootDepartment, true);
                    break;
                case DocumentsAccessType.OnlySelectedDepartments:

                    departments = DB.Departments.Where(o => !o.IsDeleted && o.DocumentsAccessId == authorizedUser.DocumentsAccess.Id).ToList();
                    break;
            }

            DepartmentsHelper.HideSoftDeletedDepartments(departments);


            var documents = new List<Document>();

            if (drafts == true)
            {
                documents = dbDocuments.Where(o => o.DraftInfo != null && o.DraftInfo.Department.EDMSubjectId == ourEDMSubject.Id)
                                       .ToList()
                                       .Where(o => departments.Any(a => a.Id == o.DraftInfo.DepartmentId))
                                       .ToList();
            }
            else if (drafts == false)
            {
                documents = dbDocuments.AsEnumerable()
                                       .Where(o => o.SigningSides.Any(o => o.IsThisSubject(ourEDMSubject)))
                                       .ToList();
            }


            return documents;
        }
        public Counterparty? GetCounterpartyFromSide(int edmSubjectId, DocumentSigningSide side)
        {
            var counterparties = DB.Counterparties.Where(o => o.EDMSubjectId == edmSubjectId).ToList();
            return counterparties.FirstOrDefault(o => o.IsThisDocumentSigningSide(side));
        }




        public List<DocumentSigningSide> GetUnsignedSides(Document document, bool isCancellationSigning)
        {
            var unsignedSides = new List<DocumentSigningSide>();

            var signingResults = DB.DocumentSigningResults.Where(o => o.DocumentSigningMetadataId == document.Signing.Id);
            if (isCancellationSigning)
            {
                signingResults = DB.DocumentSigningResults.Where(o => o.DocumentCancellationMetadataId == document.Cancellation.Id);
            }


            foreach (var side in document.SigningSides.Where(o => !o.IsDeleted))
            {
                if (!signingResults.Any(o => o.SideId == side.Id))
                {
                    unsignedSides.Add(side);
                }
            }

            return unsignedSides;
        }
        public DocumentSigningSide TryGetOurSigningSide(Document document, EDMSubject ourEDMSubject)
        {
            var ourSide = document.SigningSides.FirstOrDefault(o => !o.IsDeleted && o.IsThisSubject(ourEDMSubject));
            if(ourSide == null)
            {
                throw new Exception403("Субъект ЭДО не находится в списке сторон подписания документа");
            }
            return ourSide;
        }
        public bool IsSideSignedOrRejected(Document document, int sideId, bool isCancellationSigning)
        {
            return !GetUnsignedSides(document, isCancellationSigning).Any(o => o.Id == sideId);
        }
        public bool IsOnlyOurSideNotSigned(Document document, int sideId, bool isCancellationSigning)
        {
            return GetUnsignedSides(document, isCancellationSigning).Count == 1 
                && !IsSideSignedOrRejected(document, sideId, isCancellationSigning);
        }





        public void ThrowIfDocumentTypeNotValid(Document document)
        {
            var type = DBService.TryGetOne(DB.DocumentTypes, document.TypeId);
            if (type.Purpose == DocumentTypePurpose.ForDocumentWithFile && document is not DocumentWithFile)
            {
                throw new Exception400("Тип документа не соответствует документу. Должен быть документ с файлом");
            }
            else if (type.Purpose == DocumentTypePurpose.ForPriceListDocument && document is not PriceListDocument)
            {
                throw new Exception400("Тип документа не соответствует документу. Должен быть ценовой лист");
            }
            else if (type.Purpose == DocumentTypePurpose.ForWithPositionItemsDocument && document is not WithPositionItemsDocument)
            {
                throw new Exception400("Тип документа не соответствует документу. Должен быть документ с позициями");
            }
            else if (type.Purpose == DocumentTypePurpose.ForDocumentParcel && document is not DocumentsParcel)
            {
                throw new Exception400("Тип документа не соответствует документу. Должен быть пакет документов");
            }
        }
    }
}
