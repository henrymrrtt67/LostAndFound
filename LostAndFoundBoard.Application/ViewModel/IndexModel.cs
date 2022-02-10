using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostAndFoundBoard.Application.ViewModel
{
    public class IndexModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Descrpition { get; set; }
        public string Category { get; set; }
        public bool IsFound { get; set; }
    }
}
