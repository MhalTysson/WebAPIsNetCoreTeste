using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WebApi2.Models;

namespace WebApi2.Services
{
    public class CalculaJurosService : ICalculaJurosService
    {
        public async Task<TaxaJuros> GetTaxaJurosAsync(string UrlServer)
        {
            try
            {
                TaxaJuros TaxaRecebida;
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(UrlServer))
                    {
                        string WebApi1Response = await response.Content.ReadAsStringAsync();
                        TaxaRecebida = JsonSerializer.Deserialize<TaxaJuros>(WebApi1Response, new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        });
                    }
                }
                return TaxaRecebida;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
