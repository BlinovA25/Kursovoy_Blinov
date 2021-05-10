using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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


    class REVIEWS
    {
        [Key]
        public int ReviewID { get; set; }
        public string UserName { get; set; }
        public string ReviewText { get; set; }

    }
}
