using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeefKuaforSiram.Core.Domain.Modeller.KuaforAdminModel
{
    public class MessagesRequest
    {
        public int kuaforId { get; set; }
        public int kullaniciId { get; set; }
    }
}