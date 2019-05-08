using System;
using System.ComponentModel.DataAnnotations;

namespace ATL_API_SPMT.Models
{
    public class Route
    {
        [Key]
        public Guid Route_Id { get; set; }
        public string RouteNodes { get; set; }
        public int Total_KM { get; set; }
        public float Total_CO2 { get; set; }
        public int Total_Time { get; set; }  // hours  
    }
}
