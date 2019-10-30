using Banco.Services.Models;

namespace Banco.Services.Repositories
{
    public interface ILancamentoRepository
    {
        void Create(Lancamento lancamento);
        void Credito(Lancamento lancamento);
        void Debito(Lancamento lancamento);
        void Transferencia(string ContaDe, string ContaPara, decimal Valor);
    }
}