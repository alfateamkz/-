﻿using Alfateam.Core.Services;
using Alfateam.DB;
using Alfateam.DB.Services;
using Alfateam.DB.ServicesDBs;
using Alfateam.Gateways.Abstractions;

namespace Alfateam.AdminPanelGeneral.API.Models
{
    public class ControllerParams
    {
        public ControllerParams(IDDbContext iddb,
                               AdmininstrationDbContext admininstrationDb,
                               CertCenterDbContext certCenterDb,

                               SalesDbContext salesDb,
                               MarketingDbContext marketingDb,
                               TelephonyDbContext telephonyDb,
                               MessengerDbContext messengerDb,
                               EDMDbContext edmDb,

                               AbsDBService dBService,
                               AbsFilesService filesService,
                               UploadedFilesService uploadedFilesService,
                               IWebHostEnvironment appEnv,
                               IMailGateway mailGateway,
                               ISMSGateway smsGateway)
        {
            IdDb = iddb;
            AdmininstrationDb = admininstrationDb;
            CertCenterDb = certCenterDb;

            SalesDb = salesDb;
            MarketingDb = marketingDb;
            TelephonyDb = telephonyDb;
            MessengerDb = messengerDb;
            EDMDb = edmDb;

            DBService = dBService;
            FilesService = filesService;
            UploadedFilesService = uploadedFilesService;
            AppEnvironment = appEnv;
            MailGateway = mailGateway;
            SMSGateway = smsGateway;
        }


        public IDDbContext IdDb { get; set; }
        public AdmininstrationDbContext AdmininstrationDb { get; set; }
        public CertCenterDbContext CertCenterDb { get; set; }



        public SalesDbContext SalesDb { get; set; }
        public MarketingDbContext MarketingDb { get; set; }
        public TelephonyDbContext TelephonyDb { get; set; }
        public MessengerDbContext MessengerDb { get; set; }
        public EDMDbContext EDMDb { get; set; }





        public AbsDBService DBService { get; set; }
        public AbsFilesService FilesService { get; set; }
        public UploadedFilesService UploadedFilesService { get; set; }
        public IWebHostEnvironment AppEnvironment { get; set; }
        public IMailGateway MailGateway { get; set; }
        public ISMSGateway SMSGateway { get; set; }
    }
}
