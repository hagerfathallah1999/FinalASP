using System.ComponentModel.DataAnnotations;

namespace FinalASP.Models
{
    public class SupplierMatrial
    {
        [Key]
        public int id {  get; set; }
        [Required(ErrorMessage = "This field is Required")]
        public string name { get; set; }=string.Empty;
        [Required(ErrorMessage = "This field is Required")]
        public string description { get; set; } = string.Empty;
        [Required(ErrorMessage = "This field is Required")]
        public double Price { get; set; }
        public string Image { get; set; } = string.Empty;
        [Required(ErrorMessage = "This field is Required")]
        public double quantity { get; set; }
        public string image { get; set; } = string.Empty;

        public int SupplierId { get; set;}
        public Supplier Supplier { get; set; }

    }
}
