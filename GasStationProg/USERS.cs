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
    class UserContext : DbContext
    {
        public UserContext() : base("DbConnection")
        { }
        public DbSet<USERS> Users { get; set; }
    }

    [Table("USERS")]
    class USERS
    {
        [Key]
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserPass { get; set; }
        public string Email { get; set; }
        public bool adm { get; set; }
        public DateTime registrDate { get; set; }
    }
}
