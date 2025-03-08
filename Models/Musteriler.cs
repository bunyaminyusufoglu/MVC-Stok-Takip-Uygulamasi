using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace StokTakip.Models
{
    [Table("Musteriler")]
    public class Musteriler
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, DisplayName("Müşteri Adı")]
        public string Adi { get; set; }

        [Required, DisplayName("Müşteri Soyadı")]
        public string Soyadi { get; set; }

        [Required, DisplayName("Müşteri Telefonu")]
        public string Telefon { get; set; }

        [Required, DisplayName("Müşteri Borcu")]
        public int Borc { get; set; }

        public ICollection<Satislar> Satislar { get; set; } // Bir müşterinin birçok satışı olabilir
    }
}