using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BeefKuaforSiram.Core.Domain
{
    [Table("KuaforAnket")]
    public class KuaforAnket
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("Kuaför Id"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public string Soru { get; set; }

        [DisplayName("CevapA"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public string CevapA { get; set; }

        [DisplayName("CevapB"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public string CevapB { get; set; }

        [DisplayName("CevapC"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public string CevapC { get; set; }

        [DisplayName("CevapD"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public string CevapD { get; set; }
    }
}