using Microsoft.AspNetCore.Mvc;
using System;
using WebApiTaxaJuros.Controllers;
using WebApiTaxaJuros.Models;
using Xunit;

namespace WebApiTaxaJurosTest
{
    public class TaxaJurosControllerTest
    {
        TaxaJurosController _controller;
        
        public TaxaJurosControllerTest()
        {            
            _controller = new TaxaJurosController();
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.GetTaxaJuros();
            
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Get_WhenCalled_ShouldReturn0dot01()
        {
            // Arrange
            TaxaJuros TaxaEsperada = new TaxaJuros
            {
                Id = 1,
                Taxa = (decimal)0.01
            };
            
            // Act            
            var okResult = _controller.GetTaxaJuros().Result as OkObjectResult;
            var TaxaRecebida = Assert.IsType<TaxaJuros>(okResult.Value);
            
            // Assert
            Assert.Equal(TaxaEsperada.Taxa, TaxaRecebida.Taxa);
        }
    }
}
