using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.VM
{
    public class CompanyVM
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string MailingName { get; set; }
        public string Address { get; set; }
        public StateVM State { get; set; }
        public CountryVM Country { get; set; }
        public string PinCode { get; set; }
        public string GSTNo { get; set; }
        public string PANNo { get; set; }
        public string Phone { get; set; }
        public string MobileNo { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string ContactPerson { get; set; }
        public string CINNo { get; set; }
        public DateTime? FYStartDate { get; set; }
        public DateTime? BookStartDate { get; set; }
        public string Branch { get; set; }
        public List<CompanyLicenseDetailsVM> Licenses { get; set; }
        public CompanyTypeVM CompanyType { get; set; }
        public bool IsActive { get; set; }
    }
}
