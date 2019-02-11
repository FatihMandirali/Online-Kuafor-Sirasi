using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BeefKuaforSiram.Core.Domain
{
    [Table("KuaforPuan")]
    public class KuaforPuan
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("KuaforId")]
        public int KuaforIdi { get; set; }
        public virtual Kuaforler KuaforId { get; set; }

        [ForeignKey("KullaniciId")]
        public int KullaniciIdi { get; set; }
        public virtual Kullanici KullaniciId { get; set; }

        [DisplayName("Hız Puan"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public int HizPuan { get; set; }

        [DisplayName("Özen Puan"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public int OzenPuan { get; set; }

        [DisplayName("Kalite Puan"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public int KalitePuan { get; set; }
    }
}