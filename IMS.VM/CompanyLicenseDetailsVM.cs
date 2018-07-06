using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.VM
{
    public class CompanyLicenseDetailsVM
    {
        public LicenseTypeVM License { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public string LicenseNo { get; set; }
        public bool IsActive { get; set; }
    }
}
