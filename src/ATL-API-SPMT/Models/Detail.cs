using System;
using System.ComponentModel.DataAnnotations;

namespace ATL_API_SPMT.Models
{
    public class Detail
    {
        [Key]
        public Guid Detail_Id { get; set; }
        public Guid Shipment_Id { get; set; }
        public Guid Container_Id { get; set; }
        public int Quantity { get; set; }
    }
}
