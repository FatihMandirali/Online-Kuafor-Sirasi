using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeefKuaforSiram.Core.Domain.Modeller.YoneticiAdminModel
{
    public class GorevlerRequest
    {
        public string gorevAdi{ get; set; }
        public int tamamlanmaAdet { get; set; }
        public int id { get; set; }
        public int basariPuani { get; set; }
    }
}