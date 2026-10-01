using CascaApi.Models;

namespace CascaApi.Repository
{
    public class JogadorRepository : IJogadorRepository
    {
        private readonly List<JogadorModel> _jogadores = [];
        private readonly object _sync = new();

        public bool Adicionar(JogadorModel jogador)
        {
            lock (_sync)
            {
                var cpf = NormalizarCpf(jogador.Cpf);
                if (_jogadores.Any(cadastrado => NormalizarCpf(cadastrado.Cpf) == cpf))
                    return false;

                _jogadores.Add(jogador);
                return true;
            }
        }

        public IReadOnlyCollection<JogadorModel> Listar()
        {
            lock (_sync) return _jogadores.ToArray();
        }

        public IReadOnlyCollection<JogadorModel> ListarNaPeneira()
        {
            lock (_sync) return _jogadores.Where(jogador => !jogador.Aprovado).ToArray();
        }

        public bool AtualizarAprovacao(string cpf, bool aprovado)
        {
            lock (_sync)
            {
                var jogador = _jogadores.FirstOrDefault(j => NormalizarCpf(j.Cpf) == NormalizarCpf(cpf));
                if (jogador is null) return false;
                jogador.Aprovado = aprovado;
                return true;
            }
        }

        private static string NormalizarCpf(string cpf) => new string(cpf.Where(char.IsDigit).ToArray());
    }
}
