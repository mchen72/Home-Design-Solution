// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HDS_WebApp.Models
{
    public partial class ProductData
    {
        public string Id { get; set; }
        public string Brand { get; set; }
        public int Cost { get; set; }
        public string CurrentInventory { get; set; }
        public string Description { get; set; }
        public string LargeItem { get; set; }
        public double ListPrice { get; set; }
        public string ModelNumber { get; set; }
        public int SerialNumber { get; set; }
        public string CategoryName { get; set; }
        public string Name { get; set; }
    }
}
