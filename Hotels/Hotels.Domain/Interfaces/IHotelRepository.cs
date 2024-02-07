using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Domain.Interfaces
{
    public interface IHotelRepository
    {
        Task Create(Domain.Entities.Hotel hotel);
        Task<Domain.Entities.Hotel?> GetByName(string name);
        Task<IEnumerable<Domain.Entities.Hotel>> GetAll();
        Task<Domain.Entities.Hotel> GetByEncodedName(string encodedName);
        Task Commit();
    }
}
