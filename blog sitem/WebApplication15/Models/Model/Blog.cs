using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication15.Models.Model
{
    [Table("Blog")]
    public class Blog
    {
        [Key]
        public int BlogID { get; set; }
        public string Baslik { get; set; }
        public string İcerik { get; set; }
        public string ResimURL { get; set; }
        public int? KategoriID { get; set; }
        public Kategori Kategori{ get; set; }
        
    }
}