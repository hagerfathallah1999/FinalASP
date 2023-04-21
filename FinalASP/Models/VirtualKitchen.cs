using System.ComponentModel.DataAnnotations;

namespace FinalASP.Models
{
    public class VirtualKitchen
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "This field is Required")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "This field is Required")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "This field is Required")]
        public string Address { get; set; } = string.Empty;
        public string LogoImage { get; set; } = string.Empty;
        [Required(ErrorMessage = "This field is Required")]
        public double Phone { get; set; }
        public string Domain { get; set; } = string.Empty;
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    }
}
