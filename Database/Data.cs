using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Database
{
    public partial class Data : DbContext
    {
        public Data()
            : base("name=Data")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<DnD> DnDs { get; set; }
        public virtual DbSet<PackageDetail> PackageDetails { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
