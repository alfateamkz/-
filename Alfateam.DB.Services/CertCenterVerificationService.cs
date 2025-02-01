using Alfateam.CertGenerators;
using Alfateam.CertificationCenter.Models;
using Alfateam.CertificationCenter.Models.Enums;
using Alfateam.Core.Exceptions;
using Alfateam.Core.Services;
using Alfateam.DB.Services.Enums;
using Alfateam.Gateways.Abstractions;
using Org.BouncyCastle.Asn1.Pkcs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.DB.Services
{
    public class CertCenterVerificationService
    {
        public readonly CertCenterDbContext DB;
        public readonly AbsDBService DBService;

        public CertCenterVerificationService(CertCenterDbContext db,
                                             AbsDBService dbService)
        {
            DB = db;
            DBService.SetDB(DB);
        }


        //public byte[] SignData(string data, byte[] certificate, string password)
        //{
        //    var pfx = AlfateamEDSGenerator.GetCertFromBytes(certificate, password);
        //    var alfateamEDS = DB.AlfateamEDSs.FirstOrDefault(o => o.EDSSerialNumber == pfx.SerialNumber);

        //    ThrowIfCertNotVaild(alfateamEDS);
        //    return AlfateamEDSGenerator.SignData(data, certificate, password); 
        //}
        
        public AlfateamEDS GetAlfateamEDS(string publicKey)
        {
            var alfateamEDS = DB.AlfateamEDSs.FirstOrDefault(o => o.PublicKey == publicKey);
            ThrowIfCertIsNull(alfateamEDS);

            return alfateamEDS;
        }

        public bool DoesCertificateBelongTo(string publicKey, string subjectCountryCode, string subjectNumber, EDSFor subjectEDSFor)
        {
            var alfateamEDS = DB.AlfateamEDSs.FirstOrDefault(o => o.PublicKey == publicKey);
            ThrowIfCertIsNull(alfateamEDS);

            if(subjectEDSFor == EDSFor.Individual)
            {
                var documentCountryCode = AlfateamEDSGenerator.GetValueFromX509String(alfateamEDS.OwnerStringInfo, "OID.1.3.6.1.5.5.7.9.5"); //CountryOfResidence
                var idNumber = AlfateamEDSGenerator.GetValueFromX509String(alfateamEDS.OwnerStringInfo, "OID.2.5.4.45"); //UniqueIdentifier (серия и номер паспорта или аналог)

                return subjectCountryCode == documentCountryCode && subjectNumber == idNumber;
            }
            else if(subjectEDSFor == EDSFor.Business)
            {
                var companyCountryCode = AlfateamEDSGenerator.GetValueFromX509String(alfateamEDS.OwnerStringInfo, "C"); //CountryCode
                var organizationNumber = AlfateamEDSGenerator.GetValueFromX509String(alfateamEDS.OwnerStringInfo, "OID.2.5.4.97"); //OrganizationIdentifier (ИНН или аналог)

                return subjectCountryCode == companyCountryCode && subjectNumber == organizationNumber;
            }

            return false;
        }

        public string BuildSigningAppDeeplinkURL(SigningAppDeeplinkURLParamType paramType, string value, string returnParameter)
        {
            return $"alfakey://paramType={(int)paramType}&value={value}&returnParameter={returnParameter}";
        }

        public bool VerifyCert(string data, byte[] signature, string publicKey)
        {
            var alfateamEDS = DB.AlfateamEDSs.FirstOrDefault(o => o.PublicKey == publicKey);

            ThrowIfCertNotVaild(alfateamEDS);
            return AlfateamEDSGenerator.VerifyAlfateamEDS(data, signature, publicKey);
        }




        private void ThrowIfCertNotVaild(AlfateamEDS alfateamEDS)
        {
            ThrowIfCertIsNull(alfateamEDS);
            if (alfateamEDS.IsRevoked)
            {
                throw new Exception403("Сертификат был отозван, подписание невозможно");
            }
            else if (!alfateamEDS.IsActive)
            {
                throw new Exception403("Сертификат просрочен либо еще не наступила дата начала действия сертификата, подписание невозможно");
            }
        }

        private void ThrowIfCertIsNull(AlfateamEDS alfateamEDS)
        {
            if (alfateamEDS == null)
            {
                throw new Exception404("Сертификат с данным ключом не найден");
            }
        }
    }

}
