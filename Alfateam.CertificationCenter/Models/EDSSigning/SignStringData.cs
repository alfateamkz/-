namespace Alfateam.CertificationCenter.API.Models.EDSSigning
{
    public class SignStringData
    {
        public string Data { get; set; }
        public byte[] Certificate { get; set; }
        public string Password { get; set; }
    }
}
