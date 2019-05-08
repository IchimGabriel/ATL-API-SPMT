using ATL_API_SPMT.Models;
using Microsoft.EntityFrameworkCore;

namespace ATL_API_SPMT.Data
{
    public class ShipmentContext : DbContext
    {
        public ShipmentContext(DbContextOptions<ShipmentContext> options) : base(options) { }
        public ShipmentContext() { }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Container> Containers { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
    }
}
