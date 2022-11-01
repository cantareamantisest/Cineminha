using Cineminha.Apresentacao.Mvc.Controllers;
using Cineminha.Testes.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cineminha.Testes
{
    public class SessionControllerTests
    {
        [Fact]
        public void QuandoObterTodasSessoes_EntaoRetornarTodasSessoes()
        {
            var mockSessaoAplicacao = MockISessaoAplicacao.GetMock();
            //var sessionController = new SessionManagerController(mockSessaoAplicacao);
        }
    }
}
