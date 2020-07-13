using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Ecommerce.Libraries.Email
{
    public class ContatoEmail
    {
        public static void EnviarContatoPorEmail(Contato contato)
        {
            //Usando servidor SMTP para envio de email(usando o servidor do gmail)
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("gabriel.origa4r@gmail.com", "Dani0503");
            //Usando protocolo de segurança ssl
            smtp.EnableSsl = true;

            MailMessage mensagem = new MailMessage();
            mensagem.From = new MailAddress("gabriel.origa4r@gmail.com");
            mensagem.To.Add(contato.Email);
            mensagem.Subject = "Criação de conta no Ecommerce";
            mensagem.IsBodyHtml = true;
            mensagem.Body = string.Format("<h2>{0}</h2>", contato.Texto);

            smtp.Send(mensagem);
        }
    }
}
