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
    
    public partial class sp_obtenerFacturacionId_Result
    {
        public int facturacionId { get; set; }
        public string nombre { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public string descripcion { get; set; }
        public Nullable<int> impuesto { get; set; }
        public Nullable<double> subtotal { get; set; }
        public Nullable<double> total { get; set; }
        public string tipo { get; set; }
        public Nullable<int> id_estado { get; set; }
    }
}
