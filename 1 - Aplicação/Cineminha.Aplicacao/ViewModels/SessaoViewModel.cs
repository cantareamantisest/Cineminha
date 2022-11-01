using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Cineminha.Aplicacao.ViewModels
{
    public class SessaoViewModel
    {
        [Key]
        public int IdSessao { get; set; }

        [Required]
        [Display(Name = "Nome do Filme")]
        public int IdFilme { get; set; }

        [Required]
        [Display(Name = "Nome da Sala")]
        public int IdSala { get; set; }

        [Required]
        [Display(Name = "Data da Sessão")]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "Hora de Início")]
        [DataType(DataType.Time)]
        public TimeSpan HoraInicio { get; set; }

        [Display(Name = "Hora de Término")]
        public TimeSpan HoraTermino
        {
            get { return HoraTerminoCalculada(HoraInicio); }
        }

        [Required]
        [Display(Name = "Valor do Ingresso")]
        [DataType(DataType.Currency)]
        public decimal ValorIngresso { get; set; }

        [Display(Name = "Tipo de Animação")]
        public int TipoAnimacao { get; set; }

        [Display(Name = "Tipo de Áudio")]
        public int TipoAudio { get; set; }

        public string AuxiliarTipoAnimacao
        {
            get
            {
                return TipoAnimacao switch
                {
                    1 => "2D",
                    2 => "3D",
                    _ => string.Empty
                };
            }
        }

        public string AuxiliarTipoAudio
        {
            get
            {
                return TipoAudio switch
                {
                    1 => "Original",
                    2 => "Dublado",
                    _ => string.Empty
                };
            }
        }

        public virtual FilmeViewModel? Filme { get; set; }

        public virtual SalaViewModel? Sala { get; set; }

        public List<SelectListItem>? SelectListTipoAnimacao { get; set; }

        public List<SelectListItem>? SelectListTipoAudio { get; set; }

        public List<SelectListItem>? SelectListFilme { get; set; }

        public List<SelectListItem>? SelectListSala { get; set; }

        private TimeSpan HoraTerminoCalculada(TimeSpan horaInicio)
        {
            var duration = Filme != null ? (double)Filme.Duracao : 0;
            return horaInicio.Add(TimeSpan.FromMinutes(duration));
        }
    }
}