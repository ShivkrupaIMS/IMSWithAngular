using IMS.DF.DL;
using IMS.VM;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DL
{
    public class InvoiceDL : BaseDL, IInvoiceDL
    {
        public InvoiceVM AddInvoice(InvoiceVM c)
        {
            DB.tblInvoice Invoice = IMSDB.tblInvoices.Add(
                new DB.tblInvoice
                {
                   InvoiceNumber = c.InvoiceNumber,
                   CreatedDate = System.DateTime.Now,
                   InvoiceDate = c.InvoiceDate,
                   InvoiceTypeId = c.InvoiceType.InvoiceTypeId,
                   CompanyGSTIN = c.Company.GSTNo,
                   CompanyId = c.Company.CompanyId,
                   SupplyStateId = c.SupplyState.StateId,
                   TotalInvoiceAmount = c.TotalInvoiceAmount,
                   IsReverseCharge = c.IsReverseCharge,
                   IsActive = c.IsActive
                });

            c.InvoiceDetails.ForEach(p =>
                IMSDB.tblInvoiceDetails.Add(
                    new DB.tblInvoiceDetail
                    {
                       ItemId = p.Item.ItemId,
                       DiscountPercent = p.DiscountPercent,
                       CessAmount = p.CessAmount,
                       CessRate = p.CessRate,
                       CGSTAmount = p.CGSTAmount,
                       CGSTRate = p.CGSTRate,
                       IGSTAmount = p.IGSTAmount,
                       IGSTRate = p.IGSTRate,
                       DiscountValue = p.DiscountValue,
                       ItemValue = p.ItemValue,
                       Quantity = p.Quantity,
                       SGSTAmount = p.SGSTAmount,
                       SGSTRate = p.SGSTRate,
                       TaxableValue = p.TaxableValue,
                       TotalTaxPlusCess = p.TotalTaxPlusCess,
                       TotalTransactionAmount = p.TotalTransactionAmount,
                       IsActive = p.IsActive,
                       tblInvoice = Invoice
                    })
                );
           
            IMSDB.SaveChanges();
            c.InvoiceId = Invoice.InvoiceId;
            return c;
        }

        public int DeleteInvoice(int InvoiceId)
        {
            IMSDB.tblInvoiceDetails.RemoveRange(IMSDB.tblInvoiceDetails.Where(p => p.InvoiceId == InvoiceId));
            IMSDB.tblInvoices.Remove(IMSDB.tblInvoices.Where(p => p.InvoiceId == InvoiceId).FirstOrDefault());
            IMSDB.SaveChanges();
            return 1;
        }

        public InvoiceVM EditInvoice(InvoiceVM c)
        {
            DB.tblInvoice Invoice = IMSDB.tblInvoices.Find(c.InvoiceId);
            if (Invoice != null)
            {
                IMSDB.tblInvoiceDetails.RemoveRange(IMSDB.tblInvoiceDetails.Where(p => p.InvoiceId == c.InvoiceId));

                Invoice.InvoiceNumber = c.InvoiceNumber;
                Invoice.CreatedDate = System.DateTime.Now;
                Invoice.InvoiceDate = c.InvoiceDate;
                Invoice.InvoiceTypeId = c.InvoiceType.InvoiceTypeId;
                Invoice.CompanyGSTIN = c.Company.GSTNo;
                Invoice.CompanyId = c.Company.CompanyId;
                Invoice.SupplyStateId = c.SupplyState.StateId;
                Invoice.TotalInvoiceAmount = c.TotalInvoiceAmount;
                Invoice.IsReverseCharge = c.IsReverseCharge;
                Invoice.IsActive = c.IsActive;

                c.InvoiceDetails.ForEach(p =>
                IMSDB.tblInvoiceDetails.Add(
                    new DB.tblInvoiceDetail
                    {
                        ItemId = p.Item.ItemId,
                        DiscountPercent = p.DiscountPercent,
                        CessAmount = p.CessAmount,
                        CessRate = p.CessRate,
                        CGSTAmount = p.CGSTAmount,
                        CGSTRate = p.CGSTRate,
                        IGSTAmount = p.IGSTAmount,
                        IGSTRate = p.IGSTRate,
                        DiscountValue = p.DiscountValue,
                        ItemValue = p.ItemValue,
                        Quantity = p.Quantity,
                        SGSTAmount = p.SGSTAmount,
                        SGSTRate = p.SGSTRate,
                        TaxableValue = p.TaxableValue,
                        TotalTaxPlusCess = p.TotalTaxPlusCess,
                        TotalTransactionAmount = p.TotalTransactionAmount,
                        IsActive = p.IsActive,
                        tblInvoice = Invoice
                    })
                );

                IMSDB.Entry(Invoice).State = EntityState.Modified;
                IMSDB.SaveChanges();
            }
            return c;
        }

        public InvoiceVM GetInvoiceById(int InvoiceId)
        {
            DB.tblInvoice Invoice = IMSDB.tblInvoices.Where(p => p.InvoiceId == InvoiceId).FirstOrDefault();
            if (Invoice != null)
            {
                List<LicenseTypeVM> licenseList = new List<LicenseTypeVM>();
                List<InvoiceDetailsVM> invoiceDetailsList = new List<InvoiceDetailsVM>();


                Invoice.tblInvoiceDetails.ToList().ForEach(p =>
                    invoiceDetailsList.Add(new InvoiceDetailsVM
                    {
                        Item = new ItemVM { ItemId = p.tblItem.ItemId, ItemName = p.tblItem.ItemName, CGST =(float) p.tblItem.CGST, IGST = (float)p.tblItem.IGST, SGST = (float) p.tblItem.SGST},
                        DiscountPercent = p.DiscountPercent,
                        CessAmount = p.CessAmount,
                        CessRate = p.CessRate,
                        CGSTAmount = p.CGSTAmount,
                        CGSTRate = p.CGSTRate,
                        IGSTAmount = p.IGSTAmount,
                        IGSTRate = p.IGSTRate,
                        DiscountValue = p.DiscountValue,
                        ItemValue = p.ItemValue,
                        Quantity = p.Quantity,
                        SGSTAmount = p.SGSTAmount,
                        SGSTRate = p.SGSTRate,
                        TaxableValue = p.TaxableValue,
                        TotalTaxPlusCess = p.TotalTaxPlusCess,
                        TotalTransactionAmount = p.TotalTransactionAmount,
                        IsActive = p.IsActive,
                        InvoiceId = InvoiceId
                    })
                );

                return new InvoiceVM()
                {
                    InvoiceNumber = Invoice.InvoiceNumber,
                    InvoiceDate = Invoice.InvoiceDate,
                    InvoiceType = new InvoiceTypeVM { InvoiceTypeId = Invoice.tblInvoiceType.InvoiceTypeId },
                    Company = new CompanyVM { CompanyId = Invoice.CompanyId, GSTNo = Invoice.CompanyGSTIN },
                    SupplyState = new StateVM { StateId = Invoice.SupplyStateId },
                    TotalInvoiceAmount = Invoice.TotalInvoiceAmount,
                    IsReverseCharge = Invoice.IsReverseCharge,
                    IsActive = Invoice.IsActive,
                    InvoiceDetails = invoiceDetailsList
                };
            }
            return null;

        }

        public IList<InvoiceVM> GetInvoiceList()
        {
            List<InvoiceVM> InvoiceList = new List<InvoiceVM>();
            List<DB.tblInvoice> items = IMSDB.tblInvoices.ToList();
            if (items != null)
            {
                items.ForEach(Invoice => {
                    List<InvoiceDetailsVM> invoiceDetailsList = new List<InvoiceDetailsVM>();
                    

                    Invoice.tblInvoiceDetails.ToList().ForEach(p =>
                        invoiceDetailsList.Add(new InvoiceDetailsVM
                        {
                            Item = new ItemVM { ItemId = p.tblItem.ItemId, ItemName = p.tblItem.ItemName, CGST = (float)p.tblItem.CGST, IGST = (float)p.tblItem.IGST, SGST = (float)p.tblItem.SGST },
                            DiscountPercent = p.DiscountPercent,
                            CessAmount = p.CessAmount,
                            CessRate = p.CessRate,
                            CGSTAmount = p.CGSTAmount,
                            CGSTRate = p.CGSTRate,
                            IGSTAmount = p.IGSTAmount,
                            IGSTRate = p.IGSTRate,
                            DiscountValue = p.DiscountValue,
                            ItemValue = p.ItemValue,
                            Quantity = p.Quantity,
                            SGSTAmount = p.SGSTAmount,
                            SGSTRate = p.SGSTRate,
                            TaxableValue = p.TaxableValue,
                            TotalTaxPlusCess = p.TotalTaxPlusCess,
                            TotalTransactionAmount = p.TotalTransactionAmount,
                            IsActive = p.IsActive,
                            InvoiceId = p.InvoiceId
                        })
                    );

                    InvoiceList.Add(
                     new InvoiceVM()
                     {
                         InvoiceNumber = Invoice.InvoiceNumber,
                         InvoiceDate = Invoice.InvoiceDate,
                         InvoiceType = new InvoiceTypeVM { InvoiceTypeId = Invoice.tblInvoiceType.InvoiceTypeId },
                         Company = new CompanyVM { CompanyId = Invoice.CompanyId, GSTNo = Invoice.CompanyGSTIN },
                         SupplyState = new StateVM { StateId = Invoice.SupplyStateId },
                         TotalInvoiceAmount = Invoice.TotalInvoiceAmount,
                         IsReverseCharge = Invoice.IsReverseCharge,
                         IsActive = Invoice.IsActive,
                        InvoiceDetails = invoiceDetailsList
                     });
                });
            }

            return InvoiceList;
        }
    }
}
