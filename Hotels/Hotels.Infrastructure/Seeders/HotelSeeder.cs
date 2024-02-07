using Hotels.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Infrastructure.Seeders
{
    public class HotelSeeder
    {
        private readonly HotelsDbContext _dbContext;

        public HotelSeeder(HotelsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if(await _dbContext.Database.CanConnectAsync())
            {
                if(!_dbContext.Hotel.Any())
                {
                    var niedzwiadek = new Domain.Entities.Hotel()
                    {
                        Name = "Niedziwadek",
                        Description = "Hotel przy stoku.",
                        ContactDetails = new()
                        {
                            City = "Zakopane",
                            Street = "Górska",
                            PostalCode = "10-220",
                            PhoneNumber = "991026601"
                        }
                    };

                    var hotel1 = new Domain.Entities.Hotel()
                    {
                        Name = "HotelA",
                        Description = "Hotel przy stoku.",
                        ContactDetails = new()
                        {
                            City = "CityA",
                            Street = "StreetA",
                            PostalCode = "01-234",
                            PhoneNumber = "111223344"
                        }
                    };

                    var hotel2 = new Domain.Entities.Hotel()
                    {
                        Name = "HotelB",
                        Description = "Hotel przy stoku.",
                        ContactDetails = new()
                        {
                            City = "CityB",
                            Street = "StreetB",
                            PostalCode = "12-345",
                            PhoneNumber = "223344556"
                        }
                    };

                    var hotel3 = new Domain.Entities.Hotel()
                    {
                        Name = "HotelC",
                        Description = "Hotel przy stoku.",
                        ContactDetails = new()
                        {
                            City = "CityC",
                            Street = "StreetC",
                            PostalCode = "23-456",
                            PhoneNumber = "334455667"
                        }
                    };

                    var hotel4 = new Domain.Entities.Hotel()
                    {
                        Name = "HotelD",
                        Description = "Hotel przy stoku.",
                        ContactDetails = new()
                        {
                            City = "CityD",
                            Street = "StreetD",
                            PostalCode = "34-567",
                            PhoneNumber = "445566778"
                        }
                    };

                    var hotel5 = new Domain.Entities.Hotel()
                    {
                        Name = "HotelE",
                        Description = "Hotel przy stoku.",
                        ContactDetails = new()
                        {
                            City = "CityE",
                            Street = "StreetE",
                            PostalCode = "45-678",
                            PhoneNumber = "556677889"
                        }
                    };

                    var hotel6 = new Domain.Entities.Hotel()
                    {
                        Name = "HotelF",
                        Description = "Hotel przy stoku.",
                        ContactDetails = new()
                        {
                            City = "CityF",
                            Street = "StreetF",
                            PostalCode = "56-789",
                            PhoneNumber = "667788990"
                        }
                    };

                    var hotel7 = new Domain.Entities.Hotel()
                    {
                        Name = "HotelG",
                        Description = "Hotel przy stoku.",
                        ContactDetails = new()
                        {
                            City = "CityG",
                            Street = "StreetG",
                            PostalCode = "67-890",
                            PhoneNumber = "778899001"
                        }
                    };

                    var hotel8 = new Domain.Entities.Hotel()
                    {
                        Name = "HotelH",
                        Description = "Hotel przy stoku.",
                        ContactDetails = new()
                        {
                            City = "CityH",
                            Street = "StreetH",
                            PostalCode = "78-901",
                            PhoneNumber = "889900112"
                        }
                    };

                    var hotel9 = new Domain.Entities.Hotel()
                    {
                        Name = "HotelI",
                        Description = "Hotel przy stoku.",
                        ContactDetails = new()
                        {
                            City = "CityI",
                            Street = "StreetI",
                            PostalCode = "89-012",
                            PhoneNumber = "990011223"
                        }
                    };

                    var hotel10 = new Domain.Entities.Hotel()
                    {
                        Name = "HotelJ",
                        Description = "Hotel przy stoku.",
                        ContactDetails = new()
                        {
                            City = "CityJ",
                            Street = "StreetJ",
                            PostalCode = "90-123",
                            PhoneNumber = "001122334"
                        }
                    };
                    niedzwiadek.EncodeName();
                    hotel1.EncodeName();
                    hotel2.EncodeName();
                    hotel3.EncodeName();
                    hotel4.EncodeName();
                    hotel5.EncodeName();
                    hotel6.EncodeName();
                    hotel7.EncodeName();
                    hotel8.EncodeName();
                    hotel9.EncodeName();
                    hotel10.EncodeName();


                    _dbContext.Hotel.Add(niedzwiadek);
                    _dbContext.Hotel.Add(hotel1);
                    _dbContext.Hotel.Add(hotel2);
                    _dbContext.Hotel.Add(hotel3);
                    _dbContext.Hotel.Add(hotel4);
                    _dbContext.Hotel.Add(hotel5);
                    _dbContext.Hotel.Add(hotel6);
                    _dbContext.Hotel.Add(hotel7);
                    _dbContext.Hotel.Add(hotel8);
                    _dbContext.Hotel.Add(hotel9);
                    _dbContext.Hotel.Add(hotel10);

                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
