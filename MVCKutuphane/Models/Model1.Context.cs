﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCKutuphane.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class KutuphaneDBEntities2 : DbContext
    {
        public KutuphaneDBEntities2()
            : base("name=KutuphaneDBEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblcezalar> tblcezalar { get; set; }
        public virtual DbSet<tblhakkimizda> tblhakkimizda { get; set; }
        public virtual DbSet<tblhareketler> tblhareketler { get; set; }
        public virtual DbSet<tbliletisim> tbliletisim { get; set; }
        public virtual DbSet<tblkasa> tblkasa { get; set; }
        public virtual DbSet<tblkategoriler> tblkategoriler { get; set; }
        public virtual DbSet<tblkitaplar> tblkitaplar { get; set; }
        public virtual DbSet<tblpersoneller> tblpersoneller { get; set; }
        public virtual DbSet<tbluyeler> tbluyeler { get; set; }
        public virtual DbSet<tblyazarlar> tblyazarlar { get; set; }
        public virtual DbSet<tblmesajlar> tblmesajlar { get; set; }
        public virtual DbSet<tblduyurular> tblduyurular { get; set; }
        public virtual DbSet<tbladmin> tbladmin { get; set; }
    
        public virtual ObjectResult<string> EnFazlaKitabiOlanYazar()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("EnFazlaKitabiOlanYazar");
        }
    
        public virtual ObjectResult<EnAktifUye_Result> EnAktifUye()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<EnAktifUye_Result>("EnAktifUye");
        }
    
        public virtual ObjectResult<EnFazlaOkunanKitap_Result> EnFazlaOkunanKitap()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<EnFazlaOkunanKitap_Result>("EnFazlaOkunanKitap");
        }
    
        public virtual ObjectResult<string> EnFazlaOkunanKitap1()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("EnFazlaOkunanKitap1");
        }
    
        public virtual ObjectResult<string> EnAktifUye1()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("EnAktifUye1");
        }
    
        public virtual ObjectResult<string> EnFazlaKitabiOlanYazar1()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("EnFazlaKitabiOlanYazar1");
        }
    
        public virtual ObjectResult<string> EnBasariliPersonel()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("EnBasariliPersonel");
        }
    }
}
