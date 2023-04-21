using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinalASP.Models
{
    public class CloudKitchenContext : IdentityDbContext<ApplicationUser>   
    {
        public DbSet<DeliveryCompany> DeliveryCompanys {get; set;}
        public DbSet<Kitchen> Kitchens { get; set; }
        public DbSet<PhysicalKitchen> PhysicalKitchens { get; set; }
        public DbSet<PhysicalOrder> PhysicalOrders { get; set; }
        public DbSet<PhysicalOrderList> PhysicalOrderLists { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<SupplierMatrial> SupplierMatrials { get; set;}
        public DbSet<VirtualKitchen> VirtualKitchens { get; set; }
        public DbSet<VirtualOrder> VirtualOrders { get; set; }

        public CloudKitchenContext() : base() { }
        public CloudKitchenContext(DbContextOptions options) : base(options) { }
    }
}
