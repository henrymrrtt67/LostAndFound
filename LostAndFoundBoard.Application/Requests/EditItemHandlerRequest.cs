using LostAndFoundBoard.Application.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostAndFoundBoard.Application.Requests
{
    public class EditItemHandlerRequest : IRequest<EditItemViewModel>
    {
        public int Id { get; set; }
    }
}
