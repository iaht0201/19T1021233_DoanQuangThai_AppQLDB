using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace AppQuanLyDanhBa.Model
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=AppDBContext")
        {
        }

        public virtual DbSet<Nguoi> Nguois { get; set; }
        public virtual DbSet<Nhom> Nhoms { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Nhom>()
                .HasMany(e => e.Nguois)
                .WithOptional(e => e.Nhom)
                .HasForeignKey(e => e.IDNhom);
        }
    }
}
