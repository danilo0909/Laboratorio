using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Laboratorio.Models;

namespace Laboratorio.Data
{
    public class DBContext : DbContext
    {
        public DBContext (DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public DbSet<Laboratorio.Models.Cadastro_Cliente> Cadastro_Cliente { get; set; } = default!;

        public DbSet<Laboratorio.Models.Cadastro_Maquina> Cadastro_Maquina { get; set; } = default!;

        public DbSet<Laboratorio.Models.Inventario> Inventario { get; set; } = default!;
    }
}
