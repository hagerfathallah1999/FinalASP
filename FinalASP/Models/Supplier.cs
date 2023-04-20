namespace FinalASP.Models
{
    public class Supplier
    {
        public int id {  get; set; }
        public string name { get; set; }
        public string Location { get; set; }
        public string Capacity { get; set; }
        public ICollection<SupplierMartials> SupplierMartials { get; set; } = new List<SupplierMartials>();

    }
}
