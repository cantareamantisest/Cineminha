using System.ComponentModel.DataAnnotations;

namespace Cineminha.Apresentacao.Mvc.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}