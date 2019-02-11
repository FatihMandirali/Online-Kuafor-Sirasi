using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BeefKuaforSiram.Core.Domain
{
    [Table("Rozetler")]
    public class Rozetler
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("Rozet Adı"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public string RozetAdi { get; set; }

        [DisplayName("Resim"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public string Resim { get; set; }
    }
}