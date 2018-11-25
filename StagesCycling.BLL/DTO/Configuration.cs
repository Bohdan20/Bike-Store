namespace StagesCycling.BLL.DTO
{
    using System;

    public class Configuration
    {
        public long ConfigNumber { get; set; }
        public string Customer { get; set; }
        public string Comment { get; set; }
        public decimal GrossPrice { get; set; }
        public int Discount { get; set; }
        public decimal NetPrice { get; set; }
        public DateTime Timestamp { get; set; }
        public bool CreateSalesOrder { get; set; }
    }
}
