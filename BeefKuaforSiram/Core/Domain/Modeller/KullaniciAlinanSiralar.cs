using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeefKuaforSiram.Core.Domain.Modeller
{
    public class KullaniciAlinanSiralar
    {
        public string trasCesidi { get; set; }

        public string tarih { get; set; }

        public string kuaforElemani { get; set; }

        public string kuafor { get; set; }

        public string saatAraligi { get; set; }

        public bool siradurum { get; set; }

        public bool tamamlanmadurum { get; set; }

        public int id { get; set; }
    }
}