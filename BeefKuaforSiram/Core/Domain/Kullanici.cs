using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BeefKuaforSiram.Core.Domain
{
    [Table("Kullanici")]
    public class Kullanici
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("Ad"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public string Ad { get; set; }

        [DisplayName("Soyad"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public string Soyad { get; set; }

        [DisplayName("Email"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public string Email { get; set; }

        [DisplayName("Kullanıcı Adı"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public string KullaniciAdi { get; set; }

        [DisplayName("Şifre"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public string Sifre { get; set; }

        [DisplayName("Sehir"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public string Sehir { get; set; }

        [DisplayName("Semt"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public string Semt { get; set; }

        [DisplayName("Telefon"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public string Telefon { get; set; }

      //  [DisplayName("Doğum Tarihi"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
      //  public DateTime DogumTarihi { get; set; }

        //--
        [DisplayName("Slug"), Required(ErrorMessage = "Lütfen Bu Alanı Boş Bırakmayın.")]
        public string Slug { get; set; }

        [DisplayName("Avatar")]
        public string Avatar { get; set; }

    }
}