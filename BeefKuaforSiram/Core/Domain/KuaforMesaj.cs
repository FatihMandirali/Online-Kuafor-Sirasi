using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BeefKuaforSiram.Core.Domain
{
    [Table("KuaforMesaj")]
    public class KuaforMesaj
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("KuaforId")]
        public int KuaforIdi { get; set; }
        public virtual Kuaforler KuaforId { get; set; }

        [ForeignKey("KullaniciId")]
        public int KullaniciIdi { get; set; }
        public virtual Kullanici KullaniciId { get; set; }

        [DisplayName("Mesaj"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public string Mesaj { get; set; }

        [DisplayName("Kullanıcı"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public bool Kullanici { get; set; } = true;

        [DisplayName("Yönetici"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public bool Yonetici { get; set; } = true;

        [DisplayName("Yönetici Durum"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public bool YoneticiDurum { get; set; } = true;

        [DisplayName("Kullanıcı Durum"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public bool KullaniciDurum { get; set; } = true;
    }
}