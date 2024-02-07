using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Application.Hotel.Queries.GetHotelByEncodedName
{
    public class GetHotelByEncodedNameQuery : IRequest<HotelDto>
    {
        public string EncodedName { get; set; }
        public GetHotelByEncodedNameQuery(string encodedName)
        {
            EncodedName = encodedName;
        }
    }
}
