using ficym.Entities;
using ficym.IServices.location;

namespace ficym.Services
{
    public class LocalizacaoService : ILocalizacaoService
    {
        public async Task<Coordenadas> GetLocalizacaoAtual(CancellationToken cancellationToken)
        {
            Console.WriteLine("Location service passou...");
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Best, TimeSpan.FromSeconds(1));
                var loc = await Geolocation.GetLocationAsync(request, cancellationToken);

                if (loc != null)
                {
                    return new Coordenadas()
                    {
                        Latitude = loc.Latitude,
                        Longitude = loc.Longitude,
                        Altitude = loc.Altitude,
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
            return new Coordenadas()
            {
                Latitude = 404,
                Longitude = 404,
                Altitude = 404,
            };
        }
    }
}
