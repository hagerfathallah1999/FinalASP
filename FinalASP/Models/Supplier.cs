using System.ComponentModel.DataAnnotations;
namespace FinalASP.Models
{
    public class Supplier
    {
        [Key]
        public int id {  get; set; }
        [Required(ErrorMessage = "name is Required")]
        public string name { get; set; } = string.Empty;
        [Required(ErrorMessage = "location is Required")]
        public string location { get; set; } = string.Empty;
        [Required(ErrorMessage = "capacity is Required")]
        public string capacity { get; set; } = string.Empty;
		[Required(ErrorMessage = "type is Required")]
		public string type { get; set; } = string.Empty;
		[Required(ErrorMessage = "phone is Required")]
		public string phone { get; set; } = string.Empty;
		public string logo { get; set; } = string.Empty;
        public ICollection<SupplierMatrial> SupplierMatrials { get; set; } = new List<SupplierMatrial>();

    }
}
