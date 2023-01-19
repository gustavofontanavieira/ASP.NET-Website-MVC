using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyMVCSite.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Digite o nome do contato")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o E-mail do contato")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Digite o número do contato")]
        [Phone(ErrorMessage = "O celular não é válido")]
        public string Numero { get; set; }
    }

}
