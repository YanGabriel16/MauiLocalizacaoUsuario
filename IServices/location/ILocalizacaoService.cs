using ficym.Entities;

namespace ficym.IServices.location
{
    public interface ILocalizacaoService
    {
        Task<Coordenadas> GetLocalizacaoAtual(CancellationToken cancellationToken);
    }
}
