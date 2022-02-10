using LostAndFoundBoard.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostAndFoundBoard.Application.ViewModel
{
    public class EditItemViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ContactPersonFullName { get; set; }
        public string ContactPersonPhoneNumber { get; set; }
        public CategoryEnum Category { get; set; }
        public bool IstemFound { get; set; }
    }
}
