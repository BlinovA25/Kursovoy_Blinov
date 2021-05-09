using System;
using System.Collections.Generic;
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

        public DbSet<Fuel> Fuels { get; set; }
    }

    public class Fuel
    {
        public int idFuel { get; set; }
        public string FuelName { get; set; }
        public decimal FuelPrice { get; set; }

    }
}
