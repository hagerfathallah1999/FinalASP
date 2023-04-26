using System.ComponentModel.DataAnnotations;
namespace FinalASP.Models
{
    public class Supplier
    {
        [Key]
        public int id {  get; set; }
        [Required(ErrorMessage = "CompanyName is Required")]
		public string CompanyName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        [Required(ErrorMessage = "location is Required")]
        public string Location { get; set; } = string.Empty;
        [Required(ErrorMessage = "Capacity is Required")]
        public string Capacity { get; set; } = string.Empty;
		[Required(ErrorMessage = "Type is Required")]
		public string type { get; set; } = string.Empty;
		[Required(ErrorMessage = "Phone is Required")]
		public string phone { get; set; } = string.Empty;
        public string logo { get; set; } = string.Empty;
        public ICollection<SupplierMatrial> SupplierMatrials { get; set; } = new List<SupplierMatrial>();

    }
}
