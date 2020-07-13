using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Ecommerce.Libraries.Lang;

namespace Ecommerce.Models
{
    public class Contato
    {
        //Faz a validação do campo
        [Required]
        public string Nome { get; set; }
        [Required]
        //Faz a validação para ver se o E-mail esta em um formato valido.
        [EmailAddress(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E001")]
        public string Email { get; set; }
        [Required]
        public string Texto { get; set; }
    }
}
