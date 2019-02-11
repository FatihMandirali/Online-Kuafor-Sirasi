using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BeefKuaforSiram.Core.Domain
{
    [Table("KuaforTrasSaatiAralik")]
    public class KuaforTrasSaatiAralik
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("KuaforId")]
        public int KuaforIdi { get; set; }
        public virtual Kuaforler KuaforId { get; set; }

        [DisplayName("Başlama Saati"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public string BaslamaSaati { get; set; }

        [DisplayName("Bitiş Saati"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public string BitisSaati { get; set; }

        [DisplayName("ElemanId"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public int ElemanId { get; set; }

        [DisplayName("Doluluk"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public bool Dolu { get; set; }
    }
}