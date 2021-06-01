using System;
using WebApi2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi2.Services
{
    public interface ICalculaJurosService
    {
        Task<TaxaJuros> GetTaxaJurosAsync(string UrlServer);
    }
}
