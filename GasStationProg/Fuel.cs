using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public DbSet<FUEL> fuels { get; set; }
    }

    [Table("FUEL")]
    class FUEL
    {
        //public int FuelID { get; set; }
        [Key]
        public string FuelName { get; set; }
        public decimal FuelPrice { get; set; }
    }
}
