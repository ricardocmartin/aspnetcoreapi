using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banco.Services.Models
{
    public class Tranferencia
    {
        public string ContaDe { get; set; }
        public string ContaPara { get; set; }
        public Decimal Valor { get; set; }
    }
}
