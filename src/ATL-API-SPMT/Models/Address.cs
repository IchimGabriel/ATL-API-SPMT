using System;
using System.ComponentModel.DataAnnotations;

namespace ATL_API_SPMT.Models
{
    public class Address
    {
        [Key]
        public Guid Address_Id { get; set; }
        public Guid User_Id { get; set; }
        public string Field_1 { get; set; }
        public string Field_2 { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
    }
}
