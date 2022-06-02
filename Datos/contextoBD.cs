using System;
using Microsoft.EntityFrameworkCore;
using CRUD_Autos.Models;

namespace CRUD_Autos.Datos
{
    public class contextoBD: DbContext
    {
        public contextoBD(DbContextOptions<contextoBD> options) : base(options)
        {

        }
    public DbSet<autos> tablaAutos{ get; set; }
    }
}
