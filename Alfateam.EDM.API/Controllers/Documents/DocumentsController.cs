using Alfateam.Core.Enums;
using Alfateam.EDM.API.Abstractions;
using Alfateam.EDM.API.Enums;
using Alfateam.EDM.API.Helpers;
using Alfateam.EDM.API.Models;
using Alfateam.EDM.API.Models.DTO.Abstractions;
using Alfateam.EDM.API.Models.DTO.ApprovalRoutes;
using Alfateam.EDM.API.Models.DTO.Documents;
using Alfateam.EDM.Models.Abstractions;
using Alfateam.EDM.Models.Documents.Types;
using Alfateam.EDM.Models.Enums;
using Alfateam.EDM.Models.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace Alfateam.EDM.API.Controllers.Documents
{
    public class DocumentsController : AbsAuthorizedController
    {
        public DocumentsController(ControllerParams @params) : base(@params)
        {
        }

        //TODO: includes of derived types


        #region Получение документов

        [HttpGet, Route("GetDocuments")]
        public async Task<IEnumerable<DocumentDTO>> GetDocuments()
        {
            var documents = GetAvailableDocuments();
            return new DocumentDTO().CreateDTOs(documents).Cast<DocumentDTO>();
        }

        [HttpGet, Route("GetDocumentsByDepartment")]
        public async Task<IEnumerable<DocumentDTO>> GetDocumentsByDepartment(int departmentId)
        {
            var documents = GetAvailableDocuments().Where(o => o.DepartmentsReferences.Any(o => o.Id == departmentId));
            return new DocumentDTO().CreateDTOs(documents).Cast<DocumentDTO>();
        }

        [HttpGet, Route("GetDocument")]
        public async Task<DocumentDTO> GetDocument(int id)
        {
            var documents = GetAvailableDocuments();
            return (DocumentDTO)DBService.TryGetOne(documents, id, new DocumentDTO());
        }

        #endregion

        #region Создание документов

        [HttpPost, Route("CreateDocumentsParcel")]
        public async Task<DocumentsParcelDTO> CreateDocumentsParcel(DocumentCreateEditMode mode, DocumentsParcelDTO model)
        {
            return (DocumentsParcelDTO)DBService.TryCreateEntity(DB.DocumentsParcels, model, async (entity) =>
            {
                await HandleDocuments(mode, entity.Documents);
            });
        }

        [HttpPost, Route("CreateDocuments")]
        public async Task<IEnumerable<DocumentDTO>> CreateDocuments(DocumentCreateEditMode mode, IEnumerable<DocumentDTO> models)
        {
            return DBService.TryCreateEntities(DB.Documents, models, async (entities) =>
            {
                await HandleDocuments(mode, entities);
            }).Cast<DocumentDTO>();
        }


        #endregion

        #region Согласование документов






        #endregion


        #region Аннулирование документов






        #endregion






        [HttpPut, Route("ReplaceDocumentsToDepartment")]
        public async Task ReplaceDocumentsToDepartment(int toDepartmentId, [FromBody] List<int> documentIds)
        {
            var documents = DB.Documents.Include(o => o.DepartmentsReferences)
                                        .AsEnumerable()
                                        .Where(o => documentIds.Contains(o.Id));


            var subjects = DB.EDMSubjects.Include(o => o.Department)
                                         .Where(o => !o.IsDeleted && o.BusinessId == this.BusinessId);
            var subject = DBService.TryGetOne(subjects, (int)this.EDMSubjectId);
            var toDepartment = DBService.TryGetOne(DepartmentsHelper.GetThisAndAllSubDepartments(subject.Department, true), toDepartmentId);


            foreach (var document in documents)
            {
                DepartmentsHelper.ReplaceDocumentDepartment((int)this.EDMSubjectId, document, toDepartment);
            }

            DBService.UpdateEntities(DB.Documents, documents);
        }








        private IEnumerable<Document> GetAvailableDocuments()
        {
            var user = this.AuthorizedUser;

            List<Department> departments = new List<Department>();

            switch (user.DocumentsAccess.Type)
            {
                case DocumentsAccessType.AllDepartments:

                    departments = DB.Departments.Include(o => o.Documents).ThenInclude(o => o.DepartmentsReferences)
                                                .Where(o => !o.IsDeleted && o.EDMSubjectId == this.EDMSubjectId)
                                                .ToList();
                    break;
                case DocumentsAccessType.OnlyUserDepartment:

                    var department = DB.Departments.Include(o => o.Documents).ThenInclude(o => o.DepartmentsReferences)
                                                   .FirstOrDefault(o => o.Id == user.DepartmentId);
                    departments = new List<Department> { department };
                    break;
                case DocumentsAccessType.OnlyUserDepartmentAndSubsidiary:

                    var rootDepartment = DB.Departments.Include(o => o.Documents).ThenInclude(o => o.DepartmentsReferences)
                                                       .Include(o => o.SubDepartments)
                                                       .FirstOrDefault(o => o.Id == user.DepartmentId);

                    departments = DepartmentsHelper.GetThisAndAllSubDepartments(rootDepartment, true);
                    break;
                case DocumentsAccessType.OnlySelectedDepartments:

                    departments = DB.Departments.Include(o => o.Documents).ThenInclude(o => o.DepartmentsReferences)
                                                .Where(o => !o.IsDeleted && o.DocumentsAccessId == user.DocumentsAccess.Id)
                                                .ToList();
                    break;
            }

            DepartmentsHelper.HideSoftDeletedDepartments(departments);
            return departments.SelectMany(o => o.Documents).Where(o => !o.IsDeleted);
        }




        private async Task HandleDocuments(DocumentCreateEditMode mode, IEnumerable<Document> allDocuments)
        {
            var simpleDocuments = allDocuments.Where(o => o is DocumentWithFile)
                                              .Cast<DocumentWithFile>()
                                              .ToList();

            for (int i = 0; i < simpleDocuments.Count; i++)
            {
                await HandleNonFormalizedDocument(simpleDocuments[i], i);
            }

            var mainDepartment = DB.EDMSubjects.Include(o => o.Department)
                                               .FirstOrDefault(o => o.Id == this.EDMSubjectId && !o.IsDeleted)
                                               .Department;
            foreach(var doc in allDocuments)
            {
                doc.DepartmentsReferences.Add(mainDepartment);

                if (mode == DocumentCreateEditMode.FinalDocument)
                {
                    
                }
                else if (mode == DocumentCreateEditMode.Draft)
                {

                }
            } 
        }
        private async Task HandleNonFormalizedDocument(DocumentWithFile document, int counter)
        {
            document.DocumentPath = await FilesService.TryUploadFile(counter, FileType.Document);
        }
    }
}
