using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostAndFoundLibrary.Domain.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public int ContactPersonId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsFound { get; set; }

        public virtual ContactPerson ContactPerson { get; set; }
        public virtual Category Category { get; set; }
    }
}
