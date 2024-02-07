using AutoMapper;
using Hotels.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Application.Hotel.Queries.GetAllHotelQuery
{
    internal class GetAllHotelHandler : IRequestHandler<GetAllHotelQuery, IEnumerable<HotelDto>>
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IMapper _mapper;

        public GetAllHotelHandler(IHotelRepository hotelRepository, IMapper mapper)
        {
            _hotelRepository = hotelRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<HotelDto>> Handle(GetAllHotelQuery request, CancellationToken cancellationToken)
        {
            var hotels = await _hotelRepository.GetAll();
            var dtos = _mapper.Map<IEnumerable<HotelDto>>(hotels);

            return dtos;
        }
    }
}
