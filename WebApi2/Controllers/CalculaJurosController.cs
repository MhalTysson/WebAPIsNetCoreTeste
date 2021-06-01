using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi2.Models;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using WebApi2.Services;

namespace WebApi2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CalculajurosController : ControllerBase
    {
        private readonly ICalculaJurosService _service;
        public CalculajurosController(ICalculaJurosService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<string>> GetJurosCompostos([FromQuery] decimal ValorInicial, [FromQuery] int Meses)
        {
            try
            {
                const string WebApi1Url = "https://localhost:44321/TaxaJuros/";

                TaxaJuros TaxaAplicada = await _service.GetTaxaJurosAsync(WebApi1Url);

                double ValorCalculado = (double)ValorInicial * Math.Pow((double)(1 + TaxaAplicada.Taxa), (double)(Meses));

                int PosVirgula = ValorCalculado.ToString().IndexOf(",");

                string ValorFinal;
                if (PosVirgula == -1)
                {
                    ValorFinal = ValorCalculado.ToString("#0.00");
                    return Ok(ValorFinal);
                }
                
                ValorFinal = ValorCalculado.ToString().Substring(0,PosVirgula + 3);
                
                return Ok(ValorFinal);
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
