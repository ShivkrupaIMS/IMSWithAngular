//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IMS.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblInvoiceDetail
    {
        public int InvoiceDetailsId { get; set; }
        public int InvoiceId { get; set; }
        public int ItemId { get; set; }
        public int ItemDetailsId { get; set; }
        public string PackageSize { get; set; }
        public int Quantity { get; set; }
        public double DiscountPercent { get; set; }
        public double ItemValue { get; set; }
        public double DiscountValue { get; set; }
        public double TaxableValue { get; set; }
        public double IGSTRate { get; set; }
        public double IGSTAmount { get; set; }
        public double CGSTRate { get; set; }
        public double CGSTAmount { get; set; }
        public double SGSTRate { get; set; }
        public double SGSTAmount { get; set; }
        public double CessRate { get; set; }
        public double CessAmount { get; set; }
        public double TotalTaxPlusCess { get; set; }
        public double TotalTransactionAmount { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    
        public virtual tblInvoice tblInvoice { get; set; }
        public virtual tblItem tblItem { get; set; }
        public virtual tblItemDetail tblItemDetail { get; set; }
    }
}