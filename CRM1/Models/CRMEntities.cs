using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using CRM1.Models;

namespace CRM1
{
    public partial class CRMEntities : DbContext
    {
        public CRMEntities()
            : base("name=CRMEntities")
        {
        }

        public virtual DbSet<KULLANICILAR> KULLANICILAR { get; set; }
        public virtual DbSet<MUSTERILER> MUSTERILER { get; set; }
        public virtual DbSet<URUNLER> URUNLER { get; set; }
        public virtual DbSet<Sepet> Sepet { get; set; }
        public virtual DbSet<SIPARISLER> SIPARISLER { get; set; }
        public virtual DbSet<IMAGE> IMAGE { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
