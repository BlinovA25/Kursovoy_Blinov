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
    class ReviewContext : DbContext
    {
        public ReviewContext() : base("DbConnection")
        { }
        public DbSet<REVIEWS> Reviews { get; set; }
    }

    [Table("REVIEWS")]
    class REVIEWS
    {
        [Key]
        public int ReviewID { get; set; }
        public string UserName { get; set; }
        public string Review { get; set; }

    }
}
