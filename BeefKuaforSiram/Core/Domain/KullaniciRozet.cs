using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BeefKuaforSiram.Core.Domain
{
    [Table("KullaniciRozet")]
    public class KullaniciRozet
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("KullaniciId")]
        public int KullaniciIdi { get; set; }
        public virtual Kullanici KullaniciId { get; set; }

        [ForeignKey("RozetId")]
        public int RozetIdi { get; set; }
        public virtual Rozetler RozetId { get; set; }
    }
}