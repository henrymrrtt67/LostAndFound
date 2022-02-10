using LostAndFoundBoard.Application.Requests;
using LostAndFoundBoard.Application.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LostAndFoundBoard.UI.Controllers
{
    public class ItemController : Controller
    {
        private IMediator _mediator;

        public ItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int Id)
        {
            return View(await _mediator.Send(new ItemDetailHandlerRequest{ Id = Id }));
        }


        [HttpGet]
        public IActionResult CreateItem()
        {
            return View(new CreateItemViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem(CreateItemViewModel request)
        {
            await _mediator.Send(new CreateItemCommandRequest { ViewModel = request });
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> EditItem(int Id)
        {
            return View(await _mediator.Send(new EditItemHandlerRequest { Id = Id }));
        }

        [HttpPost]
        public async Task<IActionResult> EditItem(EditItemViewModel request)
        {
            await _mediator.Send(new EditItemCommandRequest { ViewModel = request });
            return RedirectToAction("Index", "Home");
        }
    }
}
