using System.ComponentModel.DataAnnotations;

namespace Cineminha.Aplicacao.ViewModels
{
    public class UsuarioViewModel
    {
        [Key]
        public int IdUsuario { get; set; }

        [Required]
        [Display(Name = "Nome")]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Login")]
        [StringLength(100)]
        public string Login { get; set; }

        [Required]
        [Display(Name = "Senha")]
        [StringLength(200)]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required]
        [Display(Name = "Função")]
        [StringLength(100)]
        public string Funcao { get; set; }
    }
}