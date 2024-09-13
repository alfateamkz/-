using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Abstractions.Communication.Messenger;
using Alfateam.CRM2_0.Models.Abstractions.Communication.Omnichannel;
using Alfateam.CRM2_0.Models.Abstractions.Content.Education.Courses;
using Alfateam.CRM2_0.Models.Abstractions.Content.Tests;
using Alfateam.CRM2_0.Models.Abstractions.Gamification;
using Alfateam.CRM2_0.Models.Abstractions.Roles.Accountance;
using Alfateam.CRM2_0.Models.Abstractions.Roles.Accountance.Transactions;
using Alfateam.CRM2_0.Models.Abstractions.Roles.Compliance;
using Alfateam.CRM2_0.Models.Abstractions.Roles.Financier;
using Alfateam.CRM2_0.Models.Abstractions.Roles.HR;
using Alfateam.CRM2_0.Models.Abstractions.Roles.Lawyer;
using Alfateam.CRM2_0.Models.Abstractions.Roles.Marketing;
using Alfateam.CRM2_0.Models.Abstractions.Roles.Sales;
using Alfateam.CRM2_0.Models.Abstractions.Roles.SecurityService;
using Alfateam.CRM2_0.Models.Abstractions.Roles.Staff;
using Alfateam.CRM2_0.Models.Communication.Messenger;
using Alfateam.CRM2_0.Models.Content.Education.Courses;
using Alfateam.CRM2_0.Models.Content.Events;
using Alfateam.CRM2_0.Models.Content.Feedback;
using Alfateam.CRM2_0.Models.Content.Posts;
using Alfateam.CRM2_0.Models.Content.Tests;
using Alfateam.CRM2_0.Models.Content.Videos;
using Alfateam.CRM2_0.Models.Departments;
using Alfateam.CRM2_0.Models.Gamification;
using Alfateam.CRM2_0.Models.Gamification.Achievements;
using Alfateam.CRM2_0.Models.Gamification.Contests;
using Alfateam.CRM2_0.Models.Gamification.Data;
using Alfateam.CRM2_0.Models.Gamification.General;
using Alfateam.CRM2_0.Models.Gamification.Shop;
using Alfateam.CRM2_0.Models.Gamification.Shop.Order;
using Alfateam.CRM2_0.Models.General;
using Alfateam.CRM2_0.Models.General.Assessment.Risks;
using Alfateam.CRM2_0.Models.General.Info;
using Alfateam.CRM2_0.Models.General.Services;
using Alfateam.CRM2_0.Models.General.Verification;
using Alfateam.CRM2_0.Models.Other.StopList;
using Alfateam.CRM2_0.Models.Roles.Accountance;
using Alfateam.CRM2_0.Models.Roles.Accountance.Loans;
using Alfateam.CRM2_0.Models.Roles.Compliance;
using Alfateam.CRM2_0.Models.Roles.Compliance.Appeals;
using Alfateam.CRM2_0.Models.Roles.Compliance.Conflicts;
using Alfateam.CRM2_0.Models.Roles.Compliance.Conflicts.Resolutions;
using Alfateam.CRM2_0.Models.Roles.Compliance.Corruption;
using Alfateam.CRM2_0.Models.Roles.Compliance.Fraud;
using Alfateam.CRM2_0.Models.Roles.Compliance.Law;
using Alfateam.CRM2_0.Models.Roles.Financier;
using Alfateam.CRM2_0.Models.Roles.Financier.Investments;
using Alfateam.CRM2_0.Models.Roles.Financier.Planning;
using Alfateam.CRM2_0.Models.Roles.Financier.Pricing;
using Alfateam.CRM2_0.Models.Roles.HR;
using Alfateam.CRM2_0.Models.Roles.HR.JobVacancies;
using Alfateam.CRM2_0.Models.Roles.HR.Manuals;
using Alfateam.CRM2_0.Models.Roles.HR.Questionnaires;
using Alfateam.CRM2_0.Models.Roles.HR.TestTasks;
using Alfateam.CRM2_0.Models.Roles.Lawyer;
using Alfateam.CRM2_0.Models.Roles.Lawyer.Documents;
using Alfateam.CRM2_0.Models.Roles.Lawyer.LegalCases;
using Alfateam.CRM2_0.Models.Roles.Lawyer.Trial;
using Alfateam.CRM2_0.Models.Roles.Marketing;
using Alfateam.CRM2_0.Models.Roles.Marketing.Referral;
using Alfateam.CRM2_0.Models.Roles.Sales;
using Alfateam.CRM2_0.Models.Roles.Sales.Conversation;
using Alfateam.CRM2_0.Models.Roles.Sales.Franchising;
using Alfateam.CRM2_0.Models.Roles.Sales.Funnel;
using Alfateam.CRM2_0.Models.Roles.Sales.Orders;
using Alfateam.CRM2_0.Models.Roles.Sales.Orders.Milestones;
using Alfateam.CRM2_0.Models.Roles.Sales.Plan;
using Alfateam.CRM2_0.Models.Roles.Sales.Scripting;
using Alfateam.CRM2_0.Models.Roles.SecurityService.Checking;
using Alfateam.CRM2_0.Models.Roles.SecurityService.Checking.Data;
using Alfateam.CRM2_0.Models.Roles.SecurityService.Checking.Scoring;
using Alfateam.CRM2_0.Models.Roles.SecurityService.Scoring;
using Alfateam.CRM2_0.Models.Roles.Staff;
using Alfateam.CRM2_0.Models.Roles.Staff.Counterparties;
using Alfateam.CRM2_0.Models.Roles.Staff.Employess;
using Alfateam.CRM2_0.Models.Security;
using Alfateam.DB.Helpers;
using Alfateam.DB.Methods.CRMDBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Alfateam.DB
{
    public class CRMDBContext : DbContext
    {
        public CRMDBContext()
        {
            InitDBMethods();
            if (Database.EnsureCreated())
            {

            }
        }
        public CRMDBContext(DbContextOptions<CRMDBContext> options) : this()
        {

        }




        #region Abstractions

        #region Communication

        #region Messenger
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
        #endregion

        #region Omnichannel
        public DbSet<OmnichannelAccount> OmnichannelAccounts { get; set; }
        #endregion

        #endregion

        #region Content


        #region Education

        #region Courses
        public DbSet<CourseLessonBlock> CourseLessonBlocks { get; set; }
        #endregion

        #endregion

        #region Tests
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionOption> QuestionOptions { get; set; }
        #endregion

        #endregion

        #region Gamification
        public DbSet<GamificationEvent> GamificationEvents { get; set; }
  
        #endregion

        #region Roles

        #region Accountance

        #region Transactions
        public DbSet<Transaction> Transactions { get; set; }
        #endregion
        public DbSet<LoanObligationPledge> LoanObligationPledges { get; set; }

        #endregion

        #region Compliance
        public DbSet<CorruptionCaseParticipant> CorruptionCaseParticipants { get; set; }
        #endregion

        #region Financier
        public DbSet<InvestmentCondition> InvestmentConditions { get; set; }

        #endregion

        #region HR
        public DbSet<HRQuestionaireQuestion> HRQuestionaireQuestions { get; set; }

        #endregion

        #region Lawyer
        public DbSet<Litigation> Litigations { get; set; }
        public DbSet<TrialProcessParticipant> TrialProcessParticipants { get; set; }

        #endregion

        #region Marketing
        public DbSet<BaseAdCampaignItemTask> BaseAdCampaignItemTasks { get; set; }
        public DbSet<BaseReferralProgram> BaseReferralPrograms { get; set; }

        #endregion

        #region Sales
        public DbSet<Franchise> Franchises { get; set; }
        public DbSet<FranchiseSaleConditions> FranchiseSaleConditions { get; set; }
        public DbSet<RoyaltyFranchiseSaleConditions> RoyaltyFranchiseSaleConditions { get; set; }

        #endregion

        #region SecurityService
        public DbSet<ScoringQuestion> ScoringQuestions { get; set; }

        #endregion

        #region Staff
        public DbSet<CounterpartySubparty> CounterpartySubparties { get; set; }

        #endregion

        #endregion

        public DbSet<DepartmentsGrouping> DepartmentsGroupings { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<TaxSystem> TaxSystems { get; set; }

        #endregion

        #region Communication

        #region Messenger

        public DbSet<ChatMessageAttachment> ChatMessageAttachments { get; set; }
        public DbSet<GroupChatUserInfo> GroupChatUserInfos { get; set; }

        #endregion


        #endregion

        #region Content

        #region Education

        #region Courses
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseBlock> CourseBlocks { get; set; }
        public DbSet<CourseCategory> CourseCategories { get; set; }
        public DbSet<CourseLesson> CourseLessons { get; set; }
        public DbSet<CourseLessonPart> CourseLessonParts { get; set; }

        #endregion

        #endregion

        #region Events
        public DbSet<Event> Events { get; set; }
        public DbSet<EventCategory> EventCategories { get; set; }
        public DbSet<EventFormat> EventFormats { get; set; }

        #endregion

        #region Feedback
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentAttachment> CommentAttachments { get; set; }
        public DbSet<FeedbackEntry> FeedbackEntries { get; set; }
        #endregion

        #region Posts
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        #endregion

        #region Tests
        public DbSet<QuestionOptionScaleInfo> QuestionOptionScaleInfos { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<TestCategory> TestCategories { get; set; }
        public DbSet<TestResult> TestResults { get; set; }
        public DbSet<TestScale> TestScales { get; set; }

        #endregion

        #region Videos
        public DbSet<Video> Videos { get; set; }
        public DbSet<VideoCategory> VideoCategories { get; set; }
        #endregion

        #endregion

        #region Gamification

        #region Achievements
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<AchievementCategory> AchievementCategories { get; set; }

        #endregion

        #region Contests

        public DbSet<Contest> Contests { get; set; }
        public DbSet<ContestPlaces> ContestPlaces { get; set; }
        public DbSet<ContestPrize> ContestPrizes { get; set; }
        public DbSet<ContestResult> ContestResults { get; set; }
        public DbSet<ContestWinner> ContestWinners { get; set; }

        #endregion

        #region Data
        public DbSet<GamificationUserAchievement> GamificationUserAchievements { get; set; }
        public DbSet<GamificationUserData> GamificationUserDatas { get; set; }
        public DbSet<UserLevelCriteriaInfo> UserLevelCriteriaInfos { get; set; }
        public DbSet<UserLevelInfo> UserLevelInfos { get; set; }
        #endregion

        #region General
        public DbSet<Level> Levels { get; set; }
        public DbSet<LevelCriteria> LevelCriterias { get; set; }
        public DbSet<LevelReward> LevelRewards { get; set; }
        #endregion

        #region Shop

        #region Orders
        public DbSet<ShopOrder> ShopOrders { get; set; }
        public DbSet<ShopOrderItem> ShopOrderItems { get; set; }
        #endregion
        public DbSet<ShopCategory> ShopCategories { get; set; }
        public DbSet<ShopItem> ShopItems { get; set; }
        #endregion

        public DbSet<GamificationFine> GamificationFines { get; set; }
        public DbSet<GamificationModel> GamificationModels { get; set; }
        public DbSet<GamificationUser> GamificationUsers { get; set; }
        public DbSet<GamificationUserTask> GamificationUserTasks { get; set; }
        #endregion

        #region General

        #region Assessment

        #region Risks
        public DbSet<Risk> Risks { get; set; }
        public DbSet<RiskAssessment> RiskAssessments { get; set; }
        public DbSet<RiskConsequence> RiskConsequences { get; set; }
        public DbSet<RiskConsequenceAction> RiskConsequenceActions { get; set; }
        public DbSet<RiskManagementAction> RiskManagementActions { get; set; }
        public DbSet<RisksGroup> RisksGroups { get; set; }
        public DbSet<RisksModel> RisksModels { get; set; }
        #endregion

        #endregion

        #region Info
        public DbSet<SocialNetworksInfo> SocialNetworksInfos { get; set; }
        public DbSet<TransportProperty> TransportProperties { get; set; }

        #endregion

        #region Services
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceCategory> ServiceCategories { get; set; }

        #endregion

        #region Verification
        public DbSet<VerificationCode> VerificationCodes { get; set; }
        #endregion

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Availability> Availabilities { get; set; }
        public DbSet<Business> Businesses { get; set; }
        public DbSet<BusinessContent> BusinessContents { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Cost> Costs { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<CourtStructure> CourtStructures { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<DeadlineFailedReason> DeadlineFailedReasons { get; set; }
        public DbSet<EDMProvider> EDMProviders { get; set; }
        public DbSet<Encouragement> Encouragements { get; set; }
        public DbSet<Fine> Fines { get; set; }
        public DbSet<LegalForm> LegalForms { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<OrganizationOffice> OrganizationOffices { get; set; }
        public DbSet<OrganizationOfficeStaff> OrganizationOfficeStaffs { get; set; }
        public DbSet<Penalty> Penalties { get; set; }
        public DbSet<PricingItem> PricingItems { get; set; }
        public DbSet<RealEstate> RealEstates { get; set; }
        public DbSet<Thing> Things { get; set; }
        public DbSet<CRM2_0.Models.General.TimeZone> TimeZones { get; set; }
        public DbSet<Transport> Transports { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserGivenRole> UserGivenRoles { get; set; }
        public DbSet<UserRoleModel> UserRoleModels { get; set; }
        public DbSet<WorkingTeam> WorkingTeams { get; set; }
        #endregion

        #region Other

        #region StopList
        public DbSet<StopListItem> StopListItems { get; set; }
        #endregion


        #endregion

        #region Roles

        #region Accountance

        #region Loans
        public DbSet<LoanObligation> LoanObligations { get; set; }
        #endregion

        public DbSet<Account> Accounts { get; set; }
        public DbSet<TransactionChanges> TransactionChanges { get; set; }
        #endregion

        #region Compliance

        #region Appeals
        public DbSet<Appeal> Appeals { get; set; }
        public DbSet<AppealAction> AppealActions { get; set; }
        public DbSet<AppealResult> AppealResults { get; set; }
        public DbSet<AppealResultAction> AppealResultActions { get; set; }
        #endregion

        #region Conflicts

        #region Resolutions
        public DbSet<ConflictResolutionAlgorithm> ConflictResolutionAlgorithms { get; set; }
        public DbSet<ConflictResolutionAlgorithmBlock> ConflictResolutionAlgorithmBlocks { get; set; }

        #endregion


        public DbSet<Conflict> Conflicts { get; set; }
        public DbSet<ConflictParticipant> ConflictParticipants { get; set; }
        public DbSet<ConflictResolutionProposal> ConflictResolutionProposals { get; set; }
        public DbSet<ConflictResolutionProposalFeedback> ConflictResolutionProposalFeedbacks { get; set; }
        public DbSet<ConflictResult> ConflictResults { get; set; }
        public DbSet<ConflictResultAction> ConflictResultActions { get; set; }
        public DbSet<ConflictSide> ConflictSides { get; set; }

        #endregion

        #region Corruption
        public DbSet<CorruptionCase> CorruptionCases { get; set; }
        public DbSet<CorruptionCaseAction> CorruptionCaseActions { get; set; }
        public DbSet<CorruptionCaseInitDetails> CorruptionCaseInitDetails { get; set; }
        public DbSet<CorruptionCaseResult> CorruptionCaseResults { get; set; }
        public DbSet<CorruptionCaseSide> CorruptionCaseSides { get; set; }
		#endregion

		#region Fraud
		public DbSet<FraudCategory> FraudCategories { get; set; }
		public DbSet<FraudDescription> FraudDescriptions { get; set; }
        public DbSet<FraudPreventionMethod> FraudPreventionMethods { get; set; }

        #endregion

        #region Law
        public DbSet<ProhibitedService> ProhibitedServices { get; set; }

        #endregion

        public DbSet<ComplianceCriteria> ComplianceCriterias { get; set; }
        public DbSet<ComplianceCriteriaGroup> ComplianceCriteriaGroups { get; set; }
        public DbSet<ComplianceRequirements> ComplianceRequirements { get; set; }
        public DbSet<ComplianceRequirementsCategory> ComplianceRequirementsCategories { get; set; }
        #endregion

        #region Financier

        #region Investments
        public DbSet<Investment> Investments { get; set; }
        public DbSet<InvestmentEarlyWithdrawalCondition> InvestmentEarlyWithdrawalConditions { get; set; }
        public DbSet<InvestmentTerm> InvestmentTerms { get; set; }
        public DbSet<InvestProject> InvestProjects { get; set; }
        public DbSet<InvestProjectAttachment> InvestProjectAttachments { get; set; }
        public DbSet<InvestProjectDeposit> InvestProjectDeposits { get; set; }
        #endregion

        #region Planning
        public DbSet<FinanicialPlan> FinanicialPlans { get; set; }
        public DbSet<FinanicialPlanItem> FinanicialPlanItems { get; set; }
        public DbSet<FinanicialPlanItemCell> FinanicialPlanItemCells { get; set; }
        public DbSet<FinanicialPlanItemsGroup> FinanicialPlanItemsGroups { get; set; }
        #endregion

        #region Planning
        public DbSet<PricingModel> PricingModels { get; set; }
        public DbSet<PricingService> PricingServices { get; set; }
        #endregion
        public DbSet<Foundation> Foundations { get; set; }

        #endregion

        #region HR

        #region JobVacancies
        public DbSet<JobVacancy> JobVacancies { get; set; }
        public DbSet<JobVacancyExpierence> JobVacancyExpierences { get; set; }

        #endregion

        #region Manuals
        public DbSet<HRManual> HRManuals { get; set; }
        public DbSet<HRManualCategory> HRManualCategories { get; set; }

        #endregion

        #region Questionnaires
        public DbSet<HRQuestionaireQuestionGroup> HRQuestionaireQuestionGroups { get; set; }
        public DbSet<HRQuestionaireQuestionOption> HRQuestionaireQuestionOptions { get; set; }
        public DbSet<HRQuestionnaire> HRQuestionnaires { get; set; }
        public DbSet<HRQuestionnaireCategory> HRQuestionnaireCategories { get; set; }
        #endregion

        #region TestTasks
        public DbSet<CandidateTestTask> CandidateTestTasks { get; set; }
        public DbSet<CandidateTestTaskAnswer> CandidateTestTaskAnswers { get; set; }
        public DbSet<CandidateTestTaskAnswerAttachment> CandidateTestTaskAnswerAttachments { get; set; }
        #endregion

        public DbSet<CandidateCall> CandidateCalls { get; set; }
        public DbSet<CandidateCallRescheduling> CandidateCallReschedulings { get; set; }
        public DbSet<CandidateInterview> CandidateInterviews { get; set; }
        public DbSet<CandidateInterviewDecision> CandidateInterviewDecisions { get; set; }
        #endregion

        #region Lawyer

        #region Documents
        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentVersion> DocumentVersions { get; set; }
        public DbSet<SignedDocument> SignedDocuments { get; set; }
        #endregion

        #region LegalCases
        public DbSet<LegalCase> LegalCases { get; set; }
        public DbSet<LegalCaseRequest> LegalCaseRequests { get; set; }
        public DbSet<LegalCaseRequestResult> LegalCaseRequestResults { get; set; }
        public DbSet<LegalCaseResult> LegalCaseResults { get; set; }
		#endregion

		#region Trial
		public DbSet<Court> Courts { get; set; }
		public DbSet<Judge> Judges { get; set; }
        public DbSet<TrialHearing> TrialHearings { get; set; }
        public DbSet<TrialHearingResult> TrialHearingResults { get; set; }
        public DbSet<TrialProcessResult> TrialProcessResults { get; set; }
        public DbSet<TrialProcessSide> TrialProcessSides { get; set; }
        public DbSet<TrialRequest> TrialRequests { get; set; }
        public DbSet<TrialRequestResult> TrialRequestResult { get; set; }
        #endregion

        public DbSet<LawyerTask> LawyerTask { get; set; }

        #endregion

        #region Management

        #region Kanban
        //TODO: канбан

        #endregion


        #endregion

        #region Marketing

        #region Referral

        public DbSet<MultiLevelReferralProgramLevel> MultiLevelReferralProgramLevels { get; set; }
        public DbSet<Referral> Referrals { get; set; }

        #endregion

        public DbSet<AdCampaign> AdCampaigns { get; set; }
        public DbSet<AdCampaignBudgetItem> AdCampaignBudgetItems { get; set; }
        public DbSet<AdCampaignItem> AdCampaignItems { get; set; }
        public DbSet<AdCampaignItemReport> AdCampaignItemReports { get; set; }
		public DbSet<AdCampaignItemTaskCheckRequest> AdCampaignItemTaskCheckRequests { get; set; }
		public DbSet<AdCampaignItemTaskCheckRequestResult> AdCampaignItemTaskCheckRequestResults { get; set; }
		#endregion

		#region Sales

		#region Conversations
		//TODO: подумать над рефакторингом
		public DbSet<CustomerCall> CustomerCalls { get; set; }
        public DbSet<CustomerConference> CustomerConferences { get; set; }
        public DbSet<CustomerMeeting> CustomerMeetings { get; set; }
        public DbSet<CustomerMeetingAttachment> CustomerMeetingAttachments { get; set; }
        #endregion

        #region Franchising
        public DbSet<FranchisePricing> FranchisePricings { get; set; }
        public DbSet<FranchiseRoyaltyScheme> FranchiseRoyaltySchemes { get; set; }
        public DbSet<FranchiseRoyaltySchemeItem> FranchiseRoyaltySchemeItems { get; set; }
        public DbSet<FranchiseSale> FranchiseSales { get; set; }
        public DbSet<FranchiseSaleConditionsGroup> FranchiseSaleConditionsGroups { get; set; }

        #endregion

        #region Funnel
        public DbSet<SalesFunnel> SalesFunnels { get; set; }
        public DbSet<SalesFunnelStage> SalesFunnelStages { get; set; }
        #endregion

        #region Orders

        #region Milestones
        public DbSet<OrderMilestone> OrderMilestones { get; set; }
        public DbSet<OrderMilestoneBudgetItem> OrderMilestoneBudgetItems { get; set; }
        public DbSet<OrderMilestoneDeadlineInfo> OrderMilestoneDeadlineInfos { get; set; }
        public DbSet<OrderMilestoneReport> OrderMilestoneReports { get; set; }
        public DbSet<OrderMilestoneReportItem> OrderMilestoneReportItems { get; set; }
        public DbSet<OrderMilestoneReportItemAttachment> OrderMilestoneReportItemAttachments { get; set; }
        #endregion


        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderSaleInfo> OrderSaleInfos { get; set; }
        public DbSet<OrderTask> OrderTasks { get; set; }
        #endregion

        #region Plan
        public DbSet<SalesPlan> SalesPlans { get; set; }
        public DbSet<SalesPlanItem> SalesPlanItems { get; set; }
        public DbSet<SalesPlanning> SalesPlannings { get; set; }
        #endregion

        #region Scripting
        public DbSet<SalesScript> SalesScripts { get; set; }
        public DbSet<SalesScriptBlock> SalesScriptBlocks { get; set; }
        #endregion

        public DbSet<SalesKPI> SalesKPIs { get; set; }

        #endregion

        #region SecurityService 

        #region Checking

        #region Data
        public DbSet<SSCheckingData> SSCheckingDatas { get; set; }
        public DbSet<SSCheckingDataAttachment> SSCheckingDataAttachments { get; set; }
        #endregion

        #region Scoring

        public DbSet<SSCheckingScoringResult> SSCheckingScoringResults { get; set; }
        public DbSet<SSCheckingScoringResultAnswer> SSCheckingScoringResultAnswers { get; set; }
        public DbSet<SSCheckingScoringResultQAvailableOption> SSCheckingScoringResultQAvailableOptions { get; set; }
        public DbSet<SSCheckingScoringResultQGroup> SSCheckingScoringResultQGroups { get; set; }
        public DbSet<SSCheckingScoringResultQuestion> SSCheckingScoringResultQuestions { get; set; }

        #endregion

        public DbSet<SSChecking> SSCheckings { get; set; }
        public DbSet<SSCheckingRequest> SSCheckingRequests { get; set; }
        public DbSet<SSCheckingRequestResult> SSCheckingRequestResults { get; set; }
        public DbSet<SSCheckingResult> SSCheckingResults { get; set; }
        public DbSet<SSCheckingVerificationInfo> SSCheckingVerificationInfos { get; set; }
        #endregion

        #region Scoring
        public DbSet<ScoringModel> ScoringModels { get; set; }
        public DbSet<ScoringModelCategory> ScoringModelCategories { get; set; }
        public DbSet<ScoringQuestionGroup> ScoringQuestionGroups { get; set; }
        public DbSet<ScoringQuestionOption> ScoringQuestionOptions { get; set; }
        #endregion

        #endregion

        #region Staff

        #region Counterparties
        public DbSet<CounterpartyPaymentScheme> CounterpartyPaymentSchemes { get; set; }
        public DbSet<CounterpartyWorkingDayInfo> CounterpartyWorkingDayInfos { get; set; }

        #endregion

        #region Employess
        public DbSet<EmployeeVacation> EmployeeVacations { get; set; }
        public DbSet<EmployeeWorkingDayInfo> EmployeeWorkingDayInfos { get; set; }
        public DbSet<EmployeeWorkingDaySkipReason> EmployeeWorkingDaySkipReasons { get; set; }
        #endregion

        public DbSet<Probation> Probations { get; set; }
        public DbSet<WorkerDocument> WorkerDocuments { get; set; }
        public DbSet<WorkerNotificationSettings> WorkerNotificationSettingss { get; set; }
        #endregion

        #endregion

        #region Security
        public DbSet<UsedCredential> UsedCredentials { get; set; }
        public DbSet<Session> Sessions { get; set; }
        #endregion




        #region Методы для работы с БД

        public DepartmentsMethods DepartmentsMethods { get; private set; }

        #endregion

        #region Initial methods

        private void InitDBMethods()
        {
            DepartmentsMethods = new DepartmentsMethods(this);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(ConnectionStrings.CRM, new MySqlServerVersion(new Version(8, 0, 11)));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
       
        }

        #endregion
    }
}
