using ElectronicSignature.Certification;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Pkcs;
using System.Security.AccessControl;
using Alfateam.CertGenerators.Models;
using Org.BouncyCastle.Security;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using Alfateam.CertGenerators.Enums;
using System.Text;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Tls;
using System.Globalization;

namespace Alfateam.CertGenerators
{
    public static class AlfateamEDSGenerator
    {
#if DEBUG
        public static X509Certificate2 AlfateamSignerCertificate => "C:\\Users\\User\\Desktop\\alfateamSigner.pfx".GetPrivateCert("AlfaHuiCA12342024");
#else
        public static X509Certificate2 AlfateamSignerCertificate => "/uploads/alfateamSigner.pfx".GetPrivateCert("AlfaHuiCA12342024");
#endif

        public static GenerateCertificateInfo GenerateAlfateamCompanyEDS()
        {
            var organizationParams = new Alfateam.CertGenerators.Models.AlfateamEDSGeneratorOrganizationParams
            {
                Title = "ТОО \"Альфатим ИТ\"",
                CommonName = "Alfateam",
                CountryCode = "KZ",
                LocalityName = "г. Астана",
                Organization = "ТОО \"Альфатим ИТ\"",
                OrganizationIdentifier = "220640023065",
                OrganizationUnitName = "Информационные технологии",
                Password = "AlfaHuiCA12342024",
                PostalAddress = "РК, г. Астана, ул. Акмешит, д.7, кв. 43",
                PostalCode = "010017",
                Role = "Президент",
                StateOrProvinceName = "Акмолинская область",
                Street = "ул. Акмешит, д.7, кв. 43",

                TelephoneNumber = "77057417483",
                DateOfBirth = new DateTime(2002, 9, 8),
                CountryCodeOfCitizenship = "RU",
                CountryOfResidence = "KZ",
                EmailAddress = "eronhiilogch@alfateam.co",
                Gender = Gender.M,
                GivenName = "Александрович",
                Name = "Артур",
                Surname = "Бондарев",
                PlaceOfBirth = "РФ, Воронежская область, г. Борисоглебск",
                UniqueIdentifier = "020908050265"
            };

            var x509name = organizationParams.MakeX509Name();

            var info = GenerateCertificate(x509name, organizationParams.Password, true);
            info.Props = organizationParams;
            return info;
        }




        public static GenerateCertificateInfo GenerateAlfateamEDSForOrganization(AlfateamEDSGeneratorOrganizationParams certInfoProps)
        {
            var x509name = certInfoProps.MakeX509Name();

            var info = GenerateCertificate(x509name, certInfoProps.Password, false);
            info.Props = certInfoProps;
            return info;
        }


        public static GenerateCertificateInfo GenerateAlfateamEDSForPhysical(AlfateamEDSGeneratorPhysicalParams certInfoProps)
        {
            var x509name = certInfoProps.MakeX509Name();

            var info = GenerateCertificate(x509name, certInfoProps.Password, false);
            info.Props = certInfoProps;
            return info;
        }



        public static X509Certificate2 GetCertFromBytes(byte[] certificate, string password)
        {
            return new X509Certificate2(certificate, password, X509KeyStorageFlags.Exportable);
        }

        public static byte[] SignData(string data, byte[] certificate, string password)
        {
            X509Certificate2 pfx = new X509Certificate2(certificate, password, X509KeyStorageFlags.Exportable);
            return Cryptography.SignDataByPrivateKey(data, pfx.GetPrivateKeyFromCert(password));
        }

        public static byte[] SignData(byte[] data, byte[] certificate, string password)
        {
            X509Certificate2 pfx = new X509Certificate2(certificate, password, X509KeyStorageFlags.Exportable);
            return Cryptography.SignDataByPrivateKey(data, pfx.GetPrivateKeyFromCert(password));
        }





        public static bool VerifyAlfateamEDS(string data, byte[] signature, string publicKeyString)
        {
            byte[] publicKeyBytes = Convert.FromBase64String(publicKeyString);
            AsymmetricKeyParameter asymmetricKeyParameter = PublicKeyFactory.CreateKey(publicKeyBytes);

            return Cryptography.VerifySignedByPublicKey(data, signature, asymmetricKeyParameter);
        }


        public static string? GetValueFromX509String(string x509string, string key)
        {
            var propsValuesStrings = x509string.Split(',');
            var dictionary = new Dictionary<string, string>();

            foreach (var prop in propsValuesStrings)
            {
                int indexOfEqualitySign = prop.IndexOf('=');

                var propName = prop.Substring(0, indexOfEqualitySign).Trim();
                var propValue = prop.Substring(indexOfEqualitySign + 1).Trim();

                dictionary[propName] = propValue;
            }

            if (dictionary.ContainsKey(key))
            {
                return dictionary[key];
            }
            return null;
        }




        #region Private methods

        private static GenerateCertificateInfo GenerateCertificate(X509Name x509Name, string password, bool isCA)
        {
            var keyPair = ElectronicSignature.Certification.Cryptography.GenerateRSAKeyPair();
            var CSR = GenerateCSR(x509Name, CryptographyAlgorithm.SHA256withRSA, keyPair);

            X509Certificate2 createdCert;
            if (isCA)
            {
                var x509 = ElectronicSignature.Certification.Cryptography.GenerateSelfSignedCert(CSR, keyPair.Private, DateTime.UtcNow, DateTime.UtcNow.AddYears(100));
                createdCert = new X509Certificate2(x509.GetEncoded(), password);
            }
            else
            {
                var x509 = ElectronicSignature.Certification.Cryptography.GenerateSignedCertificate(CSR, AlfateamSignerCertificate, password, DateTime.UtcNow, DateTime.UtcNow.AddYears(1));
                createdCert = new X509Certificate2(x509.GetEncoded());
            }

            var pfx = CreatePFXCertificate(keyPair, createdCert);
            return new GenerateCertificateInfo
            {
                KeyPair = keyPair,
                PFX = pfx,
                CSR = CSR,
            };
        }

        private static Pkcs10CertificationRequest GenerateCSR(X509Name subject, CryptographyAlgorithm algorithm, AsymmetricCipherKeyPair keyPair)
        {
            string text = algorithm.ToString();
            bool flag = text.IsRsaAlgorithm();
            AsymmetricKeyParameter @private = keyPair.Private;
            if (1 == 0)
            {
            }

            Pkcs10CertificationRequest result;
            if (!(@private is ECPrivateKeyParameters))
            {
                if (!(@private is RsaPrivateCrtKeyParameters) || !flag)
                {
                    goto IL_00d4;
                }

                result = new Pkcs10CertificationRequest(text, subject, keyPair.Public, null, keyPair.Private);
            }
            else
            {
                if (flag)
                {
                    goto IL_00d4;
                }

                result = new Pkcs10CertificationRequest(text, subject, keyPair.Public, null, keyPair.Private);
            }

            if (1 == 0)
            {
            }

            return result;
        IL_00d4:
            throw new Exception("Unknown key pair type");
        }
        private static X509Certificate2 CreatePFXCertificate(AsymmetricCipherKeyPair keyPair, X509Certificate2 selfSigned)
        {
            var bcRsaPrivateKey = (RsaPrivateCrtKeyParameters)keyPair.Private;
            var rsaParameters = DotNetUtilities.ToRSAParameters(bcRsaPrivateKey);
            var rsaKey = RSA.Create(rsaParameters);

            // Assuming you have an X509Certificate2 named certificate
            var exportableCertificate = selfSigned.CopyWithPrivateKey(rsaKey);

            return exportableCertificate;
        }

        #endregion
    }
}
