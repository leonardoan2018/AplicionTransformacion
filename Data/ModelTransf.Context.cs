﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BDInfoTransformacionEntities : DbContext
    {
        public BDInfoTransformacionEntities()
            : base("name=BDInfoTransformacionEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<tbAplicacion> tbAplicacion { get; set; }
        public virtual DbSet<tbUsuario> tbUsuario { get; set; }
        public virtual DbSet<tbContenido> tbContenido { get; set; }
        public virtual DbSet<tbTema> tbTema { get; set; }
        public virtual DbSet<tbAdjunto> tbAdjunto { get; set; }
        public virtual DbSet<tbAmbiente> tbAmbiente { get; set; }
        public virtual DbSet<tbCategoriaHD> tbCategoriaHD { get; set; }
        public virtual DbSet<tbGruposInstalacion> tbGruposInstalacion { get; set; }
        public virtual DbSet<tbHojaDatos> tbHojaDatos { get; set; }
        public virtual DbSet<tbItemSubcategoria> tbItemSubcategoria { get; set; }
        public virtual DbSet<tbSubCategoriaHD> tbSubCategoriaHD { get; set; }
        public virtual DbSet<tbApoyoPasoAmbiente> tbApoyoPasoAmbiente { get; set; }
        public virtual DbSet<tbAreaApoyo> tbAreaApoyo { get; set; }
        public virtual DbSet<tbPasoAmbiente> tbPasoAmbiente { get; set; }
    }
}
