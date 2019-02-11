using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BeefKuaforSiram.Core.Domain
{
    [Table("KuaforFirsat")]
    public class KuaforFirsat
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("KuaforId")]
        public int KuaforIdi { get; set; }
        public virtual Kuaforler KuaforId { get; set; }

        [DisplayName("Fırsat İçerik"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public string FirsatIcerik { get; set; }

        [DisplayName("Fırsat Yayın Tarih"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public DateTime FirsatYayinTarih { get; set; }

        [DisplayName("Yönetici Onayı"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public int YoneticiOnayi { get; set; } = 3;
    }
}