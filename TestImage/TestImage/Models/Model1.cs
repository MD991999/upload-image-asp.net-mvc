using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace TestImage.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=DBModel")
        {
        }

        public virtual DbSet<Tblimage> Tblimages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tblimage>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Tblimage>()
                .Property(e => e.Image)
                .IsUnicode(false);
        }
    }
}
