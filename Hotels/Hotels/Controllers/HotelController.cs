using AutoMapper;
using Hotels.Application.Hotel;
using Hotels.Application.Hotel.Commands.CreateHotel;
using Hotels.Application.Hotel.Queries.GetAllHotelQuery;
using Hotels.Application.Hotel.Queries.GetHotelByEncodedName;
using Hotels.Application.Hotel.Commands.EditHotel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Hotels.Controllers
{
    public class HotelController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public HotelController(IMediator mediator, IMapper mapper)
        {
            _mediator=mediator;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var hotels = await _mediator.Send(new GetAllHotelQuery());
            return View(hotels);
        }

        [Route("Hotel/{encodedName}/Details")]
        public async Task<IActionResult> Details(string encodedName)
        {
            var dto = await _mediator.Send(new GetHotelByEncodedNameQuery(encodedName));
            return View(dto);
        }

        [Route("Hotel/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(string encodedName)
        {
            var dto = await _mediator.Send(new GetHotelByEncodedNameQuery(encodedName));
            if(!dto.IsEditable)
            {
                return RedirectToAction("NoAccess", "Home");
            }
            EditHotelCommand model = _mapper.Map<EditHotelCommand>(dto);
            return View(model);

        }

        [HttpPost]
        [Route("Hotel/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(string encodedName, EditHotelCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));

        }
        [Authorize(Roles ="Owner")]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [Authorize(Roles = "Owner")]
        public async Task<IActionResult> Create(CreateHotelCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
    }
}
