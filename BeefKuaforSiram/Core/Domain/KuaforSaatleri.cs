using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BeefKuaforSiram.Core.Domain
{
    [Table("KuaforSaatleri")]
    public class KuaforSaatleri
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("KuaforId")]
        public int KuaforIdi { get; set; }
        public virtual Kuaforler KuaforId { get; set; }

        [DisplayName("Açılma Saati"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public string AcilmaSaati { get; set; }

        [DisplayName("Kapanma Saati"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public string KapanmaSaati { get; set; }

        // 
        [DisplayName("Ortalama Traş Zamanı"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public string Aralik { get; set; }
    }
}