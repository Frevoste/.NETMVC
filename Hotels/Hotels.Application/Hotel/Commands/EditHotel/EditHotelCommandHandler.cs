using Hotels.Application.ApplicationUser;
using Hotels.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Application.Hotel.Commands.EditHotel
{
    public class EditHotelCommandHandler : IRequestHandler<EditHotelCommand>
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IUserContext _userContext;

        public EditHotelCommandHandler(IHotelRepository hotelRepository, IUserContext userContext)
        {
            _hotelRepository = hotelRepository;
            _userContext = userContext;
        }
        public async Task<Unit> Handle(EditHotelCommand request, CancellationToken cancellationToken)
        {
            var hotel = await _hotelRepository.GetByEncodedName(request.EncodedName!);

            var user = _userContext.GetCurrentUser();
            var isEditable = user != null && hotel.CreatedById == user.Id;

            if(!isEditable)
            {
                return Unit.Value;
            }
            hotel.Description  = request.Description;
            hotel.About =  request.About;

            hotel.ContactDetails.City = request.City;
            hotel.ContactDetails.PhoneNumber = request.PhoneNumber;
            hotel.ContactDetails.PostalCode = request.PostalCode;
            hotel.ContactDetails.Street = request.Street;

            await _hotelRepository.Commit();
            return Unit.Value;        
        }
    }
}
