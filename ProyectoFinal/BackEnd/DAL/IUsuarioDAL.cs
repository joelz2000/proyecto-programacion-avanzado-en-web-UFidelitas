﻿using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public interface IUsuarioDAL
    {
        bool agregarUsuario(sp_obtenerUsuarios_Result sp_ObtenerUsuarios_Result);

        List<sp_obtenerUsuarios_Result> obtenerUsuarios();

        sp_obtenerUsuariosId_Result obtenerUsuarioById(int id);

        bool actualizarUsuario(sp_obtenerUsuarios_Result sp_ObtenerUsuarios_Result);

        bool eliminarUsuario(int id);

        bool agregarRolUsuario(sp_ObtenerRolesUser_Result usuario);

        bool actualizarRolUsuario(int rolIdActual, int userId, int rolIdNueva, int idEstado);

        List<sp_ObtenerRolesUser_Result>obtenerRolesUsuario();

        sp_obtenerRolUserId_Result obtenerRolUsuarioById(int id);
    }
}
