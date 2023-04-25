using System.ComponentModel.DataAnnotations;

namespace FinalASP.Models
{
    public class VirtualKitchen
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Address is Required")]
        public string Address { get; set; } = string.Empty;
        [Required(ErrorMessage = "CompnayName is Required")]
        public string CompanyName { get; set; } = string.Empty;
		public string LogoImage { get; set; } = string.Empty;
        [Required(ErrorMessage = "Phone is Required")]
        public double Phone { get; set; }
		[Required(ErrorMessage = "Domain is Required")]
        public string Domain { get; set; } = string.Empty;

		public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    }
}
