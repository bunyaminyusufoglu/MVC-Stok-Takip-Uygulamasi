using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StokTakip.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Musteriler> Musteriler { get; set; }
        public DbSet<Satislar> Satislar { get; set; }
        public DbSet<Urunler> Urunler { get; set; }
        public DbSet<Kullanicilar> Kullanicilar { get; set; }
    }
}