using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Libraries.Email;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ecommerce.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Contato()
        {
            return View();
        }
        public IActionResult ContatoAcao()
        {
            //Verifica se há algum erro no envio, caso não haja envia com sucesso.
            try
            {
                Contato contato = new Contato();

                contato.Nome = HttpContext.Request.Form["nome"];
                contato.Email = HttpContext.Request.Form["email"];
                contato.Texto = HttpContext.Request.Form["texto"];

                var ListaMensagens = new List<ValidationResult>();
                var contexto = new ValidationContext(contato);
                //Verifica se houve erros e retorna pro booleano true ou false.
                bool isValid = Validator.TryValidateObject(contato, contexto, ListaMensagens, true);

                //Verifica se todas as validações deram sucesso e caso tenha dado executa o envio de email.
                if (isValid)
                {
                    //Envia o Email.
                    ContatoEmail.EnviarContatoPorEmail(contato);
                    //Atribui a mensagem de sucesso para a variavel de viewData
                    ViewData["MSG_S"] = "Mensagem de contato enviada com sucesso.";
                }
                //Se não der sucesso no envio ele recupera as mensagens de erro e exibe para o usuario.
                else
                {
                    StringBuilder sb = new StringBuilder();
                    //Varre a lista de mensagens de erro e joga para exibição.
                    foreach(var Texto in ListaMensagens)
                    {
                        sb.Append(Texto.ErrorMessage);
                    }
                    ViewData["MSG_E"] = sb.ToString();
                    ViewData["CONTATO"] = contato;
                }
            }
            //Caso haja uma exceção ele trata e devolve uma mensagem de erro. 
            catch (Exception ex)
            {
                ViewData["MSG_E"] = "Desculpe infelizmente tivemos algum problema ao efetuar o envio, tente novamente mais tarde.";
                //TODO - Implementar log
            }
            //Retorna para a tela de contato.
            return View("Contato");

        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult CadastroCliente()
        {
            return View();
        }
        public IActionResult CarrinhoCompras()
        {
            return View();
        }
    }
}
