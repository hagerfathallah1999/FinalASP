using System.ComponentModel.DataAnnotations;
namespace FinalASP.Models
{
    public class Supplier
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "This field is Required")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "This field is Required")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "This field is Required")]
        public string CompanyName { get; set; } = string.Empty;

        [Required(ErrorMessage = "This field is Required")]
        public string Location { get; set; } = string.Empty;

        [Required(ErrorMessage = "This field is Required")]
        public string Capacity { get; set; } = string.Empty;

        public ICollection<SupplierMatrial> SupplierMatrials { get; set; } = new List<SupplierMatrial>();

    }
}
