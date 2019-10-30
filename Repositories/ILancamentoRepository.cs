using Banco.Services.Models;

namespace Banco.Services.Repositories
{
    public interface ILancamentoRepository
    {
        void Credito(Lancamento lancamento);
        void Debito(Lancamento lancamento);
    }
}