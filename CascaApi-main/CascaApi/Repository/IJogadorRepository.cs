using CascaApi.Models;

namespace CascaApi.Repository
{
    public interface IJogadorRepository
    {
        bool Adicionar(JogadorModel jogador);
        IReadOnlyCollection<JogadorModel> Listar();
        IReadOnlyCollection<JogadorModel> ListarNaPeneira();
        bool AtualizarAprovacao(string cpf, bool aprovado);
    }
}
