using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.VM
{
    public class InvoiceStatusVM
    {
        public int InvoiceStatusId { get; set; }
        public string InvoiceStatus { get; set; }
        public bool IsActive { get; set; }
    }
}
