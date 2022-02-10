using LostAndFoundBoard.Application.Requests;
using LostAndFoundBoard.Application.ViewModel;
using LostAndFoundLibrary.Domain.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LostAndFoundBoard.Application.Handlers
{
    public class IndexHandler : IRequestHandler<IndexHandlerRequest, IndexListingViewModel>
    {
        private IContext _context;
        public IndexHandler(IContext context) 
        {
            _context = context;
        }

        public async Task<IndexListingViewModel> Handle(IndexHandlerRequest request, CancellationToken cancellationToken)
        {
            var result =  new IndexListingViewModel{
                IndexModels = _context.Item.Select(x => new IndexModel {
                Title = x.Title,
                Descrpition = x.Description,
                Id = x.Id,
                Category = x.Category.Description,
                IsFound = x.IsFound
            }).ToList()};
            return result;
        }
    }
}
