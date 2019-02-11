using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeefKuaforSiram.Core.Domain.Modeller.YoneticiAdminModel
{
    public class KuaforlerListResponse
    {
        public int id { get; set; }
        public string kuaforAdi { get; set; }
        public string sehir { get; set; }
        public string semt { get; set; }
        public string adres { get; set; }
        public string telefon { get; set; }
        public string mail { get; set; }
        public string sahip { get; set; }
        public int cinsiyet { get; set; }
        public string acilmaSaati { get; set; }
        public string kapanmaSaati { get; set; }
        public int puan { get; set; }
        public DateTime eklenmeTarihi { get; set; }
    }
}