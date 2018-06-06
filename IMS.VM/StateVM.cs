using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.VM
{
    public class StateVM
    {
        public int StateId { get; set; }
        //public string StateCode { get; set; }
        public string StateName { get; set; }
        public bool IsActive { get; set; }

        public CountryVM Country { get; set; }
    }
}
