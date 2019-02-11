using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeefKuaforSiram.Core.Domain.Modeller.KuaforAdminModel
{
    public class KuaforHizliSiraResponse
    {
        public int id { get; set; }

        public string baslamaSaati { get; set; }

        public string bitisSaati { get; set; }

        public bool  Durum { get; set; }


    }
}