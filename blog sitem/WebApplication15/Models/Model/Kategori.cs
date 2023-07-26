using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication15.Models.Model
{ 
    [Table("Kategori")]
    public class Kategori
    {
        [Key]
        public int KategoriID { get; set; }
        [Required, StringLength(50, ErrorMessage ="50 karakter giriniz")]
        public string KategoriAd { get; set; }
        public string Aciklama { get; set; }
        public ICollection<Blog> Blogs { get; set; }
    }
}