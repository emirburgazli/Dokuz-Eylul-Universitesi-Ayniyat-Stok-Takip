﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StokTakipMain.Veritabani
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class İmyoStokTakipEntities1 : DbContext
    {
        public İmyoStokTakipEntities1()
            : base("name=İmyoStokTakipEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Bolum> Bolum { get; set; }
        public DbSet<Kategori> Kategori { get; set; }
        public DbSet<Kullanici> Kullanici { get; set; }
        public DbSet<Personel> Personel { get; set; }
        public DbSet<sysdiagrams> sysdiagrams { get; set; }
        public DbSet<Tip> Tip { get; set; }
        public DbSet<Unvanlar> Unvanlar { get; set; }
        public DbSet<Urun_Hareket> Urun_Hareket { get; set; }
        public DbSet<Urunler> Urunler { get; set; }
    }
}