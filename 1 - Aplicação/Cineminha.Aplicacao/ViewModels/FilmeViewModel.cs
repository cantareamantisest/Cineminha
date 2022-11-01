using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Cineminha.Aplicacao.ViewModels
{
    public class FilmeViewModel
    {
        [Key]
        public int IdFilme { get; set; }

        [ScaffoldColumn(false)]
        public byte[]? Imagem { get; set; }

        [Required]
        [Display(Name = "Título")]
        [StringLength(200)]
        public string Titulo { get; set; }

        [Required]
        [Display(Name = "Descrição")]
        [StringLength(200)]
        public string Descricao { get; set; }

        [Required]
        [Display(Name = "Duração (minutos)")]
        [Range(1,9999)]
        public int Duracao { get; set; }

        [Required]
        [Display(Name = "Imagem (Tamanho máximo 2 MB)")]
        [DataType(DataType.Upload)]
        public IFormFile UploadImage { get; set; }

        public virtual ICollection<SessaoViewModel> Sessoes { get; set; } = new List<SessaoViewModel>();
    }
}