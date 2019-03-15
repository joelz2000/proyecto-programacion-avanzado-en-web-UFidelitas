using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public interface IImagenProductoDAL
    {
        sp_obtenerImagenProducto_Result obtenerImagenProducto(int idProducto, string imagen);

        List<sp_obtenerImagenesProductoId_Result> obtenerImagenesProductoId(int idProducto);

    }
}
