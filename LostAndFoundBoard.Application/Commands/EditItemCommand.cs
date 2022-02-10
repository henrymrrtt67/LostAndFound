using LostAndFoundBoard.Application.Enums;
using LostAndFoundBoard.Application.Requests;
using LostAndFoundLibrary.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LostAndFoundBoard.Application.Commands
{
    public class EditItemCommand: IRequestHandler<EditItemCommandRequest, EntityEntry>
    {
        private IContext _context;
        public EditItemCommand(IContext context)
        {
            _context = context;
        }

        public async Task<EntityEntry> Handle(EditItemCommandRequest request, CancellationToken cancellationToken)
        {
            var result = _context.Item.Update(new Item
            {
                Id = request.ViewModel.Id,
                Title = request.ViewModel.Title,
                Description = request.ViewModel.Description,
                IsFound = false,
                ContactPerson = new ContactPerson
                {
                    FullName = request.ViewModel.ContactPersonFullName,
                    PhoneNumber = request.ViewModel.ContactPersonPhoneNumber
                },
                Category = new Category
                {
                    Description = MappingExtensions.EnumToCode(request.ViewModel.Category)
                }
            });
            _context.SaveChanges();
            return result;
        }
    }
}
