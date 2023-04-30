using System.ComponentModel.DataAnnotations;

namespace FinalASP.Models
{
    public class PhysicalOrder
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "This field is Required")]
        public string order { get; set; } = string.Empty;//as string from cart session
        [Required(ErrorMessage = "This field is Required")]
        public string OrderSource { get; set; } = string.Empty;
        [Required(ErrorMessage = "This field is Required")]
        public string Orderdestination { get; set; } = string.Empty;
        [Required(ErrorMessage = "This field is Required")]
        public double OrderPrice { get; set; }
        public bool DeliveryOption { get; set; } // out source delivery option
        public int PhysicalOrderListID { get; set; }
        public int PhysicalKitchenID { get; set; }

        public PhysicalKitchen PhysicalKitchen { get; set; }
        public PhysicalOrderList PhysicalOrderList { get; set; }
    }
}
