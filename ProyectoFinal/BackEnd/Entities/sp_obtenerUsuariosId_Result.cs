//------------------------------------------------------------------------------
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
    
    public partial class sp_obtenerUsuariosId_Result
    {
        public int userId { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string contrasena { get; set; }
        public string correoElectronico { get; set; }
        public Nullable<System.DateTime> fechaNacimiento { get; set; }
        public string genero { get; set; }
        public string fotoPerfil { get; set; }
        public Nullable<int> telefono { get; set; }
        public string direccion { get; set; }
        public Nullable<int> paisId { get; set; }
        public Nullable<int> distritoId { get; set; }
        public Nullable<int> provinciaId { get; set; }
        public Nullable<int> cantonId { get; set; }
        public string Usuario_ID { get; set; }
        public Nullable<int> id_estado { get; set; }
    }
}
