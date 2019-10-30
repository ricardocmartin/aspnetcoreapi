using System.Collections.Generic;
using Banco.Services.Models;

namespace Banco.Services.Repositories
{
    public interface IContaCorrenteRepository
    {
        void Create(ContaCorrente contaCorrente);
        ContaCorrente GetByCodigo(string Codigo);
        ContaCorrente Read(int Id);
        List<ContaCorrente> ReadAll();
        void Transferencia(string ContaDe, string ContaPara, decimal Valor);
        void Update(ContaCorrente contaCorrente);
    }
}