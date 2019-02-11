using BeefKuaforSiram.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeefKuaforSiram.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IKullaniciRepository Kullanici { get; }
        IKuaforAktiflikRepository KuaforAktiflik { get; }
        IKuaforAnketCevapRepository KuaforAnketCevap { get; }
        IKuaforAnketRepository KuaforAnket { get; }
        IKuaforElemanlariRepository KuaforElemanlari { get; }
        IKuaforFirsatRepository KuaforFirsat { get; }
        IKuaforlerRepository Kuaforler { get; }
        IKuaforMesajRepository KuaforMesaj { get; }
        IKuaforPuanRepository KuaforPuan { get; }
        IKuaforSaatleriRepository KuaforSaatleri { get; }
        IKuaforSahipRepository KuaforSahip { get; }
        IKuaforSiraRepository KuaforSira { get; }
        IKuaforTrasCesitleriRepository KuaforTrasCesitleri { get; }
        IKuaforTrasSaatiAralikRepository KuaforTrasSaatiAralik { get; }
        IKuaforYorumRepository KuaforYorum { get; }
        IKullaniciCuzdanRepository KullaniciCuzdan { get; }
        IKullaniciFavorileriRepository KullaniciFavorileri { get; }
        IKullaniciIslemleriRepository KullaniciIslemleri { get; }
        IKullaniciRozetRepository KullaniciRozet { get; }
        IRozetlerRepository Rozetler { get; }
        IYeniEklenenKuaforlerRepository YeniEklenenKuaforler { get; }
        IYoneticiRepository Yonetici { get; }
        int Complete();
    }
}