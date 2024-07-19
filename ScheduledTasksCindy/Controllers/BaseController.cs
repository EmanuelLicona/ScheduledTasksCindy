using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace ScheduledTasksCindy.Controllers
{
    public class BaseController: Controller
    {

        public static void EnviarCorreo()
        {
            //try
            //{
            //    MailMessage mail = new MailMessage("tu_correo@example.com", "destinatario@example.com");
            //    SmtpClient client = new SmtpClient("smtp.example.com");

            //    client.Port = 587; // Puerto SMTP
            //    client.Credentials = new System.Net.NetworkCredential("tu_correo@example.com", "tu_contraseña");
            //    client.EnableSsl = true;

            //    mail.Subject = "Asunto del correo";
            //    mail.Body = "Cuerpo del correo";

            //    client.Send(mail);
            //    Console.WriteLine("Correo enviado exitosamente.");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Error al enviar el correo: " + ex.Message);
            //    throw; // Lanza la excepción para que Hangfire lo capture y programe el reintento
            //}

            Console.WriteLine("Error al enviar el correo: ");

        }

    }
}