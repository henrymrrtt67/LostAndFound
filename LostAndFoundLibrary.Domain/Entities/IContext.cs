using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostAndFoundLibrary.Domain.Entities
{
    public interface IContext
    {
        DbSet<Category> Category { get; set; }
        DbSet<ContactPerson> ContactPersons { get; set; }
        DbSet<Item> Item { get; set; }
        int SaveChanges();
    }

}
