using LostAndFoundBoard.Application.ViewModel;
using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostAndFoundBoard.Application.Requests
{
    public class EditItemCommandRequest : IRequest<EntityEntry>
    {
        public EditItemViewModel ViewModel { get; set; }
    }
}
