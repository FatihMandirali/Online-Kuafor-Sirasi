using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeefKuaforSiram.Core.Domain.Modeller
{
    public class KullaniciFavorilerRequest
    {
        public string kuaforSlug { get; set; }

        public int kullaniciId { get; set; }
    }
}