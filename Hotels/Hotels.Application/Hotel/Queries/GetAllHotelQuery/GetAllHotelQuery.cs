using Hotels.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Application.Hotel.Queries.GetAllHotelQuery
{
    public class GetAllHotelQuery : IRequest<IEnumerable<HotelDto>>
    {

    }
}
