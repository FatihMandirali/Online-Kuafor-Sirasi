using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeefKuaforSiram.Core.Domain.Modeller
{
    public class KuaforDetayYorum
    {
        public string KuaforAdi { get; set; }

        public string KullaniciAdi { get; set; }

        public string Yorum { get; set; }

        public int KalitePuan { get; set; }

        public int OzenPuan { get; set; }

        public int HizPuan { get; set; }

    }
}