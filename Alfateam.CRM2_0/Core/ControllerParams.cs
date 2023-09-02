using Alfateam.DB;

namespace Alfateam.CRM2_0.Core
{
    public class ControllerParams
    {
        public CRMDBContext DB { get; set; }
        public IWebHostEnvironment AppEnvironment { get; set; }
    }
}
