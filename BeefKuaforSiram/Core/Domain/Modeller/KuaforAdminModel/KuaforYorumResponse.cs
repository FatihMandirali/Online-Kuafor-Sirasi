using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeefKuaforSiram.Core.Domain.Modeller.KuaforAdminModel
{
    public class KuaforYorumResponse
    {
        public int id { get; set; }

        public string yorum { get; set; }

        public int hizPuan { get; set; }

        public int ozenPuan { get; set; }

        public int kalitePuan { get; set; }

        public string kullaniciAdi { get; set; }
    }
}