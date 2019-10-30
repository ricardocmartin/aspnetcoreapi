using System.Collections.Generic;
using Banco.Services.Models;

namespace Banco.Services.Repositories
{
    public interface IContaCorrenteRepository
    {
        void Create(ContaCorrente contaCorrente);
        ContaCorrente Read(int Id);
        List<ContaCorrente> ReadAll();
    }
}