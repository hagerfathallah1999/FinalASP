namespace FinalASP.Models
{
    public class SupplierMartials
    {
        public int id {  get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public double Price { get; set; }
        public double quantity { get; set; }
        public int SupplierId { get; set;}
        public Supplier Supplier { get; set; }

    }
}
