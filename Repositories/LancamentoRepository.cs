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


        public void Create(Lancamento lancamento)
        {
            this.context.Set<Lancamento>().Add(lancamento);
            this.context.SaveChanges();
        }


        public void Transferencia(string ContaDe, string ContaPara, decimal Valor)
        {

            var contaCorrenteDe = this.context.Set<ContaCorrente>().Where(e => e.Codigo == ContaDe).SingleOrDefault();
            var contaCorrentePara = this.context.Set<ContaCorrente>().Where(e => e.Codigo == ContaPara).SingleOrDefault();

            var lancamentoDebito = new Lancamento()
            {
                ContaCorrente = contaCorrenteDe,
                Valor = Valor
            };

            var lancamentoCredito = new Lancamento()
            {
                ContaCorrente = contaCorrentePara,
                Valor = Valor
            };

            this.Debito(lancamentoDebito);
            this.Credito(lancamentoCredito);
        }

        public void Credito(Lancamento lancamento)
        {
            if (string.IsNullOrEmpty(lancamento.ContaCorrente.Codigo))
            {
                lancamento.ContaCorrente = context.Set<ContaCorrente>().Find(lancamento.ContaCorrente.Id);
            }

            lancamento.ContaCorrente.Saldo += lancamento.Valor;
            lancamento.IsCredit = true;
            this.context.Set<ContaCorrente>().Update(lancamento.ContaCorrente);
            this.context.Set<Lancamento>().Add(lancamento);
            this.context.SaveChanges(true);
        }

        public void Debito(Lancamento lancamento)
        {
            if (string.IsNullOrEmpty(lancamento.ContaCorrente.Codigo))
            {
                lancamento.ContaCorrente = context.Set<ContaCorrente>().Find(lancamento.ContaCorrente.Id);
            }

            lancamento.ContaCorrente.Saldo -= lancamento.Valor;
            lancamento.IsCredit = false;
            //TODO: limite de crédito?
            if (lancamento.ContaCorrente.Saldo < 0)
                throw new Exception("O Saldo não pode ser negativo");

            this.context.Set<ContaCorrente>().Update(lancamento.ContaCorrente);
            this.context.Set<Lancamento>().Add(lancamento);
            this.context.SaveChanges(true);
        }


    }
}
