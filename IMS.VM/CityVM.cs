using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.VM
{
    public class CityVM
    {
        public int CityId { get; set; }
        //public string CityCode { get; set; }
        public string CityName { get; set; }
        public bool IsActive { get; set; }

        public StateVM State { get; set; }
    }
}
