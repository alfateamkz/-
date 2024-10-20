using Alfateam.DB;
using Alfateam.EDM.API.Enums;
using Alfateam.EDM.API.Helpers;
using Alfateam.EDM.Models.Abstractions;
using Alfateam.EDM.Models.Enums.DocumentStatuses;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.EDM.API.Models
{
    public class DocumentsFilterModel
    {
        public int? DepartmentId { get; set; }
        public bool IncludingSubsidiaryDepartments { get; set; }


        public DocumentStatusType? StatusType { get; set; }
        /// <summary>
        /// Если StatusType == Handling, то используется enum DocumentHandlingTypeFilter
        /// Если StatusType == ApprovalStatus, то используется enum из бд DocumentApprovalStatus
        /// Если StatusType == CancellationApprovalStatus, то используется enum из бд DocumentCancellationApprovalStatus
        /// Если StatusType == SigningResult, то используется enum из бд DocumentSigningResultType
        /// Если StatusType == CancellationResult, то используется enum из бд DocumentCancellationResult
        /// </summary>
        public int? StatusTypeValue { get; set; }


        public int? DocumentTypeId { get; set; }


        public DocumentDateSortFor DateSortFilterFor { get; set; }
        public DateSortFilter DateSortFilter { get; set; }



        public List<Document> FilterDocuments(List<Document> documents, EDMDbContext db, EDMSubject ourEDMSubject)
        {
            documents = FilterByDocType(documents);
            documents = FilterByDateSort(documents);
            documents = FilterByStatus(documents, db, ourEDMSubject);
            documents = FilterByDepartments(documents, db);

            return documents;
        }

        public List<Document> FilterByDocType(List<Document> documents)
        {
            if (this.DocumentTypeId != null)
            {
                documents = documents.Where(o => o.TypeId == this.DocumentTypeId).ToList();
            }
            return documents;
        }
        public List<Document> FilterByDateSort(List<Document> documents)
        {
            DateTime filterFrom = DateTime.MinValue;
            DateTime filterTo = DateTime.MaxValue;
            switch (this.DateSortFilter.Type)
            {
                case DateSortFilterType.Any:
                    break;
                case DateSortFilterType.Day:
                    filterFrom = this.DateSortFilter.Date1.Date;
                    filterTo = this.DateSortFilter.Date1.Date.AddDays(1);
                    break;
                case DateSortFilterType.Month:
                    filterFrom = new DateTime(this.DateSortFilter.Year, this.DateSortFilter.MonthOrQuarter, 1);
                    filterTo = new DateTime(this.DateSortFilter.Year, this.DateSortFilter.MonthOrQuarter, 1).AddMonths(1);
                    break;
                case DateSortFilterType.Quarter:
                    int quarterMonth = this.DateSortFilter.MonthOrQuarter + ((this.DateSortFilter.MonthOrQuarter - 1) * 3);

                    filterFrom = new DateTime(this.DateSortFilter.Year, quarterMonth, 1);
                    filterTo = new DateTime(this.DateSortFilter.Year, quarterMonth, 1).AddMonths(3);
                    break;
                case DateSortFilterType.Year:
                    filterFrom = new DateTime(this.DateSortFilter.Year, 1, 1);
                    filterTo = new DateTime(this.DateSortFilter.Year, 1, 1).AddYears(1);
                    break;
                case DateSortFilterType.Interval:
                    filterFrom = this.DateSortFilter.Date1.Date;
                    filterTo = this.DateSortFilter.Date2.Date;
                    break;
            }

            switch (this.DateSortFilterFor)
            {
                case DocumentDateSortFor.DateOfGetting:
                    documents = documents.Where(o => o.DeliveredToSigningSidesAt >= filterFrom && o.DeliveredToSigningSidesAt <= filterTo).ToList();
                    break;
                case DocumentDateSortFor.DateOfTarification:
                    documents = documents.Where(o => o.TariffedAt >= filterFrom && o.TariffedAt <= filterTo).ToList();
                    break;
                case DocumentDateSortFor.DateOfDocument:
                    documents = documents.Where(o => o.DocumentDate >= filterFrom && o.DocumentDate <= filterTo).ToList();
                    break;
                case DocumentDateSortFor.DateOfStatusChange:
                    documents = documents.Where(o => o.StatusChangedAt >= filterFrom && o.StatusChangedAt <= filterTo).ToList();
                    break;
            }

            return documents;
        }
        public List<Document> FilterByStatus(List<Document> documents, EDMDbContext db, EDMSubject ourEDMSubject)
        {
            if (this.StatusType != null)
            {
                switch (this.StatusType)
                {
                    case DocumentStatusType.Handling:
                        var handlingEnum = (DocumentHandlingTypeFilter)this.StatusTypeValue;
                        switch (handlingEnum)
                        {
                            case DocumentHandlingTypeFilter.NotReadYet:
                                documents = documents.Where(o => o.IsDocumentReadBy(ourEDMSubject.Id)).ToList();
                                break;
                            case DocumentHandlingTypeFilter.SignatureRequired:
                                for (int i = documents.Count - 1; i >= 0; i--)
                                {
                                    var doc = documents[i];
                                    var signings = db.DocumentSigningResults.Include(o => o.Side)
                                                                            .Where(o => o.DocumentSigningMetadataId == doc.Signing.Id && !o.IsDeleted);
                                    if (signings.Any(o => o.Side.IsThisSubject(ourEDMSubject)))
                                    {
                                        documents.Remove(doc);
                                    }
                                }
                                break;
                            case DocumentHandlingTypeFilter.SignatureError:
                                //TODO:  DocumentHandlingTypeFilter.SignatureError filter
                                break;
                            case DocumentHandlingTypeFilter.CancellationRequired:
                                for (int i = documents.Count - 1; i >= 0; i--)
                                {
                                    var doc = documents[i];
                                    var signings = db.DocumentSigningResults.Include(o => o.Side)
                                                                            .Where(o => o.DocumentCancellationMetadataId == doc.Cancellation.Id && !o.IsDeleted);
                                    if (signings.Any(o => o.Side.IsThisSubject(ourEDMSubject)) || doc.Cancellation.Status != DocumentCancellationResult.CancellationRequested)
                                    {
                                        documents.Remove(doc);
                                    }
                                }
                                break;
                        }
                        break;
                    case DocumentStatusType.SigningResult:
                        var signingResultEnum = (DocumentSigningResultType)this.StatusTypeValue;
                        documents = documents.Where(o => o.Signing.Status == signingResultEnum).ToList();
                        break;
                    case DocumentStatusType.CancellationResult:
                        var cancellationResultEnum = (DocumentCancellationResult)this.StatusTypeValue;
                        documents = documents.Where(o => o.Cancellation.Status == cancellationResultEnum).ToList();
                        break;
                    case DocumentStatusType.ApprovalStatus:
                        var approvalEnum = (DocumentApprovalStatus)this.StatusTypeValue;
                        documents = documents.Where(o => o.Approval.Status == approvalEnum).ToList();
                        break;
                    case DocumentStatusType.CancellationApprovalStatus:
                        var cancellationApprovalEnum = (DocumentCancellationApprovalStatus)this.StatusTypeValue;
                        documents = documents.Where(o => o.CancellationApproval.Status == cancellationApprovalEnum).ToList();
                        break;
                }
            }

            return documents;
        }
        public List<Document> FilterByDepartments(List<Document> documents, EDMDbContext db)
        {
            if (this.DepartmentId != null)
            {
                if (this.IncludingSubsidiaryDepartments)
                {
                    var department = db.Departments.Include(o => o.SubDepartments)
                                                   .FirstOrDefault(o => o.Id == this.DepartmentId);


                    var subDepartments = DepartmentsHelper.GetThisAndAllSubDepartments(department, true);
                    DepartmentsHelper.HideSoftDeletedDepartments(subDepartments);

                    for (int i = documents.Count - 1; i >= 0; i--)
                    {
                        var doc = documents[i];

                        bool hasDepartment = false;
                        foreach (var dep in subDepartments)
                        {
                            if (doc.DepartmentsReferences.Any(o => o.Id == dep.Id))
                            {
                                hasDepartment = true;
                                break;
                            }
                        }

                        if (!hasDepartment)
                        {
                            documents.Remove(doc);
                        }
                    }
                }
                else
                {
                    documents = documents.Where(o => o.DepartmentsReferences.Any(o => o.Id == this.DepartmentId)).ToList();
                }
            }

            return documents;
        }
    }
}
