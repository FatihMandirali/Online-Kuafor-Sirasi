using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BeefKuaforSiram.Core.Domain
{
    [Table("KuaforTrasCesitleri")]
    public class KuaforTrasCesitleri
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("KuaforId")]
        public int KuaforIdi { get; set; }
        public Kuaforler KuaforId { get; set; }

        [DisplayName("Traş Çeşiti"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public string Cesit { get; set; }

        [DisplayName("Fiyatı"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public int Fiyat { get; set; }

        [DisplayName("Dk"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public int Dk { get; set; }
    }
}