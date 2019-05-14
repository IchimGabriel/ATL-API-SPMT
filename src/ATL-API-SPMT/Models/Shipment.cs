using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATL_API_SPMT.Models
{
    public class Shipment
    {
        public enum Statuses { VALID, DELIVERED, TRANSIT, FAILURE, RETURNED, CANCELED }

        [Key]
        public Guid Shipment_Id { get; set; }
        public Guid Customer_Id { get; set; }
        public Guid Employee_Id { get; set; }
        public Statuses Status { get; set; }
        public Guid Address_From_Id { get; set; }
        public Guid Address_To_Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Created_Date { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Departure_Date { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Arrival_Date { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Total_Price { get; set; }
        public Guid Route_Id { get; set; }

        public ICollection<Message> Messages { get; set; }
        public ICollection<Detail> Details { get; set; }
    }
}
