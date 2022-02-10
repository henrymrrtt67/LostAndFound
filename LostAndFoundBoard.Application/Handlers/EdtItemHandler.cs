using LostAndFoundBoard.Application.Enums;
using LostAndFoundBoard.Application.Requests;
using LostAndFoundBoard.Application.ViewModel;
using LostAndFoundLibrary.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LostAndFoundBoard.Application.Handlers
{
    public class EdtItemHandler : IRequestHandler<EditItemHandlerRequest, EditItemViewModel>
    {
        private IContext _context;
        public EdtItemHandler(IContext context)
        {
            _context = context;
        }


        public async Task<EditItemViewModel> Handle(EditItemHandlerRequest request, CancellationToken cancellationToken)
        {
            var result = _context.Item.Find(request.Id);

            var contactPerson = _context.ContactPersons.Find(result.ContactPersonId);

            var category = _context.Category.Find(result.CategoryId);

            return new EditItemViewModel
            {
                Id = result.Id,
                Title = result.Title,
                Description = result.Description,
                ContactPersonFullName = contactPerson.FullName,
                ContactPersonPhoneNumber = contactPerson.PhoneNumber,
                IstemFound = result.IsFound,
                Category = MappingExtensions.CodeToEnum(category.Description)
            };

        }
    }
}
