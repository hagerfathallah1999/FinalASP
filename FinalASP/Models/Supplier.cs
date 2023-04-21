using System.ComponentModel.DataAnnotations;
namespace FinalASP.Models
{
    public class Supplier
    {
        [Key]
        public int id {  get; set; }
        [Required(ErrorMessage = "This field is Required")]
        public string name { get; set; } = string.Empty;
        [Required(ErrorMessage = "This field is Required")]
        public string Location { get; set; } = string.Empty;
        [Required(ErrorMessage = "This field is Required")]
        public string Capacity { get; set; } = string.Empty;
        public ICollection<SupplierMatrial> SupplierMatrials { get; set; } = new List<SupplierMatrial>();

    }
}
