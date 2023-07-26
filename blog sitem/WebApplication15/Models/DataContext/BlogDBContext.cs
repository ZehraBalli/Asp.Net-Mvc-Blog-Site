using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication15.Models.Model;

namespace WebApplication15.Models.DataContext
{
    public class BlogDBContext :DbContext
    {
        public BlogDBContext()  : base("BlogWebDB")
        {

        }
        
        public DbSet<Admin>Admin { get; set; }
        public DbSet<Blog> Blog { get; set; }
        public DbSet<Hakkimizda> Hakkimizda { get; set; }
        public DbSet<Hizmet> Hizmet { get; set; }
        public DbSet<İletisim> İletisim { get; set; }
        public DbSet<Kategori> Kategori { get; set; }
        public DbSet<Kimlik> Kimlik { get; set; }
        public DbSet<Slider> Slider { get; set; }
    }
}