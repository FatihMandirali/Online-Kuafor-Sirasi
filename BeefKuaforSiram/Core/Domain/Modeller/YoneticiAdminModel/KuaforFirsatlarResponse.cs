using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeefKuaforSiram.Core.Domain.Modeller.YoneticiAdminModel
{
    public class KuaforFirsatlarResponse
    {
        public int id { get; set; }
        public int onayTuru { get; set; }
        public string firsatAdi { get; set; }
        public string tarih { get; set; }
        public string kuaforAdi { get; set; }
        public string sehir { get; set; }

    }
}