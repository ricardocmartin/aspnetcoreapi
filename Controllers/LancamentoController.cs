using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Banco.Services.Models;
using Banco.Services.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Banco.Services.Controllers
{
    public class LancamentoController : Controller
    {
        private readonly ILancamentoRepository lancamentoRepository;

        public LancamentoController(ILancamentoRepository lancamentoRepository)
        {
            this.lancamentoRepository = lancamentoRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Debito(Lancamento lancamento)
        {
            this.lancamentoRepository.Debito(lancamento);
            return View();
        }

        public IActionResult Credito(Lancamento lancamento)
        {
            this.lancamentoRepository.Credito(lancamento);
            return View();
        }
    }
}