using System.Collections.Generic;

namespace FinalASP.Models
{
    public static class MyGeneralModel
    {
        public static string? Image { get; set; } = string.Empty;
        public static int SupplierIdTracker { get; set; }
        public static int ChefIdTracker { get; set; }
        public static int DeliveryIdTracker { get; set; }
        public static int PhyKitchenIdTracker { get; set; }
        public static int VirualOrderIdTracker { get; set; }
        public static int ReservationIdTracker { get; set; }
        public static int KitchenIdTracker { get; set; }

        public static List<Kitchen> ?kitchens { get; set; } = new List<Kitchen>();
        public static List<item> Matrials { get; set; } = new List<item> ();
        
        public static Kitchen? Kitchen { get; set; } = new Kitchen();

        public static Reservation? reservation { get; set; } = new Reservation();
    }
    public class item
    {
        public SupplierMatrial SupplierMatrial { get; set;} = new SupplierMatrial();
        public int Quantity { get; set; } = 1;
    }
}
