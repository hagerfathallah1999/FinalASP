using System.ComponentModel.DataAnnotations;

namespace FinalASP.Models
{
    public class Reservation
    {
        [Key]
        public int id {  get; set; }
        [Required(ErrorMessage = "This field is Required")]
        public DateTime OrderDate { get; set; }
        public double TotalPrice { get; set; }
        [Required(ErrorMessage = "This field is Required")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "This field is Required")]
        public DateTime EndDate { get; set; }

        public int VirtualKitchenID { get; set; }
        public int PhysicalKitchenID { get; set; }
        public int kitchenID { get; set; }
        public VirtualKitchen VirtualKitchen { get; set; }
        public PhysicalKitchen PhysicalKitchen { get; set; }
        public Kitchen kitchen { get; set; }
        public ICollection<VirtualOrder> VirtualOrders { get; set; } = new List<VirtualOrder>();

    }
}
