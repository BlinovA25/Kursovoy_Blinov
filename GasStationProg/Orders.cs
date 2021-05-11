using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GasStationProg
{
    //public class Movie
    //{
    //    public int Id { get; set; }
    //    public string Title { get; set; }
    //    public DateTime ReleaseDate { get; set; }

    //    public virtual Actor Actor { get; set; }
    //}

    //public class Actor
    //{
    //    public int Id { get; set; }
    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }
    //    public DateTime DateOfBirth { get; set; }

    //    public virtual ICollection Movies { get; set; }
    //}

    //[Table("V_MovieActors")]
    //public class VMovie
    //{
    //    [Key]
    //    public Guid Id { get; set; }
    //    public string Title { get; set; }
    //    public DateTime ReleaseDate { get; set; }
    //    public string Actor { get; set; }
    //    public DateTime DateOfBirth { get; set; }
    //}

    //public class LibraryContext : DbContext
    //{
    //    public virtual DbSet Movies { get; set; }
    //    public virtual DbSet Actors { get; set; }
    //    public virtual DbSet VMovies { get; set; }

    //    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    //    {
    //        modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
    //        base.OnModelCreating(modelBuilder);
    //    }
    //}

    class OrderContext : DbContext
    {
        public OrderContext() : base("DbConnection")
        { }
        public DbSet<ORDERS> Orders { get; set; }
    }

    [Table("ORDERS")]
    public class ORDERS
    {
        [Key]
        public int idOrder{ get; set; }
        public decimal Quantity { get; set; }
        public decimal OrderSum { get; set; }


        public string UserName { get; set; }
        //public int UserID { get; set; }
        //[ForeignKey("UserID")]
        //public USERS users { get; set; }

        public string FuelName { get; set; }
        //public int FuelID { get; set; }
        //[ForeignKey("FuelID")]
        //public FUEL fuel { get; set; }

        public int OrderStatus { get; set; }

        public DateTime ArrTime { get; set; }

        public DateTime ReadyTime { get; set; }
    }
}
