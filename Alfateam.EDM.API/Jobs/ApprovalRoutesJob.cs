using Alfateam.DB;
using Alfateam.EDM.Models.Abstractions;
using Alfateam.EDM.Models.ApprovalRoutes;
using Alfateam.EDM.Models.ApprovalRoutes.RouteStageExecutors;
using Alfateam.EDM.Models.Enums.DocumentStatuses;
using Alfateam.EDM.Models.General;
using Alfateam.Gateways;
using Alfateam.Gateways.Abstractions;
using Alfateam.Gateways.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.EDM.API.Jobs
{
    public static class ApprovalRoutesJob
    {
        public static async Task Start()
        {
            while (true)
            {

                using (EDMDbContext db = new EDMDbContext())
                {
                    var documents = db.Documents.Include(o => o.Approval).ThenInclude(o => o.ApprovalResults).ThenInclude(o => o.ApprovalRouteStage)
                                                .Include(o => o.Approval).ThenInclude(o => o.ApprovalRouteStage)
                                                .Include(o => o.Signing)
                                                .Where(o => !o.IsDeleted && o.Approval.Status == DocumentApprovalStatus.OnApprovalOrSigningStage);

                    foreach (var document in documents)
                    {
                        if (document.Approval.ApprovalRouteStage != null)
                        {
                            var deadline = document.Approval.ApprovalRouteStage.GetDeadlineDate(document.Approval.LastUpdateDate);
                            if (document.Approval.ApprovalRouteStage.HeedToNotifyAboutDeadline(deadline))
                            {
                                NotifyUsersToEmail(db, document);
                            }
                        }
                    }


                    await Task.Delay(TimeSpan.FromHours(1));
                }
            }

        }

        private static void NotifyUsersToEmail(EDMDbContext db, Document document)
        {
            var executor = db.RouteStageExecutors.FirstOrDefault(o => o.Id == document.Approval.ApprovalRouteStage.Id);
            IEnumerable<User> users = new List<User>();



            if (executor is RouteStageExecutorDepartment departmentExec)
            {
                var departmentUsers = db.Users.Where(o => o.DepartmentId == departmentExec.DepartmentId).ToList();
                var excludingUsers = db.Users.Where(o => o.RouteStageExecutorDepartmentId == departmentExec.Id);

                foreach(var excludingUser in excludingUsers)
                {
                    var depUser = departmentUsers.FirstOrDefault(o => o.Id == excludingUser.Id);
                    if(depUser != null)
                    {
                        departmentUsers.Remove(depUser);
                    }
                }

                users = departmentUsers;
            }
            else if (executor is RouteStageExecutorUsers usersExec)
            {
                users = db.Users.Where(o => o.RouteStageExecutorUsersId == usersExec.Id);               
            }


            using (IDDbContext idDb = new IDDbContext())
            {
                IMailGateway mailGateway = new MailGateway();

                foreach (var user in users)
                {
                    var alfateamUser = idDb.Users.FirstOrDefault(o => o.Guid == user.AlfateamID);
                    mailGateway.SendMail(StaticCredentials.OFFICIAL_EMAIL, new Gateways.Models.Messages.EmailMessage
                    {
                        Subject = "Требуется согласовать документ",
                        ToEmail = alfateamUser.Email,
                        ToDisplayName = alfateamUser.Surname + " " + alfateamUser.Name,
                        Body = $"{document.Title} от {document.DocumentDate.ToString("dd.MM.yyyy")}\r\n" +
                               $"Название компании"
                    });

                    //TODO: Название компании в Требуется согласовать документ
                }
            }

            
        }
    }
}
