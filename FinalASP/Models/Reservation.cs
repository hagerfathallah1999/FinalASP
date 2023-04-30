using System.ComponentModel.DataAnnotations;

namespace FinalASP.Models
{
    public class Reservation
    {
        [Key]
        public int id {  get; set; }
        
        public double TotalPrice { get; set; }
        [Required(ErrorMessage = "This field is Required")]
        public string StartDate { get; set; } = string.Empty;
        [Required(ErrorMessage = "This field is Required")]
        public string EndDate { get; set; }=string.Empty;

        public int VirtualKitchenID { get; set; }
        public int PhysicalKitchenID { get; set; }
        public int kitchenID { get; set; }
        public VirtualKitchen VirtualKitchen { get; set; }
        public PhysicalKitchen PhysicalKitchen { get; set; }
        public Kitchen kitchen { get; set; }
        public ICollection<VirtualOrder> VirtualOrders { get; set; } = new List<VirtualOrder>();

    }
}
