namespace Zadanie5.Interfaces
{
    public interface ITripsRepository
    {
        Task<IEnumberable<TripDTO>> GetTripsAsync();
    }
}
