using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BeefKuaforSiram.Core.Domain
{
    [Table("Kuaforler")]
    public class Kuaforler
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("Ad"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public string Ad { get; set; }

        [DisplayName("Sehir"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public string Sehir { get; set; }

        [DisplayName("Semt"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public string Semt { get; set; }

        [DisplayName("Adres"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public string Adres { get; set; }

        [DisplayName("EMail"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public string EMail { get; set; }

        [DisplayName("Resim"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public string Resim { get; set; }

        [DisplayName("Telefon"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public string Telefon { get; set; }

        [DisplayName("Eklenme Tarihi"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public DateTime EklenmeTarihi { get; set; }

        [ForeignKey("KuaforSahipId")]
        public int KuaforSahipIdi { get; set; }     
        public virtual KuaforSahip KuaforSahipId { get; set; }

        //----------

        [DisplayName("Puan")]
        public int Puan { get; set; }

        [DisplayName("Bay Bayan"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public int BayBayan { get; set; }

        [DisplayName("Slug"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public string Slug { get; set; }

        [DisplayName("Açılma Saati"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public string AcilmaSaati { get; set; }

        [DisplayName("Kapanma Saati"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public string KapanmaSaati { get; set; }

        [DisplayName("Ortalama Traş Zamanı"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public string Aralik { get; set; }

    }
}