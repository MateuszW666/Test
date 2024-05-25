using Zadanie5.Interfaces;
using Zadanie5.Models;
using Zadanie5.Models.DTOs;

namespace Zadanie5.Repositories
{
    public class TripsRepository : ITripsRepository
    {
        private readonly APBDZadanie7Contex _contex;

        public TripsRepository(APBDZadanie7Contex contex)
        {
            _contex = contex;
        }
        public Task<IEnumerable<TripDTO>> GetTripsAsync()
        {
            var result = _contex
                .Trips
                .Select(e =>
                new TripDTO
                {
                    Name = e.Name,
                    Description = e.Description,
                    DateFrom = DateOnly.FromDateTime(e.DateFrom),
                    DateTo = DateOnly.FromDateTime(e.DateTo),
                    MaxPeople = e.MaxPeople,
                    Countries = e.Countries
                        .Select(e =>
                        new CountryDTO { Name = e.Name}),
                    Clients = e.ClientTrips
                        .Select(e => new ClientDTO { FirstName = e.IdClientNavigation.FirstName, LastName = e.IdClientNavigation.LastName }),
                }).ToList();

            return result;
        }
    }
}
