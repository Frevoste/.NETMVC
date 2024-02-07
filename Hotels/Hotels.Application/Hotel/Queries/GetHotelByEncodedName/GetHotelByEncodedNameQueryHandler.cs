using AutoMapper;
using Hotels.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Application.Hotel.Queries.GetHotelByEncodedName
{
    public class GetHotelByEncodedNameQueryHandler : IRequestHandler<GetHotelByEncodedNameQuery, HotelDto>
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IMapper _mapper;

        public GetHotelByEncodedNameQueryHandler(IHotelRepository hotelRepository, IMapper mapper)
        {
            _hotelRepository = hotelRepository;
            _mapper = mapper;
        }
        public async Task<HotelDto> Handle(GetHotelByEncodedNameQuery request, CancellationToken cancellationToken)
        {
            var hotel = await _hotelRepository.GetByEncodedName(request.EncodedName);
            var dto = _mapper.Map<HotelDto>(hotel);

            return dto;

        }
    }
}
