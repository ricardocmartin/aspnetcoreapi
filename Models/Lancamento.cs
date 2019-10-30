using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Banco.Services.Models
{
    public class Lancamento : GenericModel
    {
        [DataMember(IsRequired = true)]
        public decimal Valor { get; set; }

        [DataMember(IsRequired = true)]
        public DateTime Data { get; set; }


        [DataMember(IsRequired = true)]
        public bool IsCredit { get; set; }

        public ContaCorrente ContaCorrente { get; set; }
    }
}
