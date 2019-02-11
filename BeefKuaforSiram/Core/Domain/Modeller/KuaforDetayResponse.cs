using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeefKuaforSiram.Core.Domain.Modeller
{
    public class KuaforDetayResponse
    {
        public string kuaforSlug { get; set; }
        public string calismaSaati { get; set; }
        public int puan { get; set; }
        public string resim { get; set; }
    }
}