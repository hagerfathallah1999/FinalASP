using System.ComponentModel.DataAnnotations;

namespace FinalASP.Models
{
    public class DeliveryCompany
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "CompnayName is Required")]
        public string CompanyName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public string Name { get; set; }=string.Empty;
		[Required(ErrorMessage = "Domain is Required")]
		public string Domain { get; set; } = string.Empty;
		[Required(ErrorMessage = "Phone is Required")]
		public string Phone { get; set; } = string.Empty;
		[Required(ErrorMessage = "CoverageArea is Required")]
		public string CoverageArea { get; set; } = string.Empty;
        public string logo { get; set; } = string.Empty;


    }
}
