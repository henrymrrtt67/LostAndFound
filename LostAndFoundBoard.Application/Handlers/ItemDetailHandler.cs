using LostAndFoundBoard.Application.Enums;
using LostAndFoundBoard.Application.Requests;
using LostAndFoundBoard.Application.ViewModel;
using LostAndFoundLibrary.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace LostAndFoundBoard.Application.Handlers
{
    public class ItemDetailHandler : IRequestHandler<ItemDetailHandlerRequest, DetailItemViewModel>
    {
        public IContext _context;
        public ItemDetailHandler(IContext context)
        {
            _context = context;
        }

        public async Task<DetailItemViewModel> Handle(ItemDetailHandlerRequest request, CancellationToken cancellationToken)
        {
            var result = _context.Item.Find(request.Id);

            var contactPerson = _context.ContactPersons.Find(result.ContactPersonId);

            var category = _context.Category.Find(result.CategoryId);

            return new DetailItemViewModel
            {
                Id = result.Id,
                Title = result.Title,
                Description = result.Description,
                ContactPersonFullName = contactPerson.FullName,
                ContactPersonPhoneNumber = contactPerson.PhoneNumber,
                IsItemFound = result.IsFound,
                Category = MappingExtensions.CodeToEnum(category.Description)
            };
        }
    }
}
