using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BeefKuaforSiram.Core.Domain
{
    [Table("KuaforSira")]
    public class KuaforSira
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("KuaforId")]
        public int KuaforIdi { get; set; }
        public virtual Kuaforler KuaforId { get; set; }

        [DisplayName("Kuaför Çeşit Adı"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public string KuaforCesitAdi { get; set; }//burda hata vermişti o yüzden string yaptım

        [DisplayName("Tarih"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public string Tarih { get; set; }


        [DisplayName("Başlama Saati"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public string KuaforSaatAralik { get; set; }

        //[DisplayName("Bitiş Saati"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        //public string BitisSaati { get; set; }

        [ForeignKey("KullaniciId")]
        public int KullaniciIdi { get; set; }
        public virtual Kullanici KullaniciId { get; set; }

        [DisplayName("Kuaför Elemanları Adı Soyadı"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public string KuaforElemanlariAdiSoyadi { get; set; }//burda hata vermişti o yüzden string yaptım

        [DisplayName("Sıra Durumu"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public bool SiraDurum { get; set; } = false;

        [DisplayName("Tamamlanma Durumu"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public bool TamamlanmaDurum { get; set; } = false;
    }
}