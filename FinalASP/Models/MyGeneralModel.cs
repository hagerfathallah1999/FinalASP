namespace FinalASP.Models
{
    public static class MyGeneralModel
    {
        public static string Image { get; set; } = string.Empty;
        public static List<Kitchen> ?kitchens { get; set; } = new List<Kitchen>();
        
    }
}
