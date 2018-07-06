using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.VM
{
    public class ItemDetailsVM
    {
        public ManufacturerVM Manufacturer { get; set; }
        public ItemUnitVM ItemUnit { get; set; }
        public int? MinQuantity { get; set; }
        public string SKU { get; set; }
        public string Description { get; set; }
        public float? Discount { get; set; }
        public float? MRP { get; set; }
        public float? SalePrice { get; set; }
        public float? PurchasePrice { get; set; }
        public bool IsActive { get; set; }
    }
}
