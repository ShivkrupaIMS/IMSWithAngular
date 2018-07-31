
namespace IMS.VM
{
    public class InvoiceDetailsVM
    {
        private int invoiceDetailsId;
        private int invoiceId;
        private ItemVM item;
        private int quantity;
        private double discountPercent;
        private double itemValue;
        private double discountValue;
        private double taxableValue;
        private double iGSTRate;
        private double iGSTAmount;
        private double cGSTRate;
        private double cGSTAmount;
        private double sGSTRate;
        private double sGSTAmount;
        private double cessRate;
        private double cessAmount;
        private double totalTaxPlusCess;
        private double totalTransactionAmount;
        private bool isActive;
        private ItemDetailsVM itemDetails;
        public ItemDetailsVM ItemDets
        {
            get { return itemDetails; }
            set { itemDetails = value; }
        }
        public int InvoiceDetailsId
        {
            get { return invoiceDetailsId; }
            set { invoiceDetailsId = value; }
        }
        public int InvoiceId
        {
            get { return invoiceId; }
            set { invoiceId = value; }
        }
        public ItemVM Item
        {
            get { return item; }
            set { item = value; }
        }
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        public double DiscountPercent
        {
            get { return discountPercent; }
            set { discountPercent = value; }
        }
        public double ItemValue
        {
            get { return itemValue; }
            set { itemValue = value; }
        }
        public double DiscountValue
        {
            get { return discountValue; }
            set { discountValue = value; }
        }
        public double TaxableValue
        {
            get { return taxableValue; }
            set { taxableValue = value; }
        }
        public double IGSTRate
        {
            get { return iGSTRate; }
            set { iGSTRate = value; }
        }
        public double IGSTAmount
        {
            get { return iGSTAmount; }
            set { iGSTAmount = value; }
        }
        public double CGSTRate
        {
            get { return cGSTRate; }
            set { cGSTRate = value; }
        }
        public double CGSTAmount
        {
            get { return cGSTAmount; }
            set { cGSTAmount = value; }
        }
        public double SGSTRate
        {
            get { return sGSTRate; }
            set { sGSTRate = value; }
        }
        public double SGSTAmount
        {
            get { return sGSTAmount; }
            set { sGSTAmount = value; }
        }
        public double CessRate
        {
            get { return cessRate; }
            set { cessRate = value; }
        }
        public double CessAmount
        {
            get { return cessAmount; }
            set { cessAmount = value; }
        }
        public double TotalTaxPlusCess
        {
            get { return totalTaxPlusCess; }
            set { totalTaxPlusCess = value; }
        }
        public double TotalTransactionAmount
        {
            get { return totalTransactionAmount; }
            set { totalTransactionAmount = value; }
        }
        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }

    }
}
