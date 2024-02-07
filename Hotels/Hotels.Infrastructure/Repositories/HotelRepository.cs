using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotels.Domain.Entities;
using Hotels.Domain.Interfaces;
using Hotels.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Hotels.Infrastructure.Repositories
{
    internal class HotelRepository : IHotelRepository
    {
        private readonly HotelsDbContext _dbContext;
        public HotelRepository(HotelsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task Commit()
            => _dbContext.SaveChangesAsync();

        public async Task Create(Hotel hotel)
        {
            _dbContext.Add(hotel);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Hotel>> GetAll()
            => await _dbContext.Hotel.ToListAsync();

        public async Task<Hotel> GetByEncodedName(string encodedName)
            => await _dbContext.Hotel.FirstAsync(h => h.EncodedName == encodedName);

        public Task<Hotel?> GetByName(string name)
           => _dbContext.Hotel.FirstOrDefaultAsync(h => h.Name.ToLower() == name.ToLower());

    }
}
