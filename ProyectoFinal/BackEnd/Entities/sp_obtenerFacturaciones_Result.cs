//------------------------------------------------------------------------------
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
    
    public partial class sp_obtenerFacturaciones_Result
    {
        public int facturacionId { get; set; }
        public string nombre { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public string descripcion { get; set; }
        public Nullable<int> impuesto { get; set; }
        public Nullable<double> subtotal { get; set; }
        public Nullable<double> total { get; set; }
        public string tipo { get; set; }
    }
}
