﻿using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class RolDALImpl : IRolDAL
    {
        private BDContext context;
        public bool sp_agregarRol(string nombre, string descripcion)
        {
            try
            {
                using (context = new BDContext())
                {
                    context.sp_agregarRol(nombre, descripcion);
                    context.SaveChanges();
                   
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            
        }
    }
}
