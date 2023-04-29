namespace FinalASP.Models
{
    public static class MyGeneralModel
    {
        public static string Image { get; set; } = string.Empty;
        public static int SupplierIdTracker { get; set; }
        public static int ChefIdTracker { get; set; }
        public static int DeliveryIdTracker { get; set; }
        public static int PhyKitchenIdTracker { get; set; }
        public static int VirualOrderIdTracker { get; set; }
        public static int ReservationIdTracker { get; set; }
        public static int KitchenIdTracker { get; set; }

        public static List<Kitchen> ?kitchens { get; set; } = new List<Kitchen>();
        
    }
}
