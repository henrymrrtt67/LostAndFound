using LostAndFoundLibrary.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostAndFoundBoard.Infrastructure
{
    public class Context : DbContext, IContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {

        }
        public DbSet<Item> Item { get; set; }
        public DbSet<ContactPerson> ContactPersons { get; set; }
        public DbSet<Category> Category { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(@"Data Source=DESKTOP-BCNRBLD\SQLEXPRESS01;Initial Catalog=DESKTOP-BCNRBLD\SQLEXPRESS01;Integrated Security=True;Pooling=False;");
    }
}
