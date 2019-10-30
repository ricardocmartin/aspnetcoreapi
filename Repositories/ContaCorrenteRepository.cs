using Banco.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banco.Services.Repositories
{
    public class ContaCorrenteRepository : IContaCorrenteRepository
    {
        private readonly ApplicationContext context;

        public ContaCorrenteRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public ContaCorrente GetByCodigo(string Codigo)
        {

            return this.context.Set<ContaCorrente>().Where(e => e.Codigo == Codigo).SingleOrDefault();
        }

        public void Transferencia(string ContaDe, string ContaPara, decimal Valor)
        {
            throw new NotImplementedException("Funcão não implementada");
        }

        public void Create(ContaCorrente contaCorrente)
        {
            this.context.Set<ContaCorrente>().Add(contaCorrente);
            this.context.SaveChanges();
        }

        public void Update(ContaCorrente contaCorrente)
        {
            this.context.Set<ContaCorrente>().Update(contaCorrente);
            this.context.SaveChanges();
        }


        public ContaCorrente Read(int Id)
        {
            return this.context.Set<ContaCorrente>().Find(Id);
        }

        public List<ContaCorrente> ReadAll()
        {
            return this.context.Set<ContaCorrente>().ToList();
        }

    }
}
