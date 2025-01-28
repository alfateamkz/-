namespace Alfateam.CertificationCenter.API.Models.EDSSigning
{
    public class SignBytesArrayData
    {
        public byte[] Data { get; set; }
        public byte[] Certificate { get; set; }
        public string Password { get; set; }
    }
}
