using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication15.Models.Model
{   
    [Table("İletisim")]
    public class İletisim
    { 
        [Key]
        public int İletisimID { get; set; }
        [Required, StringLength(250, ErrorMessage ="250 Karakter giriniz.")]
        public string Adres { get; set; }
        [Required, StringLength(250, ErrorMessage = "250 Karakter giriniz.")]
        public string Telefon { get; set; }
        public string Fax { get; set; }
        public string WhatsApp { get; set; }
        public string FaceBook { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }
    }
}