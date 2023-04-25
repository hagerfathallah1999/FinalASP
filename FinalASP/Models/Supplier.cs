using System.ComponentModel.DataAnnotations;
namespace FinalASP.Models
{
    public class Supplier
    {
        [Key]
        public int id {  get; set; }
        [Required(ErrorMessage = "name is Required")]
		public string CompanyName { get; set; } = string.Empty;
        [Required(ErrorMessage = "name is Required")]
        public string Username { get; set; } = string.Empty;
        [Required(ErrorMessage = "location is Required")]
        public string Location { get; set; } = string.Empty;
        [Required(ErrorMessage = "capacity is Required")]
        public string Capacity { get; set; } = string.Empty;
		[Required(ErrorMessage = "type is Required")]
		public string type { get; set; } = string.Empty;
		[Required(ErrorMessage = "phone is Required")]
		public string phone { get; set; } = string.Empty;
        [Required(ErrorMessage = "This field is Required")]
        public string logo { get; set; } = string.Empty;
        public ICollection<SupplierMatrial> SupplierMatrials { get; set; } = new List<SupplierMatrial>();

    }
}
