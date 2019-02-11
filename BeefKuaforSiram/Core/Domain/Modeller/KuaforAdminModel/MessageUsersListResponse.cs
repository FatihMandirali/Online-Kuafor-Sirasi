using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeefKuaforSiram.Core.Domain.Modeller.KuaforAdminModel
{
    public class MessageUsersListResponse
    {
        public int id { get; set; }
        public string kullaniciAdSoyad { get; set; }
        public int dbId { get; set; }
    }
}