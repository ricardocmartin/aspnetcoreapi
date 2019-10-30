using Banco.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banco.Services.Repositories
{
    public class LancamentoRepository : ILancamentoRepository
    {
        private readonly ApplicationContext context;

        public LancamentoRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public void Credito(Lancamento lancamento)
        {
            lancamento.ContaCorrente.Saldo += lancamento.Valor;
            this.context.Update(lancamento.ContaCorrente);

            this.context.Add(lancamento);
            this.context.SaveChanges();
        }


        public void Debito(Lancamento lancamento)
        {
            lancamento.ContaCorrente.Saldo += lancamento.Valor;

            //TODO: limite de crédito?
            if (lancamento.ContaCorrente.Saldo < 0)
                throw new Exception("O Saldo não pode ser negativo");

            //TODO: Resiliência?
            this.context.Update(lancamento.ContaCorrente);
            this.context.Add(lancamento);
            this.context.SaveChanges();
        }
    }
}
