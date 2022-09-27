using Core.Entities.Form;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrate.Ef.Context
{
    public class FormContext:DbContext
    {
        public FormContext()
        {

        }
        public DbSet<FormType> FormTypes { get; set; }
        public DbSet<FormInfo> FormInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(AppSettings.FormConnectionString);

        }
    }
}
