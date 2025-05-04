// Services/GoogleMapsService.cs
// Serviço para integração com Google Maps Geocoding API.
using GoogleMaps.LocationServices;

public class GoogleMapsService
{
    private readonly string _apiKey = "SUA_API_KEY_AQUI";

    public (double Latitude, double Longitude) ObterCoordenadas(string endereco)
    {
        var locationService = new GoogleLocationService(_apiKey);
        var ponto = locationService.GetLatLongFromAddress(endereco);

        return (ponto.Latitude, ponto.Longitude);
    }
}
