using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication15.Models.Model
{
    [Table("Hizmet")]
    public class Hizmet
    {
        [Key]
        public string HizmetID { get; set; }
        [Required,StringLength(150, ErrorMessage ="150 karakter giriniz")]
        [DisplayName("Hizmet Başlık")]
        public string Baslik { get; set; }
        [DisplayName("Hizmet Açıklama")]
        public string Aciklama { get; set; }

        [DisplayName("Hizmet Resim")]

        public string ResimURL { get; set; }
        
    }
}