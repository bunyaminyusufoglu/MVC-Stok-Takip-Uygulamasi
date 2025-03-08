using StokTakip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StokTakip.ViewModels.Home
{
    public class HomePageViewModel
    {
        public List<Urunler> Urunler { get; set; }
        public List<Musteriler> Musteriler { get; set; }
        public List<Satislar> Satislar { get; set; }
    }
}