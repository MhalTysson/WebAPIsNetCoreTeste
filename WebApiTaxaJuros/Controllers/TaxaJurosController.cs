using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTaxaJuros.Models;

namespace WebApiTaxaJuros.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TaxaJurosController : ControllerBase
    {
        [HttpGet]
        public ActionResult<TaxaJuros> GetTaxaJuros()
        {
            TaxaJuros TaxaFixa = new TaxaJuros
            {
                Id = 1,
                Taxa = (decimal)0.01
            };

            return Ok(TaxaFixa);
        }
    }
}
