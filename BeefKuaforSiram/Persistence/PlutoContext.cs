using BeefKuaforSiram.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BeefKuaforSiram.Persistence
{
    public class PlutoContext : DbContext
    {
        public PlutoContext() : base("UnitOfWork")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        
        public virtual DbSet<KuaforAktiflik> KuaforAktiflik { get; set; }
        public virtual DbSet<KuaforAnket> KuaforAnket { get; set; }
        public virtual DbSet<KuaforAnketCevap> KuaforAnketCevap { get; set; }
        public virtual DbSet<KuaforElemanlari> KuaforElemanlari { get; set; }
        public virtual DbSet<KuaforFirsat> KuaforFirsat { get; set; }

        public virtual DbSet<Kuaforler> Kuaforler { get; set; }
        public virtual DbSet<KuaforMesaj> KuaforMesaj { get; set; }
        public virtual DbSet<KuaforPuan> KuaforPuan { get; set; }
        public virtual DbSet<KuaforSaatleri> KuaforSaatleri { get; set; }
        public virtual DbSet<KuaforSahip> KuaforSahip { get; set; }

        public virtual DbSet<KuaforSira> KuaforSira { get; set; }
        public virtual DbSet<KuaforTrasCesitleri> KuaforTrasCesitleri { get; set; }
        public virtual DbSet<KuaforTrasSaatiAralik> KuaforTrasSaatiAralik { get; set; }
        public virtual DbSet<KuaforYorum> KuaforYorum { get; set; }
        public virtual DbSet<Kullanici> Kullanici { get; set; }

        public virtual DbSet<KullaniciCuzdan> KullaniciCuzdan { get; set; }
        public virtual DbSet<KullaniciFavorileri> KullaniciFavorileri { get; set; }
        public virtual DbSet<KullaniciIslemleri> KullaniciIslemleri { get; set; }
        public virtual DbSet<KullaniciRozet> KullaniciRozet { get; set; }
        public virtual DbSet<Rozetler> Rozetler { get; set; }

        public virtual DbSet<YeniEklenenKuaforler> YeniEklenenKuaforler { get; set; }
        public virtual DbSet<Yonetici> Yonetici { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);//olmazsa sebeplerinden birtanesi
        }
    }
}