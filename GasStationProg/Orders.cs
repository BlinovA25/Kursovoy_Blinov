using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasStationProg
{
    public class Orders
    {
        public int idOrder { get; set; }
        public decimal Quantity { get; set; }
        public decimal OrderSum { get; set; }

        public Fuel OrderFuel { get; set; }
        public User OrderUser { get; set; }

    }
}
