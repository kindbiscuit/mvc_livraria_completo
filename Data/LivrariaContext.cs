using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Livraria.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Livraria.Data
{
    public class LivrariaContext : IdentityDbContext
    {
       public LivrariaContext(DbContextOptions<LivrariaContext> options): base(options) 
        {
            
        }
        public DbSet<Livros> livros { get; set; }
        public DbSet<Pedidos> pedidos { get; set; }
        public DbSet<Funcionarios> funcionarios { get; set; }
       
        
    }
}
