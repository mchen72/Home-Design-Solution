// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HDS_WebApp.Models
{
    public partial class CustomerData
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public string Id { get; set; }
        public string PhoneNumber { get; set; }
    }
}
