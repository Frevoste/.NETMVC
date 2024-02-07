using AutoMapper;
using Hotels.Application.ApplicationUser;
using Hotels.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Application.Hotel.Commands.CreateHotel
{
    public class CreateHotelCommandHandler : IRequestHandler<CreateHotelCommand>
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;

        public CreateHotelCommandHandler(IHotelRepository hotelRepository, IMapper mapper, IUserContext userContext)
        {
            _hotelRepository = hotelRepository;
            _mapper = mapper;
            _userContext = userContext;

        }
        public async Task<Unit> Handle(CreateHotelCommand request, CancellationToken cancellationToken)
        {
            var currentUser = _userContext.GetCurrentUser();
            if (currentUser == null || !currentUser.IsInRole("Owner"))
            {
                return Unit.Value;
            }
            var hotel = _mapper.Map<Domain.Entities.Hotel>(request);
            hotel.EncodeName();

            hotel.CreatedById = currentUser.Id;

            await _hotelRepository.Create(hotel);

            return Unit.Value;
        }
    }
}
