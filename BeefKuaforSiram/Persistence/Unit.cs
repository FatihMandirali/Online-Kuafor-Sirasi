using BeefKuaforSiram.Core;
using BeefKuaforSiram.Core.Domain;
using BeefKuaforSiram.Core.Repositories;
using BeefKuaforSiram.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeefKuaforSiram.Persistence
{
    public class Unit : IUnitOfWork
    {
        private readonly PlutoContext _context;
        public Unit(PlutoContext context)
        {
            _context = context;
            KuaforAktiflik = new KuaforAktiflikRepository(_context);
            KuaforAnketCevap = new KuaforAnketCevapRepository(_context);
            KuaforAnket = new KuaforAnketRepository(_context);
            KuaforElemanlari = new KuaforElemanlariRepository(_context);
            KuaforFirsat = new KuaforFirsatRepository(_context);
            Kuaforler = new KuaforlerRepository(_context);
            KuaforMesaj = new KuaforMesajRepository(_context);
            KuaforPuan = new KuaforPuanRepository(_context);
            KuaforSaatleri = new KuaforSaatleriRepository(_context);
            KuaforSahip = new KuaforSahipRepository(_context);
            KuaforSira = new KuaforSiraRepository(_context);
            KuaforTrasCesitleri = new KuaforTrasCesitleriRepository(_context);
            KuaforTrasSaatiAralik = new KuaforTrasSaatiAralikRepository(_context);
            KuaforYorum = new KuaforYorumRepository(_context);
            KullaniciCuzdan = new KullaniciCuzdanRepository(_context);
            KullaniciFavorileri = new KullaniciFavorileriRepository(_context);
            KullaniciIslemleri = new KullaniciIslemleriRepository(_context);
            Kullanici = new KullaniciRepository(_context);
            KullaniciRozet = new KullaniciRozetRepository(_context);
            Rozetler = new RozetlerRepository(_context);
            YeniEklenenKuaforler = new YeniEklenenKuaforlerRepository(_context);
            Yonetici = new YoneticiRepository(_context);
        }
        public IKuaforAktiflikRepository KuaforAktiflik { get; private set; }
        public IKuaforAnketCevapRepository KuaforAnketCevap { get; private set; }
        public IKuaforAnketRepository KuaforAnket { get; private set; }
        public IKuaforElemanlariRepository KuaforElemanlari { get; private set; }
        public IKuaforFirsatRepository KuaforFirsat { get; private set; }
        public IKuaforlerRepository Kuaforler { get; private set; }
        public IKuaforMesajRepository KuaforMesaj { get; private set; }
        public IKuaforPuanRepository KuaforPuan { get; private set; }
        public IKuaforSaatleriRepository KuaforSaatleri { get; private set; }
        public IKuaforSahipRepository KuaforSahip { get; private set; }
        public IKuaforSiraRepository KuaforSira { get; private set; }
        public IKuaforTrasCesitleriRepository KuaforTrasCesitleri { get; private set; }
        public IKuaforTrasSaatiAralikRepository KuaforTrasSaatiAralik { get; private set; }
        public IKuaforYorumRepository KuaforYorum { get; private set; }
        public IKullaniciCuzdanRepository KullaniciCuzdan { get; private set; }
        public IKullaniciFavorileriRepository KullaniciFavorileri { get; private set; }
        public IKullaniciIslemleriRepository KullaniciIslemleri { get; private set; }
        public IKullaniciRepository Kullanici { get; private set; }
        public IKullaniciRozetRepository KullaniciRozet { get; private set; }
        public IRozetlerRepository Rozetler { get; private set; }
        public IYeniEklenenKuaforlerRepository YeniEklenenKuaforler { get; private set; }
        public IYoneticiRepository Yonetici { get; private set; }
        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        // <identity impersonate="false" />
        // <trust level = "Full" originUrl="" />
        // <customErrors mode = "On" >
    }
}