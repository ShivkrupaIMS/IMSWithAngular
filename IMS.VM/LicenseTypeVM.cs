using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.VM
{
    public class LicenseTypeVM
    {
        public int LicenseTypeId { get; set; }
        public string LicenseType { get; set; }

        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
