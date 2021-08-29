using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp.Models;

namespace TestApp.Data
{
    public class ApplicationDBContext : DbContext
    {
        //Database Confiuration of Dependency Injection to use database anywhere
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options): base(options)
        {

        }

        //Table Name
        public DbSet<CatogaryModel> Catogaries { get; set; }
    }
}
