using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using WebApi2.Controllers;
using WebApi2.Models;
using WebApi2.Services;
using Xunit;

namespace WebApi2Test
{
    public class CalculaJurosControllerTest
    {
        private CalculajurosController _controller;
        private Mock<ICalculaJurosService> _mock;

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Arrange            
            decimal ValorInicio = 100;
            int Tempo = 5;

            TaxaJuros TaxaEsperada = new TaxaJuros
            {
                Id = 1,
                Taxa = (decimal)0.01
            };

            _mock = new Mock<ICalculaJurosService>();
            _controller = new CalculajurosController(_mock.Object);
            _mock.Setup(x => x.GetTaxaJurosAsync(It.IsAny<string>())).Returns(Task.FromResult(TaxaEsperada));

            // Act
            var okResult = _controller.GetJurosCompostos(ValorInicio,Tempo);

            // Assert
            Assert.IsType<ActionResult<string>>(okResult.Result);
        }

        [Fact]
        public void Get_WhenCalled_ShouldReturn105Dot10()
        {
            // Arrange            
            decimal ValorInicio = 100;
            int Tempo = 5;

            TaxaJuros TaxaEsperada = new TaxaJuros
            {
                Id = 1,
                Taxa = (decimal)0.01
            };

            _mock = new Mock<ICalculaJurosService>();
            _controller = new CalculajurosController(_mock.Object);
            _mock.Setup(x => x.GetTaxaJurosAsync(It.IsAny<string>())).Returns(Task.FromResult(TaxaEsperada));

            // Act
            var okResult = _controller.GetJurosCompostos(ValorInicio, Tempo);
            var ValorCalculado = (OkObjectResult)okResult.Result.Result;
            // Assert
            Assert.Equal("105,10", ValorCalculado.Value);        
        }
    }
}
