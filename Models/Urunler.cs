using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace StokTakip.Models
{
    [Table("Urunler")]
    public class Urunler
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, DisplayName("Ürün Adı")]
        public string UrunAdi { get; set; }

        [Required, DisplayName("Ürün Kodu")]
        public string UrunKodu { get; set; }

        [Required, DisplayName("Ürün Fiyatı")]
        public int Fiyat { get; set; }

        [Required, DisplayName("Ürün Stok Drumu")]
        public int Stok { get; set; }

        public ICollection<Satislar> Satislar { get; set; } // Bir ürün birçok kez satılabilir
    }
}