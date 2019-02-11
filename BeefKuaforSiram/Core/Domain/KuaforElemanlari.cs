using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BeefKuaforSiram.Core.Domain
{
    [Table("KuaforElemanlari")]
    public class KuaforElemanlari
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("KuaforId")]
        public int KuaforIdi { get; set; }
        public virtual Kuaforler KuaforId { get; set; }

        [DisplayName("Traş Çeşiti"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public string Adi { get; set; }

        [DisplayName("Fiyatı"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public string Soyadi { get; set; }


        [DisplayName("Tc"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public string Tc { get; set; }

        [DisplayName("Telefon"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public string Telefon { get; set; }

        [DisplayName("Mail"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public string Mail { get; set; }

    }
}