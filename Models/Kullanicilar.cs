using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace StokTakip.Models
{
    [Table("Kullanicilar")]
    public class Kullanicilar
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, DisplayName("Adı")]
        public string Adi { get; set; }

        [Required, DisplayName("Soyadı")]
        public string Soyadi { get; set; }

        [Required, DisplayName("Kullanıcı Adı")]
        public string KullaniciAdi { get; set; }

        [Required, DisplayName("Şifre"), DataType(DataType.Password)]
        public string Sifre { get; set; }

    }
}