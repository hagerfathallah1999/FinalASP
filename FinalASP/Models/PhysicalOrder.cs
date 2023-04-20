namespace FinalASP.Models
{
    public class PhysicalOrder
    {
        public int Id { get; set; }
        public string order { get; set; }
        public string OrderSource { get; set; }
        public string Orderdestination { get; set; }
        public double OrderPrice { get; set; }
        public int PhysicalOrderListID { get; set; }


        public PhysicalOrderList PhysicalOrderList { get; set; }
    }
}
