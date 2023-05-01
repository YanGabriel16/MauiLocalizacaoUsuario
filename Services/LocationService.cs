using ficym.Entities;
using ficym.IServices.location;

namespace ficym.Services
{
    public class LocationService : ILocationService
    {
        public async Task<GeoCordinates> GetCurrenteLocation(CancellationToken cancellationToken)
        {
            Console.WriteLine("Location service passou...");
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Best, TimeSpan.FromSeconds(1));
                var location = await Geolocation.GetLocationAsync(request, cancellationToken);

                if (location != null)
                {
                    return new GeoCordinates()
                    {
                        Latitude = location.Latitude,
                        Longitude = location.Longitude,
                        Altitude = location.Altitude,
                    };
                }
            }
            catch (FeatureNotSupportedException ex)
            {
                Console.WriteLine(ex);
            }
            catch (FeatureNotEnabledException ex)
            {
                Console.WriteLine(ex);
            }
            catch (PermissionException ex)
            {
                Console.WriteLine(ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return new GeoCordinates()
            {
                Latitude = 404,
                Longitude = 404,
                Altitude = 404,
            };
        }
    }
}
