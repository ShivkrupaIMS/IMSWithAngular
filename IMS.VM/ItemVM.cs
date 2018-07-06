using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.VM
{
    public class ItemVM
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string Ingredient { get; set; }
        public ItemTypeVM ItemType { get; set; }
        public bool IsLicenseRequired { get; set; }
        public List<LicenseTypeVM> Licenses { get; set; }
        public HSNSACVM HSNCode { get; set; }
        public float SGST { get; set; }
        public float CGST { get; set; }
        public float IGST { get; set; }
        public List<ItemDetailsVM> ItemDetails { get; set; }
        public bool IsActive { get; set; }
        public string Comment { get; set; }
        public string Description { get; set; }
    }
}
