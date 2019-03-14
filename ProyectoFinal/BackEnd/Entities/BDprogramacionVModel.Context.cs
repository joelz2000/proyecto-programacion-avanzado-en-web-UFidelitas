﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BackEnd.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
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
        public virtual DbSet<usuarios> usuarios { get; set; }
        public virtual DbSet<usuarios_promocion> usuarios_promocion { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    
        public virtual int sp_actualizarRol(Nullable<int> pId, string pNombre, string pDescripcion)
        {
            var pIdParameter = pId.HasValue ?
                new ObjectParameter("pId", pId) :
                new ObjectParameter("pId", typeof(int));
    
            var pNombreParameter = pNombre != null ?
                new ObjectParameter("pNombre", pNombre) :
                new ObjectParameter("pNombre", typeof(string));
    
            var pDescripcionParameter = pDescripcion != null ?
                new ObjectParameter("pDescripcion", pDescripcion) :
                new ObjectParameter("pDescripcion", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_actualizarRol", pIdParameter, pNombreParameter, pDescripcionParameter);
        }
    
        public virtual int sp_actualizarRolesUser(Nullable<int> idRolOriginal, Nullable<int> idUser, Nullable<int> idRolNueva)
        {
            var idRolOriginalParameter = idRolOriginal.HasValue ?
                new ObjectParameter("idRolOriginal", idRolOriginal) :
                new ObjectParameter("idRolOriginal", typeof(int));
    
            var idUserParameter = idUser.HasValue ?
                new ObjectParameter("idUser", idUser) :
                new ObjectParameter("idUser", typeof(int));
    
            var idRolNuevaParameter = idRolNueva.HasValue ?
                new ObjectParameter("idRolNueva", idRolNueva) :
                new ObjectParameter("idRolNueva", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_actualizarRolesUser", idRolOriginalParameter, idUserParameter, idRolNuevaParameter);
        }
    
        public virtual int sp_actualizarUsuario(Nullable<int> pUsuarioId, string pNombre, string pApellidos, string pContrasena, string pCorreoElectronico, Nullable<System.DateTime> pFechaNacimiento, string pGenero, string pFotoPerfil, Nullable<int> pTelefono, string pDireccion, Nullable<int> pPaisId, Nullable<int> pDistritoId, Nullable<int> pProvinciaId, Nullable<int> pCantonId)
        {
            var pUsuarioIdParameter = pUsuarioId.HasValue ?
                new ObjectParameter("pUsuarioId", pUsuarioId) :
                new ObjectParameter("pUsuarioId", typeof(int));
    
            var pNombreParameter = pNombre != null ?
                new ObjectParameter("pNombre", pNombre) :
                new ObjectParameter("pNombre", typeof(string));
    
            var pApellidosParameter = pApellidos != null ?
                new ObjectParameter("pApellidos", pApellidos) :
                new ObjectParameter("pApellidos", typeof(string));
    
            var pContrasenaParameter = pContrasena != null ?
                new ObjectParameter("pContrasena", pContrasena) :
                new ObjectParameter("pContrasena", typeof(string));
    
            var pCorreoElectronicoParameter = pCorreoElectronico != null ?
                new ObjectParameter("pCorreoElectronico", pCorreoElectronico) :
                new ObjectParameter("pCorreoElectronico", typeof(string));
    
            var pFechaNacimientoParameter = pFechaNacimiento.HasValue ?
                new ObjectParameter("pFechaNacimiento", pFechaNacimiento) :
                new ObjectParameter("pFechaNacimiento", typeof(System.DateTime));
    
            var pGeneroParameter = pGenero != null ?
                new ObjectParameter("pGenero", pGenero) :
                new ObjectParameter("pGenero", typeof(string));
    
            var pFotoPerfilParameter = pFotoPerfil != null ?
                new ObjectParameter("pFotoPerfil", pFotoPerfil) :
                new ObjectParameter("pFotoPerfil", typeof(string));
    
            var pTelefonoParameter = pTelefono.HasValue ?
                new ObjectParameter("pTelefono", pTelefono) :
                new ObjectParameter("pTelefono", typeof(int));
    
            var pDireccionParameter = pDireccion != null ?
                new ObjectParameter("pDireccion", pDireccion) :
                new ObjectParameter("pDireccion", typeof(string));
    
            var pPaisIdParameter = pPaisId.HasValue ?
                new ObjectParameter("pPaisId", pPaisId) :
                new ObjectParameter("pPaisId", typeof(int));
    
            var pDistritoIdParameter = pDistritoId.HasValue ?
                new ObjectParameter("pDistritoId", pDistritoId) :
                new ObjectParameter("pDistritoId", typeof(int));
    
            var pProvinciaIdParameter = pProvinciaId.HasValue ?
                new ObjectParameter("pProvinciaId", pProvinciaId) :
                new ObjectParameter("pProvinciaId", typeof(int));
    
            var pCantonIdParameter = pCantonId.HasValue ?
                new ObjectParameter("pCantonId", pCantonId) :
                new ObjectParameter("pCantonId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_actualizarUsuario", pUsuarioIdParameter, pNombreParameter, pApellidosParameter, pContrasenaParameter, pCorreoElectronicoParameter, pFechaNacimientoParameter, pGeneroParameter, pFotoPerfilParameter, pTelefonoParameter, pDireccionParameter, pPaisIdParameter, pDistritoIdParameter, pProvinciaIdParameter, pCantonIdParameter);
        }
    
        public virtual int sp_agregarFacturacion(string pNombre, Nullable<System.DateTime> pfecha, string pDescripcion, Nullable<int> pImpuesto, string pTipo, Nullable<int> pCantidad, Nullable<int> pProductId, Nullable<int> pUsuario)
        {
            var pNombreParameter = pNombre != null ?
                new ObjectParameter("pNombre", pNombre) :
                new ObjectParameter("pNombre", typeof(string));
    
            var pfechaParameter = pfecha.HasValue ?
                new ObjectParameter("pfecha", pfecha) :
                new ObjectParameter("pfecha", typeof(System.DateTime));
    
            var pDescripcionParameter = pDescripcion != null ?
                new ObjectParameter("pDescripcion", pDescripcion) :
                new ObjectParameter("pDescripcion", typeof(string));
    
            var pImpuestoParameter = pImpuesto.HasValue ?
                new ObjectParameter("pImpuesto", pImpuesto) :
                new ObjectParameter("pImpuesto", typeof(int));
    
            var pTipoParameter = pTipo != null ?
                new ObjectParameter("pTipo", pTipo) :
                new ObjectParameter("pTipo", typeof(string));
    
            var pCantidadParameter = pCantidad.HasValue ?
                new ObjectParameter("pCantidad", pCantidad) :
                new ObjectParameter("pCantidad", typeof(int));
    
            var pProductIdParameter = pProductId.HasValue ?
                new ObjectParameter("pProductId", pProductId) :
                new ObjectParameter("pProductId", typeof(int));
    
            var pUsuarioParameter = pUsuario.HasValue ?
                new ObjectParameter("pUsuario", pUsuario) :
                new ObjectParameter("pUsuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_agregarFacturacion", pNombreParameter, pfechaParameter, pDescripcionParameter, pImpuestoParameter, pTipoParameter, pCantidadParameter, pProductIdParameter, pUsuarioParameter);
        }
    
        public virtual int sp_agregarRol(string pNombre, string pDescripcion)
        {
            var pNombreParameter = pNombre != null ?
                new ObjectParameter("pNombre", pNombre) :
                new ObjectParameter("pNombre", typeof(string));
    
            var pDescripcionParameter = pDescripcion != null ?
                new ObjectParameter("pDescripcion", pDescripcion) :
                new ObjectParameter("pDescripcion", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_agregarRol", pNombreParameter, pDescripcionParameter);
        }
    
        public virtual int sp_agregarRolUser(Nullable<int> pRolId, Nullable<int> pUserId)
        {
            var pRolIdParameter = pRolId.HasValue ?
                new ObjectParameter("pRolId", pRolId) :
                new ObjectParameter("pRolId", typeof(int));
    
            var pUserIdParameter = pUserId.HasValue ?
                new ObjectParameter("pUserId", pUserId) :
                new ObjectParameter("pUserId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_agregarRolUser", pRolIdParameter, pUserIdParameter);
        }
    
        public virtual ObjectResult<Nullable<bool>> sp_agregarUsuario(string pNombre, string pApellidos, string pContrasena, string pCorreoElectronico, Nullable<System.DateTime> pFechaNacimiento, string pGenero, string pFotoPerfil, Nullable<int> pTelefono, string pDireccion, Nullable<int> pPaisId, Nullable<int> pDistritoId, Nullable<int> pProvinciaId, Nullable<int> pCantonId)
        {
            var pNombreParameter = pNombre != null ?
                new ObjectParameter("pNombre", pNombre) :
                new ObjectParameter("pNombre", typeof(string));
    
            var pApellidosParameter = pApellidos != null ?
                new ObjectParameter("pApellidos", pApellidos) :
                new ObjectParameter("pApellidos", typeof(string));
    
            var pContrasenaParameter = pContrasena != null ?
                new ObjectParameter("pContrasena", pContrasena) :
                new ObjectParameter("pContrasena", typeof(string));
    
            var pCorreoElectronicoParameter = pCorreoElectronico != null ?
                new ObjectParameter("pCorreoElectronico", pCorreoElectronico) :
                new ObjectParameter("pCorreoElectronico", typeof(string));
    
            var pFechaNacimientoParameter = pFechaNacimiento.HasValue ?
                new ObjectParameter("pFechaNacimiento", pFechaNacimiento) :
                new ObjectParameter("pFechaNacimiento", typeof(System.DateTime));
    
            var pGeneroParameter = pGenero != null ?
                new ObjectParameter("pGenero", pGenero) :
                new ObjectParameter("pGenero", typeof(string));
    
            var pFotoPerfilParameter = pFotoPerfil != null ?
                new ObjectParameter("pFotoPerfil", pFotoPerfil) :
                new ObjectParameter("pFotoPerfil", typeof(string));
    
            var pTelefonoParameter = pTelefono.HasValue ?
                new ObjectParameter("pTelefono", pTelefono) :
                new ObjectParameter("pTelefono", typeof(int));
    
            var pDireccionParameter = pDireccion != null ?
                new ObjectParameter("pDireccion", pDireccion) :
                new ObjectParameter("pDireccion", typeof(string));
    
            var pPaisIdParameter = pPaisId.HasValue ?
                new ObjectParameter("pPaisId", pPaisId) :
                new ObjectParameter("pPaisId", typeof(int));
    
            var pDistritoIdParameter = pDistritoId.HasValue ?
                new ObjectParameter("pDistritoId", pDistritoId) :
                new ObjectParameter("pDistritoId", typeof(int));
    
            var pProvinciaIdParameter = pProvinciaId.HasValue ?
                new ObjectParameter("pProvinciaId", pProvinciaId) :
                new ObjectParameter("pProvinciaId", typeof(int));
    
            var pCantonIdParameter = pCantonId.HasValue ?
                new ObjectParameter("pCantonId", pCantonId) :
                new ObjectParameter("pCantonId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<bool>>("sp_agregarUsuario", pNombreParameter, pApellidosParameter, pContrasenaParameter, pCorreoElectronicoParameter, pFechaNacimientoParameter, pGeneroParameter, pFotoPerfilParameter, pTelefonoParameter, pDireccionParameter, pPaisIdParameter, pDistritoIdParameter, pProvinciaIdParameter, pCantonIdParameter);
        }
    
        public virtual int sp_deleteRol(Nullable<int> pRolId)
        {
            var pRolIdParameter = pRolId.HasValue ?
                new ObjectParameter("pRolId", pRolId) :
                new ObjectParameter("pRolId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_deleteRol", pRolIdParameter);
        }
    
        public virtual int sp_eliminarUsuario(Nullable<int> pUserId)
        {
            var pUserIdParameter = pUserId.HasValue ?
                new ObjectParameter("pUserId", pUserId) :
                new ObjectParameter("pUserId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_eliminarUsuario", pUserIdParameter);
        }
    
        public virtual ObjectResult<sp_obtenerFacturaciones_Result> sp_obtenerFacturaciones()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_obtenerFacturaciones_Result>("sp_obtenerFacturaciones");
        }
    
        public virtual ObjectResult<sp_obtenerFacturacionesProducto_Result> sp_obtenerFacturacionesProducto(Nullable<int> pId)
        {
            var pIdParameter = pId.HasValue ?
                new ObjectParameter("pId", pId) :
                new ObjectParameter("pId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_obtenerFacturacionesProducto_Result>("sp_obtenerFacturacionesProducto", pIdParameter);
        }
    
        public virtual ObjectResult<sp_obtenerFacturacionesUsuario_Result> sp_obtenerFacturacionesUsuario(Nullable<int> pId)
        {
            var pIdParameter = pId.HasValue ?
                new ObjectParameter("pId", pId) :
                new ObjectParameter("pId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_obtenerFacturacionesUsuario_Result>("sp_obtenerFacturacionesUsuario", pIdParameter);
        }
    
        public virtual ObjectResult<sp_obtenerFacturacionId_Result> sp_obtenerFacturacionId(Nullable<int> pId)
        {
            var pIdParameter = pId.HasValue ?
                new ObjectParameter("pId", pId) :
                new ObjectParameter("pId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_obtenerFacturacionId_Result>("sp_obtenerFacturacionId", pIdParameter);
        }
    
        public virtual ObjectResult<sp_obtenerRoles_Result> sp_obtenerRoles()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_obtenerRoles_Result>("sp_obtenerRoles");
        }
    
        public virtual ObjectResult<sp_ObtenerRolesUser_Result> sp_ObtenerRolesUser()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_ObtenerRolesUser_Result>("sp_ObtenerRolesUser");
        }
    
        public virtual ObjectResult<sp_obtenerRolId_Result> sp_obtenerRolId(Nullable<int> pId)
        {
            var pIdParameter = pId.HasValue ?
                new ObjectParameter("pId", pId) :
                new ObjectParameter("pId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_obtenerRolId_Result>("sp_obtenerRolId", pIdParameter);
        }
    
        public virtual ObjectResult<sp_obtenerRolUserId_Result> sp_obtenerRolUserId(Nullable<int> idUser)
        {
            var idUserParameter = idUser.HasValue ?
                new ObjectParameter("idUser", idUser) :
                new ObjectParameter("idUser", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_obtenerRolUserId_Result>("sp_obtenerRolUserId", idUserParameter);
        }
    
        public virtual ObjectResult<sp_obtenerUsuarios_Result> sp_obtenerUsuarios()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_obtenerUsuarios_Result>("sp_obtenerUsuarios");
        }
    
        public virtual ObjectResult<sp_obtenerUsuariosId_Result> sp_obtenerUsuariosId(Nullable<int> pUsuarioId)
        {
            var pUsuarioIdParameter = pUsuarioId.HasValue ?
                new ObjectParameter("pUsuarioId", pUsuarioId) :
                new ObjectParameter("pUsuarioId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_obtenerUsuariosId_Result>("sp_obtenerUsuariosId", pUsuarioIdParameter);
        }
    
        public virtual ObjectResult<sp_obtenerImagenProducto_Result> sp_obtenerImagenProducto(Nullable<int> pIdProducto, string pImagen)
        {
            var pIdProductoParameter = pIdProducto.HasValue ?
                new ObjectParameter("pIdProducto", pIdProducto) :
                new ObjectParameter("pIdProducto", typeof(int));
    
            var pImagenParameter = pImagen != null ?
                new ObjectParameter("pImagen", pImagen) :
                new ObjectParameter("pImagen", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_obtenerImagenProducto_Result>("sp_obtenerImagenProducto", pIdProductoParameter, pImagenParameter);
        }
    
        public virtual ObjectResult<sp_obtenerImagenesProductoId_Result> sp_obtenerImagenesProductoId(Nullable<int> pIdProducto)
        {
            var pIdProductoParameter = pIdProducto.HasValue ?
                new ObjectParameter("pIdProducto", pIdProducto) :
                new ObjectParameter("pIdProducto", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_obtenerImagenesProductoId_Result>("sp_obtenerImagenesProductoId", pIdProductoParameter);
        }
    }
}
