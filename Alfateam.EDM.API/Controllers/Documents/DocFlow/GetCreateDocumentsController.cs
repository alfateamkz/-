using Alfateam.EDM.Models.Enums;
using Alfateam.Core;
using Alfateam.Core.Exceptions;
using Alfateam.EDM.API.Abstractions;
using Alfateam.EDM.API.Enums;
using Alfateam.EDM.API.Models;
using Alfateam.EDM.API.Models.Documents;
using Alfateam.EDM.API.Models.DTO.Abstractions;
using Alfateam.EDM.API.Models.DTO.Documents;
using Alfateam.EDM.Models.Abstractions;
using Alfateam.EDM.Models.Documents.DocumentSigning.Sides;
using Alfateam.EDM.Models.Documents.Types;
using Alfateam.EDM.Models.General;
using Alfateam.Website.API.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Alfateam.EDM.API.Models.DTO.Documents.Types;
using Alfateam.EDM.Models.Documents.Formats;
using Alfateam.EDM.Models.Documents.DocumentSigning;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Microsoft.EntityFrameworkCore.Migrations.Internal;
using DocumentFormat.OpenXml.Office2010.PowerPoint;
using MigraDoc.Rendering;
using MigraDoc.DocumentObjectModel;
using Document = Alfateam.EDM.Models.Abstractions.Document;

namespace Alfateam.EDM.API.Controllers.Documents.DocFlow
{
    public class GetCreateDocumentsController : AbsDocumentsController
    {
        public GetCreateDocumentsController(ControllerParams @params) : base(@params)
        {
        }

        #region Получение документов

        [HttpGet, Route("GetDocuments")]
        public async Task<ItemsWithTotalCount<DocumentDTO>> GetDocuments([FromQuery] DocumentsFilterModel filter)
        {
            var documents = filter.FilterDocuments(GetAvailableDocuments().ToList(), DB, EDMSubject);
            return new ItemsWithTotalCount<DocumentDTO>
            {
                Items = new DocumentDTO().CreateDTOs(documents.Skip(filter.Offset).Take(filter.Count)).Cast<DocumentDTO>().ToList(),
                TotalCount = documents.Count()
            };
        }

        [HttpGet, Route("GetDocument")]
        public async Task<DocumentDTO> GetDocument(bool drafts, int id)
        {
            return (DocumentDTO)DBService.TryGetOne(GetAvailableDocuments(drafts), id, new DocumentDTO());
        }

        [HttpPost, Route("DownloadDocumentAsPDF")]
        public async Task DownloadDocumentAsPDF(int documentId)
        {
            //TODO: DownloadDocumentAsPDF
        }

        [HttpPost, Route("DownloadDocumentFlowArchive")]
        public async Task DownloadDocumentFlowArchive(int documentId)
        {
            //TODO: DownloadDocumentFlowArchive 
        }

        #endregion

        #region Создание документов

        [HttpPost, Route("CreateDocumentsParcel")]
        public async Task<DocumentsParcelDTO> CreateDocumentsParcel(DocumentsParcelDTO model)
        {
            if (model.Documents.Any(o => o is DocumentsParcelDTO))
            {
                throw new Exception400("Создание пакета документов в пакете недопустимо");
            }
            if (!model.IsValid())
            {
                throw new Exception400("Проверьте корректность заполнения полей");
            }

            var mainDepartment = GetOurMainDepartment();
            var parcelEntity = model.CreateDBModelFromDTO() as DocumentsParcel;

            AddOurSigningSideToDocument(parcelEntity, mainDepartment);
            CheckSigningSidesIfNotDraft(parcelEntity);

            foreach (var document in parcelEntity.Documents)
            {
                if (document.SigningSides.Any())
                {
                    throw new Exception400("Во вложенных в пакет документах не нужно задавать SigningSides. Достаточно только в пакете");
                }

                if (document is DocumentWithFile docWithFile)
                {
                    UploadedFilesService.ThrowIfFileNotAvailable(docWithFile.FileId);
                }

                document.SigningSides.AddRange(parcelEntity.SigningSides);

                SetDefaultTypeIfNotDocumentWithFile(document);
                DocService.ThrowIfDocumentTypeNotValid(document);
                document.Init(AuthorizedUser!.Id);
            }


            DBService.CreateEntity(DB.Documents, parcelEntity);
            foreach (var document in parcelEntity.Documents.Cast<DocumentWithFile>())
            {
                UploadedFilesService.TryBindFileWithEntity(document.FileId);
            }

            return (DocumentsParcelDTO)new DocumentsParcelDTO().CreateDTO(parcelEntity);
        }

        [HttpPost, Route("CreateDocuments")]
        public async Task<CreateDocumentsResult> CreateDocuments(IEnumerable<DocumentDTO> models)
        {
            if (models.Any(o => o is DocumentsParcelDTO))
            {
                throw new Exception400("Пакетное создание пакетов документов недопустимо. Используйте эндпоинт CreateDocumentsParcel");
            }

            var result = new CreateDocumentsResult();

            var mainDepartment = GetOurMainDepartment();
            foreach (var model in models)
            {
                result.Results.Add(TryCreateDocument(model, mainDepartment));
            }

            return result;
        }


        #endregion











        #region Private create document handle methods
        private CreateDocumentResult TryCreateDocument(DocumentDTO model, Department mainDepartment)
        {
            var result = new CreateDocumentResult();

            try
            {
                var createdDocDTO = DBService.TryCreateEntity(DB.Documents, model, callback: (entity) =>
                {
                    AddOurSigningSideToDocument(entity, mainDepartment);
                    CheckSigningSidesIfNotDraft(entity);

                    if (entity is DocumentWithFile docWithFile)
                    {
                        UploadedFilesService.ThrowIfFileNotAvailable(docWithFile.FileId);
                    }

                    SetDefaultTypeIfNotDocumentWithFile(entity);
                    DocService.ThrowIfDocumentTypeNotValid(entity);
                    entity.Init(AuthorizedUser!.Id);
                },
                afterSuccessCallback: (entity) =>
                {
                    if (entity is DocumentWithFile docWithFile)
                    {
                        UploadedFilesService.TryBindFileWithEntity(docWithFile.FileId);
                    }
                });
                result.CreatedDocument = (DocumentDTO)createdDocDTO;
            }
            catch (Exception ex)
            {
                result.Error = ex.Message;
            }

            return result;
        }







        private void CheckSigningSidesIfNotDraft(Document doc)
        {
            if (doc.DraftInfo == null)
            {
                var otherEDMSides = doc.SigningSides.Where(o => !o.IsThisSubject(EDMSubject))
                                                    .Cast<AlfateamEDMDocumentSigningSide>();
                foreach (var side in otherEDMSides)
                {
                    var sideSubject = DB.EDMSubjects.FirstOrDefault(o => o.Id == side.SubjectId);
                    if (CanSignWith(sideSubject.CountryCode, sideSubject.BusinessNumber) != EDMSubjectSigningAccessType.CanSign)
                    {
                        throw new Exception403($"Мы не можем подписаться с контрагентом из {sideSubject.CountryCode} с номером {sideSubject.BusinessNumber}");
                    }
                }
            }
        }
        private Department GetOurMainDepartment()
        {
            var subject = DB.EDMSubjects.Include(o => o.Department)
                                        .FirstOrDefault(o => o.Id == EDMSubjectId && !o.IsDeleted);

            return subject!.Department;
        }
        private void AddOurSigningSideToDocument(Document document, Department ourMainDepartment)
        {
            document.DepartmentsReferences.Add(ourMainDepartment);
            document.SigningSides.Add(new AlfateamEDMDocumentSigningSide()
            {
                SubjectId = (int)EDMSubjectId
            });
        }

        
        private void SetDefaultTypeIfNotDocumentWithFile(Document document)
        {
            if (document is PriceListDocument)
            {
                document.Type = DB.DocumentTypes.FirstOrDefault(o => o.Purpose == DocumentTypePurpose.ForPriceListDocument);
            }
            else if (document is WithPositionItemsDocument)
            {
                document.Type = DB.DocumentTypes.FirstOrDefault(o => o.Purpose == DocumentTypePurpose.ForWithPositionItemsDocument);
            }
            else if (document is DocumentsParcel)
            {
                document.Type = DB.DocumentTypes.FirstOrDefault(o => o.Purpose == DocumentTypePurpose.ForDocumentParcel);
            }
        }


        #endregion

        #region Private convert to PDF methods

        private byte[] ConvertDOCXToPDF(string documentPath)
        {
            throw new();
        }

        private byte[] ConvertXLSXToPDF(string documentPath)
        {
            throw new();
        }
        private byte[] ConvertTXTToPDF(string documentPath)
        {
            //first read text to end add to a string list.
            List<string> textFileLines = new List<string>();
            using (StreamReader sr = new StreamReader(documentPath))
            {
                while (!sr.EndOfStream)
                {
                    textFileLines.Add(sr.ReadLine());
                }
            }

            MigraDoc.DocumentObjectModel.Document doc = new MigraDoc.DocumentObjectModel.Document();
            MigraDoc.DocumentObjectModel.Section section = doc.AddSection();



            //just font arrangements as you wish
            MigraDoc.DocumentObjectModel.Font font = new Font("Times New Roman", 15);
            font.Bold = true;

            //add each line to pdf 
            foreach (string line in textFileLines)
            {
                Paragraph paragraph = section.AddParagraph();
                paragraph.AddFormattedText(line, font);

            }


            //save pdf document
            PdfDocumentRenderer renderer = new PdfDocumentRenderer();
            renderer.Document = doc;
            renderer.RenderDocument();

            using(MemoryStream stream = new MemoryStream())
            {
                renderer.Save(stream,false);
                return stream.GetBuffer();
            }
        }

        #endregion
    }

}
