using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using System.Text;
using Arbetsprov.Models;
using System.Net;
using System.Net.Mail;


namespace Arbetsprov.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Products()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }


        //Actiont to send email
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(EmailFormModel model)
        {
            if (ModelState.IsValid)
            {
                //Format body
                var body = "<p>Email from: {0} ({1})</p><p>Message:</p><p>{2}</p>";

                //Create new mail message
                var message = new MailMessage();

                //Format mail message
                message.To.Add(new MailAddress("andreejansson99@gmail.com"));
                message.From = new MailAddress(model.FromEmail);
                message.Subject = model.Subject;
                message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
                message.IsBodyHtml = true;

                //*Setting up SMTP client
                using(var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        //Only placeholders, needs to be replaced for it to actually worked
                        UserName = "email",
                        Password = "passwords"
                    };

                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;

                    //*Send message async
                    await smtp.SendMailAsync(message);

                    //*Return
                    return RedirectToAction("Sent");
                }
            }

            return View();
        }

        //Action result to confirm email sent
        public ActionResult Sent()
        {
            return View();
        }

    }
}