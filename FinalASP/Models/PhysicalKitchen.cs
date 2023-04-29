using System.ComponentModel.DataAnnotations;

namespace FinalASP.Models
{
    public class PhysicalKitchen
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "CompnayName is Required")]
        public string CompanyName { get; set; } = string.Empty; 
        public string Email { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Email is Required")]
        public string Locaion { get; set; } = string.Empty;
        public string LogoImage { get; set; } = string.Empty;
        [Required(ErrorMessage = "Phone is Required")]
        public double Phone { get; set; }
		[Required(ErrorMessage = "Domain is Required")]
		public string Domain { get; set; } = string.Empty;
        public ICollection<Kitchen> OwnedKitchens { get; set; } = new List<Kitchen>();
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    }
}
