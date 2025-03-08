using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StokTakip.Models
{
    [Table("Satislar")]
    public class Satislar
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, DisplayName("Müşteri")]
        public int MusteriId { get; set; }  // Foreign key olarak int yapıldı

        [ForeignKey("MusteriId")]
        public Musteriler Musteri { get; set; } // Navigation Property

        [Required, DisplayName("Alınan Ürün")]
        public int UrunId { get; set; }  // Foreign key olarak int yapıldı

        [ForeignKey("UrunId")]
        public Urunler Urun { get; set; } // Navigation Property

        [Required, DisplayName("Ürün Adeti")]
        public int Adet { get; set; }

        [Required, DisplayName("İşlem Tarihi")]
        public DateTime Tarih { get; set; }
    }
}