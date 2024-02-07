using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Application.Hotel.Commands.CreateHotel
{
    public class CreateHotelCommand : HotelDto, IRequest
    {
    }
}
