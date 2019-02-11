using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeefKuaforSiram.Core.Domain.Modeller
{
    public class KullaniciYorumRequest
    {
        public string yorum { get; set; }

        public int hizPuan { get; set; }

        public int ozenPuan { get; set; }

        public int kalitePuan { get; set; }

        public string kuaforAdi { get; set; }

        public string kullaniciSlug { get; set; }
    }
}