using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication15.Models.Model
{   
    [Table("Admin")]
    public class Admin
    {   
        [Key]
        public int AdminID { get; set; }
        [Required, StringLength(50, ErrorMessage ="50 karakter olmalıdır.")]
        public string Eposta { get; set; }
        [Required, StringLength(50, ErrorMessage = "50 karakter olmalıdır.")]
        public string Sifre { get; set; }
        public string Yetki { get; set; }
    }
}