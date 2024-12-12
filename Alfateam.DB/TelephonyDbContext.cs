using Alfateam.Telephony.Models.General;
using Alfateam.Telephony.Models.Abstractions;
using Alfateam.Telephony.Models.Abstractions.VoiceMenu;
using Alfateam.Telephony.Models.ATE;
using Alfateam.Telephony.Models.Calls;
using Alfateam.Telephony.Models.Calls.Transcriptions;
using Alfateam.Telephony.Models.Contacts;
using Alfateam.Telephony.Models.ExternalInteractions.Items.Callback;
using Alfateam.Telephony.Models.ExternalInteractions.Items.Callback.UICustomization;
using Alfateam.Telephony.Models.ExternalInteractions.Items.Callback.UICustomization.Texts;
using Alfateam.Telephony.Models.ExternalInteractions.Items.Callback.VisitedPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alfateam.Telephony.Models.General.WorkingDays;
using Alfateam.Telephony.Models.General.Security;
using Alfateam.Telephony.Models.General.AudioRecords.Internal;
using Alfateam.Telephony.Models.HLR;
using Alfateam.Telephony.Models.HLR.Results;
using Alfateam.Telephony.Models.Integrations.API;
using Alfateam.Telephony.Models;

namespace Alfateam.DB
{
    public class TelephonyDbContext : DbContext
    {
        public TelephonyDbContext()
        {
            Database.EnsureCreated();
        }
        public TelephonyDbContext(DbContextOptions<TelephonyDbContext> options)
        {
            Database.EnsureCreated();
        }

        #region Abstractions

        #region VoiceMenu

        public DbSet<VoiceMenuItem> VoiceMenuItems { get; set; }

        #endregion

        public DbSet<AudioRecord> AudioRecords { get; set; }
        public DbSet<BaseSMS> BaseSMSs { get; set; }
        public DbSet<ExtInteraction> ExtInteractions { get; set; }
        public DbSet<ExtLine> ExtLines { get; set; }
        public DbSet<TelephonyNumber> TelephonyNumbers { get; set; }

        #endregion

        #region ATE
        public DbSet<ATEItem> ATEItems { get; set; }

        #endregion

        #region Calls

        #region Transcriptions
        public DbSet<CallTranscription> CallTranscriptions { get; set; }
        public DbSet<CallTranscriptionCompanion> CallTranscriptionCompanions { get; set; }
        public DbSet<CallTranscriptionText> CallTranscriptionTexts { get; set; }

        #endregion

        public DbSet<Call> Calls { get; set; }
        public DbSet<CallRecord> CallRecords { get; set; }

        #endregion

        #region Contacts
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactCategory> ContactCategories { get; set; }

        #endregion

        #region ExternalInteractions

        #region Callback

        #region UICustomization

        #region Texts

        public DbSet<CallbackUICustomizationTextsDelayedCall> CallbackUICustomizationTextsDelayedCalls { get; set; }
        public DbSet<CallbackUICustomizationTextsLeavingSite> CallbackUICustomizationTextsLeavingSites { get; set; }
        public DbSet<CallbackUICustomizationTextsNotWorkingTime> CallbackUICustomizationTextsNotWorkingTimes { get; set; }
        public DbSet<CallbackUICustomizationTextsWorkingTime> CallbackUICustomizationTextsWorkingTimes { get; set; }

        #endregion

        public DbSet<CallbackUICustomizationGeneral> CallbackUICustomizationGenerals { get; set; }
        public DbSet<CallbackUICustomizationPrivacy> CallbackUICustomizationPrivacies { get; set; }
        public DbSet<CallbackUICustomizationTexts> CallbackUICustomizationTexts { get; set; }

        #endregion

        #region VisitedPages
        public DbSet<CallbackClientsScoringVisitedPage> CallbackClientsScoringVisitedPageItems { get; set; }
        public DbSet<CallbackClientsScoringVisitedPages> CallbackClientsScoringVisitedPages { get; set; }

        #endregion

        public DbSet<CallbackClientsScoringCriterias> CallbackClientsScoringCriterias { get; set; }
        public DbSet<CallbackCountriesFilter> CallbackCountriesFilters { get; set; }
        public DbSet<CallbackExtInteractionBannedIP> CallbackExtInteractionBannedIPs { get; set; }
        public DbSet<CallbackNumbersFilter> CallbackNumbersFilters { get; set; }
        public DbSet<CallbackUICustomization> CallbackUICustomizations { get; set; }

        #endregion

        #endregion

        #region General

        #region AudioRecords

        #region Internal
        public DbSet<ReadingVoice> ReadingVoices { get; set; }

        #endregion

        #endregion

        #region Security
        public DbSet<HistoryAction> HistoryActions { get; set; }
        public DbSet<UserPermissions> UserPermissions { get; set; }

        #endregion

        #region WorkingDays
        public DbSet<WorkingDay> WorkingDays { get; set; }
        public DbSet<WorkingDaysModel> WorkingDaysModels { get; set; }

        #endregion 

        public DbSet<Business> Businesses { get; set; }
        public DbSet<BusinessCompany> BusinessCompanies { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<SubscriptionInfo> SubscriptionInfo { get; set; }
        public DbSet<User> Users { get; set; }

        #endregion

        #region HLR

        #region Results

        public DbSet<HLRTaskIterationResult> HLRTaskIterationResults { get; set; }
        public DbSet<HLRTaskIterationResultNumber> HLRTaskIterationResultNumbers { get; set; }

        #endregion

        public DbSet<HLRTask> HLRTasks { get; set; }
        public DbSet<HLRTaskIteration> HLRTaskIterations { get; set; }

        #endregion

        #region Integrations

        #region API

        public DbSet<AlfateamAPIKey> AlfateamAPIKeys { get; set; }
        public DbSet<AlfateamAPIRequestEntry> AlfateamAPIRequestEntries { get; set; }

        #endregion

        #endregion

        public DbSet<ModerationForbiddenPhrase> ModerationForbiddenPhrases { get; set; }
    }
}
