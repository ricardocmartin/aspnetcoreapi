using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Banco.Services.Models
{
    public class ContaCorrente : GenericModel
    {
        public ContaCorrente(int Id)
        {
            this.Id = Id;
        }

        public ContaCorrente(string codigo, decimal saldo)
        {
            Codigo = codigo;
            Saldo = saldo;
        }

        [DataMember(IsRequired = true)]
        public string Codigo { get; set; }

        [DataMember(IsRequired = true)] 
        public decimal Saldo { get; set; }
        public List<Lancamento> Lancamentos { get; set; }

    }
}
