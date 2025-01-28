using Alfateam.CertGenerators.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CertGenerators.Models
{
    public class AlfateamEDSGeneratorOrganizationParams : AlfateamEDSGeneratorPhysicalParams
    {
        public AlfateamEDSGeneratorOrganizationParams()
        {

        }

        public AlfateamEDSGeneratorOrganizationParams(AlfateamEDSGeneratorPhysicalParams physicalParams)
        {
            var physicalParamsProps = physicalParams.GetType().GetProperties();
            foreach(var prop in physicalParamsProps)
            {
                this.GetType().GetProperties().FirstOrDefault(o => o.Name == prop.Name).SetValue(this, prop.GetValue(physicalParams));
            }
        }


        [DerObjectIdentifierName("C")]
        public string CountryCode { get; set; }

        [DerObjectIdentifierName("ST")]
        public string StateOrProvinceName { get; set; }

        [DerObjectIdentifierName("O")]
        public string Organization { get; set; }

        [DerObjectIdentifierName("OU")]
        public string OrganizationUnitName { get; set; }

        [DerObjectIdentifierName("T")]
        public string Title { get; set; }

        [DerObjectIdentifierName("CN")]
        public string CommonName { get; set; }

        [DerObjectIdentifierName("Street")]
        public string Street { get; set; }

        [DerObjectIdentifierName("L")]
        public string LocalityName { get; set; }

        [DerObjectIdentifierName("organizationIdentifier")]
        public string OrganizationIdentifier { get; set; }

        [DerObjectIdentifierName("PostalCode")]
        public string PostalCode { get; set; }

        [DerObjectIdentifierName("PostalAddress")]
        public string PostalAddress { get; set; }







        [DerObjectIdentifierName("ROLE")]
        public string Role { get; set; }
    }
}
