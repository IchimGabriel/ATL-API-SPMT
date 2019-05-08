using System;
using System.ComponentModel.DataAnnotations;

namespace ATL_API_SPMT.Models
{
    public class Container
    {
        [Key]
        public Guid Unit_Id { get; set; }
        public string Name { get; set; }
    }
}
