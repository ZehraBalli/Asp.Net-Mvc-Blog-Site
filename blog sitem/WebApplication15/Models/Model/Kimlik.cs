using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication15.Models.Model
{
    [Table("Kimlik")]
    public class Kimlik
    {   
        [Key]
        public int KimlikID {get;set;}
        [DisplayName("Site Başlık")]
        [Required, StringLength(100, ErrorMessage ="100 karakter giriniz.")]
        public string Title { get; set; }
        [DisplayName("Anahtar Kelimeler")]
        [Required, StringLength(100, ErrorMessage = "100 karakter giriniz.")]
        public string Keywords { get; set; }
        [DisplayName("Site Açıklama")]
        [Required, StringLength(300, ErrorMessage = "300 karakter giriniz.")]
        public string Description { get; set; }
        [DisplayName("Site Logo")]
        public string LogoURL { get; set; }
        [DisplayName("Site Ünvan")]
        public string Unvan { get; set; }
    }
}