using System.ComponentModel.DataAnnotations;

namespace FinalASP.Models
{
    public class DeliveryCompany
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }=string.Empty;
		[Required(ErrorMessage = "This field is Required")]
		public string Domain { get; set; } = string.Empty;
		[Required(ErrorMessage = "This field is Required")]
		public string Email { get; set; } = string.Empty;
		[Required(ErrorMessage = "This field is Required")]
		public string Phone { get; set; } = string.Empty;
		[Required(ErrorMessage = "This field is Required")]
		public string CoverageArea { get; set; } = string.Empty;
        public string logo { get; set; } = string.Empty;


    }
}
