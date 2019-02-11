using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeefKuaforSiram.Core.Domain.Modeller
{
    public class KullaniciMessageRequest
    {
        public int kuaforId { get; set; }
        public string kullaniciSlug { get; set; }
        public string mesaj { get; set; }
    }
}