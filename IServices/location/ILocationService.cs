using ficym.Entities;

namespace ficym.IServices.location
{
    public interface ILocationService
    {
        Task<GeoCordinates> GetCurrenteLocation(CancellationToken cancellationToken);
    }
}
