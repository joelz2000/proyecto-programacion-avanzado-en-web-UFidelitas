﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BackEnd.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BDContext : DbContext
    {
        public BDContext()
            : base("name=BDContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Canton> Canton { get; set; }
        public virtual DbSet<categorias> categorias { get; set; }
        public virtual DbSet<colecciones> colecciones { get; set; }
        public virtual DbSet<distribuidor> distribuidor { get; set; }
        public virtual DbSet<Distrito> Distrito { get; set; }
        public virtual DbSet<facturacion_producto> facturacion_producto { get; set; }
        public virtual DbSet<facturaciones> facturaciones { get; set; }
        public virtual DbSet<formas_pago_facturacion> formas_pago_facturacion { get; set; }
        public virtual DbSet<genero_producto> genero_producto { get; set; }
        public virtual DbSet<imagen_producto> imagen_producto { get; set; }
        public virtual DbSet<marcas> marcas { get; set; }
        public virtual DbSet<medida_producto> medida_producto { get; set; }
        public virtual DbSet<Pais> Pais { get; set; }
        public virtual DbSet<productos> productos { get; set; }
        public virtual DbSet<promociones> promociones { get; set; }
        public virtual DbSet<promociones_productos> promociones_productos { get; set; }
        public virtual DbSet<Provincia> Provincia { get; set; }
        public virtual DbSet<rol> rol { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<user> user { get; set; }
        public virtual DbSet<usuarios_promocion> usuarios_promocion { get; set; }
    }
}