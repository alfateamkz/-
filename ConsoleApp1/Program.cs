using Alfateam.CertGenerators;
using Alfateam.CertGenerators.Enums;
using ElectronicSignature.Certification;
using Org.BouncyCastle.Asn1.Crmf;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;
using System.Security.Cryptography.X509Certificates;



namespace ConsoleApp1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //var alfateamCertInfo = AlfateamEDSGenerator.GenerateAlfateamCompanyEDS();
            //File.WriteAllBytes("C:\\Users\\User\\Desktop\\alfateamSigner.pfx", alfateamCertInfo.PFX.Export(X509ContentType.Pfx, alfateamCertInfo.Props.Password));



            var certInfo = AlfateamEDSGenerator.GenerateAlfateamEDSForOrganization(new Alfateam.CertGenerators.Models.AlfateamEDSGeneratorOrganizationParams
            {
                Title = "ИП Бондарев Артур Александрович",
                CommonName = "ИП Бондарев Артур Александрович",
                CountryCode = "RU",
                LocalityName = "Омск",
                Organization = "ИП Бондарев Артур Александрович",
                OrganizationIdentifier = "360410571269",
                OrganizationUnitName = "IT",
                Password = "228228vV",
                PostalAddress = "г. Омск",
                PostalCode = "ZOV123",
                Role = "CEO",
                StateOrProvinceName = "Омск",
                Street = "ул. Омск, д.7",


                TelephoneNumber = "79043260186",
                DateOfBirth = new DateTime(2002, 9, 8),
                CountryCodeOfCitizenship = "RU",
                CountryOfResidence = "RU",
                EmailAddress = "alfateam2@yandex.kz",
                Gender = Gender.M,
                GivenName = "Бондарев",
                Name = "Артур",
                PlaceOfBirth = "sddsgsd",
                Surname = "Александрович",
                UniqueIdentifier = "12343243"
            });
            File.WriteAllBytes("C:\\Users\\User\\Desktop\\file.pfx", certInfo.PFX.Export(X509ContentType.Pfx, certInfo.Props.Password));



            //var pfx = "C:\\Users\\User\\Desktop\\file.pfx".GetPrivateCert("228228vV");






            var publicKeyString = certInfo.KeyPair.Public.ConvertKeyToBase64();


            var certBytes = File.ReadAllBytes("C:\\Users\\User\\Desktop\\file.pfx");
            var data = AlfateamEDSGenerator.SignData("Леон пидор", certBytes, "228228vV");
            var res = AlfateamEDSGenerator.VerifyAlfateamEDS("Леон пидор", data, publicKeyString);
        }
    }
}
