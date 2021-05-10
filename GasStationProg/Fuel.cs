using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasStationProg
{
    class FuelContext : DbContext
    {
        public FuelContext() : base("DbConnection")
        { }
        public DbSet<FUEL> AdminOrders { get; set; }
    }

    class FUEL
    {
        [Key]
        public int FuelID { get; set; }
        public string FuelName { get; set; }
        public decimal FuelPrice { get; set; }
    }

    
}
