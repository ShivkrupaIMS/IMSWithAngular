using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.VM
{
    public class ManufacturerVM
    {
        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; }

        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
