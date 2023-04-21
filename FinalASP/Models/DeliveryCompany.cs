using System.ComponentModel.DataAnnotations;

namespace FinalASP.Models
{
    public class DeliveryCompany
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }=string.Empty;
        public string Domain { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string CoverageArea { get; set; } = string.Empty;
    }
}
