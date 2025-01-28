using Alfateam.CertGenerators.Attributes;
using Alfateam.CertGenerators.Enums;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CertGenerators.Models
{
    public class AlfateamEDSGeneratorPhysicalParams
    {
        public string Password { get; set; }




        [DerObjectIdentifierName("Name")]
        public string Name { get; set; }

        [DerObjectIdentifierName("Surname")]
        public string Surname { get; set; }

        [DerObjectIdentifierName("GivenName")]
        public string? GivenName { get; set; }

        [DerObjectIdentifierName("DateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        [DerObjectIdentifierName("Gender")]
        public Gender Gender { get; set; }

        [DerObjectIdentifierName("CountryOfCitizenship")]
        public string CountryCodeOfCitizenship { get; set; }

        [DerObjectIdentifierName("CountryOfResidence")]
        public string CountryOfResidence { get; set; }

        [DerObjectIdentifierName("UniqueIdentifier")]
        public string UniqueIdentifier { get; set; }





        [DerObjectIdentifierName("PlaceOfBirth")]
        public string? PlaceOfBirth { get; set; }




        [DerObjectIdentifierName("TelephoneNumber")]
        public string TelephoneNumber { get; set; }

        [DerObjectIdentifierName("E")]
        public string EmailAddress { get; set; }


        public X509Name MakeX509Name()
        {
            var str = $"Gender={Gender.ToString()},DateOfBirth={DateOfBirth.ToString("yyyyMMdd000000Z")},";

            var certParamsList = new List<string>();
            foreach(var prop in this.GetType().GetProperties().Where(o => o.Name != "Gender" && o.Name != "DateOfBirth"))
            {
                var attribute = prop.GetCustomAttributes(true).FirstOrDefault(o => o is DerObjectIdentifierName) as DerObjectIdentifierName;
                if(attribute != null)
                {
                    certParamsList.Add($"{attribute.Name}={((string)prop.GetValue(this)).Replace(",","")}");
                }
            }

            str += string.Join(',', certParamsList);
            return new X509Name(str);
        }
    }
}
