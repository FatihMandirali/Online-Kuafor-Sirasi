using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeefKuaforSiram.Core.Domain.Modeller
{
    public class KuaforSiraAlRequest
    {
        public int? kullaniciId { get; set; }

        public string kuaforSlug { get; set; }

        public string trasCesitleri { get; set; }

        public int? elemanId { get; set; }

        public int? saatId { get; set; }

        public string tarih { get; set; }
    }
}