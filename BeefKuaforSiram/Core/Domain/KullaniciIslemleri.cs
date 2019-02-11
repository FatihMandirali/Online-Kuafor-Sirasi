using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BeefKuaforSiram.Core.Domain
{
    [Table("KullaniciIslemleri")]
    public class KullaniciIslemleri
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("Kullanıcı Adı Soyadı")]
        public string KullaniciAdSoyad { get; set; }

        [ForeignKey("KuaforSiraId")]
        public int KuaforSiraIdi { get; set; }
        public virtual KuaforSira KuaforSiraId { get; set; }

        [DisplayName("Aktiflik"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public bool Aktiflik { get; set; } = false;
    }
}