using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BeefKuaforSiram.Core.Domain
{
    [Table("KuaforAktiflik")]
    public class KuaforAktiflik
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("KuaforId")]
        public int KuaforIdi { get; set; }
        public virtual Kuaforler KuaforId { get; set; }

        [DisplayName("Aktiflik"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public bool Aktiflik { get; set; } = true;

        [DisplayName("Sebep"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public string Sebep { get; set; }
    }
}