using System.ComponentModel.DataAnnotations;

namespace Cineminha.Aplicacao.ViewModels
{
    public class SalaViewModel
    {
        [Key]
        public int IdSala { get; set; }

        [Required]
        [Display(Name = "Nome da Sala")]
        [StringLength(200)]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Quantidade de Assentos")]
        [Range(1, 9999)]
        public int Assentos { get; set; }

        public virtual ICollection<SessaoViewModel> Sessoes { get; set; } = new List<SessaoViewModel>();
    }
}