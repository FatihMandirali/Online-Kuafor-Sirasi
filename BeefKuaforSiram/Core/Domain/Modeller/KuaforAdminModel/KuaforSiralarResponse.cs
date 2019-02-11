using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeefKuaforSiram.Core.Domain.Modeller.KuaforAdminModel
{
    public class KuaforSiralarResponse
    {
        public string saatAralik { get; set; }

        public string tarih { get; set; }

        public string  kullanici { get; set; }

        public string eleman { get; set; }

        public string trasCesidi { get; set; }

        public int id { get; set; }
    }
}