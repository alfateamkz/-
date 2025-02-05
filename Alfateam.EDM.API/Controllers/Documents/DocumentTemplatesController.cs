using Alfateam.CertificationCenter.Models.Abstraction;
using Alfateam.Core;
using Alfateam.Core.Exceptions;
using Alfateam.EDM.API.Abstractions;
using Alfateam.EDM.API.Models;
using Alfateam.EDM.API.Models.DTO;
using Alfateam.EDM.API.Models.DTO.Abstractions;
using Alfateam.EDM.API.Models.DTO.Documents.Templates;
using Alfateam.EDM.API.Models.DTO.Documents.Types;
using Alfateam.EDM.Models;
using Alfateam.EDM.Models.Abstractions;
using Alfateam.EDM.Models.Documents.DocumentSigning;
using Alfateam.EDM.Models.Documents.DocumentSigning.Sides;
using Alfateam.EDM.Models.Documents.Meta;
using Alfateam.EDM.Models.Documents.Templates;
using Alfateam.EDM.Models.Documents.Types;
using Alfateam.EDM.Models.Enums;
using Alfateam.SharedModels;
using DocumentFormat.OpenXml.Wordprocessing;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System.ComponentModel;

namespace Alfateam.EDM.API.Controllers.Documents
{
    public class DocumentTemplatesController : AbsDocumentsController
    {
        public DocumentTemplatesController(ControllerParams @params) : base(@params)
        {
        }

        #region Шаблоны документов

        [HttpGet, Route("GetDocumentTemplates")]
        public async Task<ItemsWithTotalCount<DocumentTemplateDTO>> GetDocumentTemplates([FromQuery] SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<DocumentTemplate, DocumentTemplateDTO>(GetAvailableDocumentTemplates(), filter.Offset, filter.Count, (entity) =>
            {
                bool condition = true;

                if (!string.IsNullOrEmpty(filter.Query))
                {
                    condition &= entity.ToString().Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }

                return condition;
            });
        }

        [HttpGet, Route("GetDocumentTemplate")]
        public async Task<DocumentTemplateDTO> GetDocumentTemplate(int id)
        {
            return (DocumentTemplateDTO)DBService.TryGetOne(GetAvailableDocumentTemplates(), id, new DocumentTemplateDTO());
        }







        [HttpPost, Route("CreateDocumentTemplate")]
        public async Task<DocumentTemplateDTO> CreateDocumentTemplate(DocumentTemplateDTO model)
        {
            return (DocumentTemplateDTO)DBService.TryCreateEntity(DB.DocumentTemplates, model, callback: (entity) =>
            {
                UploadedFilesService.ThrowIfFileNotAvailable(entity.DocumentFileId);
                entity.EDMSubjectId = (int)this.EDMSubjectId;
            }, 
            afterSuccessCallback: (entity) => 
            {
                UploadedFilesService.TryBindFileWithEntity(entity.DocumentFileId);
            });
        }

        [HttpPut, Route("UpdateDocumentTemplate")]
        public async Task<DocumentTemplateDTO> UpdateDocumentTemplate(DocumentTemplateDTO model)
        {
            var template = DBService.TryGetOne(GetAvailableDocumentTemplates(), model.Id);
            string oldFileName = template.DocumentFileId;
            UploadedFilesService.ThrowIfNewFileNotAvailable(oldFileName, model.DocumentFileId);

            return (DocumentTemplateDTO)DBService.TryUpdateEntity(DB.DocumentTemplates, model, template, callback: (entity) =>
            {
                entity.Placeholders.Clear();
            },
            afterSuccessCallback: (entity) =>
            {
                UploadedFilesService.TryBindFileWithEntityIfChanged(oldFileName, entity.DocumentFileId);
            });
        }


        [HttpDelete, Route("DeleteDocumentTemplate")]
        public async Task DeleteDocumentTemplate(int id)
        {
            var group = DBService.TryGetOne(GetAvailableDocumentTemplates(), id);

            DBService.TryDeleteEntity(DB.DocumentTemplates, group);
            UploadedFilesService.TryUnbindFile(group.DocumentFile);
        }

        #endregion

        #region Обработка документа (подстановка значений в плейсхолдеры)

        [HttpPost, Route("SetDocumentPlaceholderValues")]
        public async Task<DocumentWithFileDTO> SetDocumentPlaceholderValues(int templateId, [FromBody] Dictionary<string, string> values)
        {
            var template = DBService.TryGetOne(GetAvailableDocumentTemplates(), templateId);

            foreach(var placeholder in template.Placeholders)
            {
                if(placeholder.IsRequired 
                    && (!values.ContainsKey(placeholder.Placeholder) || string.IsNullOrEmpty(values[placeholder.Placeholder])))
                {
                    throw new Exception400($"Обязательный плейсхолдер {placeholder.Title} ({placeholder.Placeholder}) не указан или пустой");
                }
            }

            var placeholders = values.Where(o => !string.IsNullOrEmpty(o.Value) && template.Placeholders.Any(a => a.Placeholder == o.Key));
            var placeholdersDictionary = new Dictionary<string, string>(placeholders);

            var docFilePath = CreateDocumentFileWithPlaceholders(template.DocumentFile.RelativePath, placeholdersDictionary);
            var authorizedUser = this.AuthorizedUser;

            var newDocument = new DocumentWithFile
            {
                CreatedById = authorizedUser.Id,
                TypeId = template.DocumentTypeId,
                DraftInfo = new EDM.Models.Documents.DocumentDraftInfo
                {
                    DepartmentId = authorizedUser.DepartmentId,
                },
                File = new UploadedFile
                {
                    RelativePath = docFilePath,
                },
                Metadata = new DocumentMetadata(),
                DocumentDate = DateTime.UtcNow,
                Title = "Только что созданный документ",
                Approval = new DocumentApprovalMetadata(),
                Signing = new DocumentSigningMetadata(),
                Cancellation = new DocumentCancellationMetadata(),
                CancellationApproval = new DocumentCancellationApprovalMetadata(),
                SigningSides = new List<AlfateamEDMDocumentSigningSide>
                {
                    new AlfateamEDMDocumentSigningSide
                    {
                        SubjectId = (int)this.EDMSubjectId
                    }
                }
            };
            DBService.CreateEntity(DB.Documents, newDocument);
            UploadedFilesService.TryBindFileWithEntity(newDocument.File.Id);

            return (DocumentWithFileDTO)new DocumentWithFileDTO().CreateDTO(newDocument);
        }


        #endregion








        #region Private set placeholders methods


        private string CreateDocumentFileWithPlaceholders(string templateFilePath, Dictionary<string, string> placeholders)
        {
            var fileExtension = System.IO.Path.GetExtension(templateFilePath);
            var fullDocumentPath = Path.Combine(System.IO.Path.GetDirectoryName(templateFilePath),$"{Guid.NewGuid().ToString()}{fileExtension}");

            if (fileExtension == ".pdf")
            {
                SetPDFDocumentPlaceholders(templateFilePath, fullDocumentPath, placeholders);
            }
            else if (fileExtension == ".doc" || fileExtension == ".docx")
            {
                SetDOCXDocumentPlaceholders(templateFilePath, fullDocumentPath, placeholders);
            }
            else if (fileExtension == ".xls" || fileExtension == ".xlsx")
            {
                SetXLSXDocumentPlaceholders(templateFilePath, fullDocumentPath, placeholders);
            }
            else if (fileExtension == ".txt")
            {
                SetTXTDocumentPlaceholders(templateFilePath, fullDocumentPath, placeholders);
            }
            else
            {
                throw new Exception400("Данный документ не поддерживается для подстановки значений");
            }

            return fullDocumentPath;
        }


        private void SetXLSXDocumentPlaceholders(string origFile, string resultFile, Dictionary<string, string> placeholders)
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            ExcelPackage excel = new ExcelPackage(origFile);
            foreach (var worksheet in excel.Workbook.Worksheets)
            {
                for (int row = 1; row < worksheet.Rows.EndRow + 1; row++)
                {
                    for (int column = 1; column < worksheet.Columns.EndColumn + 1; column++)
                    {
                        if (!string.IsNullOrEmpty(worksheet.Cells[row, column].Value as string))
                        {
                            string value = worksheet.Cells[row, column].Value as string;
                            foreach(var placeholder in placeholders)
                            {
                                worksheet.Cells[row, column].Value = value.Replace($"{{{{{placeholder.Key}}}}}", placeholder.Value);
                            }
                        }
                    }
                }
            }
            excel.SaveAs(resultFile);
        }
        private void SetTXTDocumentPlaceholders(string origFile, string resultFile, Dictionary<string, string> placeholders)
        {
            var text = System.IO.File.ReadAllText(origFile);
            foreach (var placeholder in placeholders)
            {
                text = text.Replace($"{{{{{placeholder.Key}}}}}", placeholder.Value);
            }
            System.IO.File.WriteAllText(resultFile, text);
        }
        private void SetDOCXDocumentPlaceholders(string origFile, string resultFile, Dictionary<string, string> placeholders)
        {
            using (var templater = DocxTemplater.DocxTemplate.Open(origFile))
            {
                foreach (var placeholder in placeholders)
                {
                    templater.BindModel(placeholder.Key, placeholder.Value);
                }
                templater.Save(resultFile);
            }
        }
        private void SetPDFDocumentPlaceholders(string origFile, string resultFile, Dictionary<string,string> placeholders)
        {
            using (PdfReader reader = new PdfReader(origFile))
            {
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    string contentString = PdfEncodings.ConvertToString(reader.GetPageContent(i), PdfObject.TEXT_PDFDOCENCODING);
                    foreach(var placeholder in placeholders)
                    {
                        contentString = contentString.Replace($"{{{{{placeholder.Key}}}}}", placeholder.Value);
                    }
                  
                    reader.SetPageContent(i, PdfEncodings.ConvertToBytes(contentString, PdfObject.TEXT_PDFDOCENCODING));
                }
                new PdfStamper(reader, new FileStream(resultFile, FileMode.Create, FileAccess.Write)).Close();
            }
        }


        #endregion

        #region Private methods
        private IEnumerable<DocumentTemplate> GetAvailableDocumentTemplates()
        {
            return DB.DocumentTemplates.Include(o => o.Placeholders)
                                       .Include(o => o.DocumentType)
                                       .Include(o => o.DocumentFile)
                                       .Where(o => !o.IsDeleted && o.EDMSubjectId == this.EDMSubjectId);
        }

        #endregion
    }
}
