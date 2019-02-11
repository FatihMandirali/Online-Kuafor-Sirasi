using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeefKuaforSiram.Core.Domain.Modeller.KuaforAdminModel
{
    public class KuaforHizliSiraRequest
    {
        public int id { get; set; }

        public string tarih { get; set; }

        public int eleman { get; set; }

        public List<int> saatAraligi { get; set; }
    }
}