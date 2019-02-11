using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeefKuaforSiram.Core.Domain.Modeller
{
    public class KullaniciMesajGonderRequest
    {
        public string kullaniciSlug { get; set; }

        public string mesaj { get; set; }

        public string kuaforSlug { get; set; }
    }
}