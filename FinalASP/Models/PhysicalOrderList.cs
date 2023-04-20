using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FinalASP.Models
{
    public class PhysicalOrderList
    {
        [Key]
        public int Id { get; set; }
        
        public DateTime OrderDate { get; set; }
        public int PhysicalKitchenID { get; set; }
        

        public PhysicalKitchen PhysicalKitchen { get; set; }
        public ICollection<PhysicalOrder> PhysicalOrders { get; set; } = new List<PhysicalOrder>();

    }
}
