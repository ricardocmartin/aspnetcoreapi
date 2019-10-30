using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Banco.Services.Models;
using Banco.Services.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Banco.Services.Controllers
{
    public class ContaCorrenteController : Controller
    {
        private readonly IContaCorrenteRepository contaCorrenteRepository;
        private readonly ILancamentoRepository lancamentoRepository;

        //public ContaCorrenteController(IContaCorrenteRepository contaCorrenteRepository, ILancamentoRepository lancamentoRepository)
        public ContaCorrenteController(ApplicationContext applicationContext)
        {

            //this.contaCorrenteRepository = contaCorrenteRepository;
            //this.lancamentoRepository = lancamentoRepository;
            this.contaCorrenteRepository = new ContaCorrenteRepository(applicationContext);
            this.lancamentoRepository = new LancamentoRepository(applicationContext);
        }

        [HttpGet]
        public IActionResult Index()
        {
            var contaCorrenteList = this.contaCorrenteRepository.ReadAll();
            return Ok(contaCorrenteList);
        }

        [HttpGet]
        public ContaCorrente Get(int id)
        {
            var contaCorrente = this.contaCorrenteRepository.Read(id);
            return contaCorrente;
        }


        [HttpGet]
        public ContaCorrente GetByCodigo(string Codigo)
        {
            var contaCorrente = this.contaCorrenteRepository.GetByCodigo(Codigo);
            return contaCorrente;
        }

        public IActionResult Transferencia(string ContaDe, string ContaPara, decimal Valor) {
            this.lancamentoRepository.Transferencia(ContaDe, ContaPara, Valor);
            return null;
        }

        [HttpPost]
        public IActionResult Debito(Lancamento lancamento)
        {
            this.lancamentoRepository.Debito(lancamento);
            return View();
        }

        [HttpPost]
        public IActionResult Credito(Lancamento lancamento)
        {
        
            this.lancamentoRepository.Credito(lancamento);
            return View();
        }

    }
}