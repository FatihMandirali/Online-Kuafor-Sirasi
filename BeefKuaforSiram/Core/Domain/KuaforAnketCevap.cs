using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BeefKuaforSiram.Core.Domain
{
    [Table("KuaforAnketCevap")]
    public class KuaforAnketCevap
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("KuaforAnketId")]
        public int KuaforAnketIdi { get; set; }
        public virtual KuaforAnket KuaforAnketId { get; set; }

        [ForeignKey("KullaniciId")]
        public int KullaniciIdi { get; set; }
        public virtual Kullanici KullaniciId { get; set; }

        [DisplayName("Fırsat Yayın Tarih"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public string Cevap { get; set; }
    }
}