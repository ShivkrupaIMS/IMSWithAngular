using System;
using System.Collections.Generic;

namespace IMS.VM
{
    public class InvoiceVM
    {
        private int invoiceId;
        private InvoiceTypeVM invoiceType;
        private string invoiceNumber;
        private DateTime invoiceDate;
        private CompanyVM company;
        private CompanyVM owner;
        private double totalInvoiceAmount;
        private StateVM supplyState;
        private bool isReverseCharge;
        private bool isActive;
        private List<InvoiceDetailsVM> invoiceDetails;
        public int InvoiceId
        {
            get { return invoiceId; }
            set { invoiceId = value; }
        }

        public InvoiceTypeVM InvoiceType
        {
            get { return invoiceType; }
            set { invoiceType = value; }
        }

        public string InvoiceNumber
        {
            get { return invoiceNumber; }
            set { invoiceNumber = value; }
        }
        public DateTime InvoiceDate
        {
            get { return invoiceDate; }
            set { invoiceDate = value; }
        }
        public CompanyVM Company
        {
            get { return company; }
            set { company = value; }
        }
        public CompanyVM Owner
        {
            get { return owner; }
            set { owner = value; }
        }
        public double TotalInvoiceAmount
        {
            get { return totalInvoiceAmount; }
            set { totalInvoiceAmount = value; }
        }
        public StateVM SupplyState
        {
            get { return supplyState; }
            set { supplyState = value; }
        }
        public bool IsReverseCharge
        {
            get { return isReverseCharge; }
            set { isReverseCharge = value; }
        }

        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }

        public List<InvoiceDetailsVM> InvoiceDetails
        {
            get { return invoiceDetails; }
            set { invoiceDetails = value; }
        }
    }
}
