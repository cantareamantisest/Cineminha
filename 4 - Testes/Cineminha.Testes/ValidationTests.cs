using Cineminha.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cineminha.Testes
{
    public class ValidationTests
    {
        [Theory]
        [InlineData(0, 1, "0001-01-01", "00:00:00", 0, 0, 0, false)]
        [InlineData(2, 0, "0001-01-01", "00:00:00", 0, 0, 0, false)]
        [InlineData(0, 0, "0001-01-01", "00:00:00", 45, 0, 0, false)]
        [InlineData(1, 1, "0001-01-01", "00:00:00", 0, 0, 0, false)]
        [InlineData(1, 2, "0001-01-01", "00:00:00", 45, 0, 1, false)]
        [InlineData(2, 1, "0001-01-01", "00:00:00", 45, 2, 0, false)]
        [InlineData(1, 2, "0001-01-01", "00:00:00", 45, 3, 1, false)]
        [InlineData(1, 1, "2022-10-31", "15:30:00", 45, 1, 1, true)]
        public void TesteValidarSessao(int idFilme, int idSala, string data, string horaInicio, decimal valorIngresso, int tipoAnimacao, int tipoAudio, bool isValid)
        {
            var sessao = new SessaoViewModel
            {
                IdFilme = idFilme,
                IdSala = idSala,
                Data = DateTime.Parse(data),
                HoraInicio = TimeSpan.Parse(horaInicio),
                TipoAnimacao = tipoAnimacao,
                TipoAudio = tipoAudio
            };
            Assert.Equal(isValid, ValidarModelo(sessao));
        }

        [Theory]
        [InlineData(null, null, 0, false)]
        [InlineData(null, "", 10, false)]
        [InlineData("", null, 60, false)]
        [InlineData(null, null, 80, false)]
        [InlineData("Titulo Filme", "", 60, false)]
        [InlineData("Titulo Filme", null, 0, false)]
        [InlineData("Titulo Filme", "Descrição Filme", 90, true)]
        public void TesteValidarFilme(string titulo, string descricao, int duracao, bool isValid)
        {
            var filme = new FilmeViewModel
            {
                Imagem = new byte[30],
                Titulo = titulo,
                Descricao = descricao,
                Duracao = duracao
            };

            Assert.Equal(isValid, ValidarModelo(filme));
        }

        private bool ValidarModelo(object modelo)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(modelo, null, null);
            return Validator.TryValidateObject(modelo, ctx, validationResults, true);
        }
    }
}
