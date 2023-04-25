using System.ComponentModel.DataAnnotations;

namespace FinalASP.Models
{
    public class PhysicalKitchen
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "This field is Required")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "This field is Required")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "This field is Required")]
        public string Locaion { get; set; } = string.Empty;
        public string LogoImage { get; set; } = string.Empty;
        public double Phone { get; set; }
		[Required(ErrorMessage = "This field is Required")]
		public string Domain { get; set; } = string.Empty;
		[Required(ErrorMessage = "This field is Required")]
		public ICollection<Kitchen> OwnedKitchens { get; set; } = new List<Kitchen>();
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    }
}
